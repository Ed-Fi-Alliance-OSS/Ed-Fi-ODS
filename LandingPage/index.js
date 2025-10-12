// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

// @ts-check
// @ts-ignore
import semver from 'https://cdn.jsdelivr.net/npm/semver@6.3.1/+esm'

/*
 * Running Locally:
 *    Disable CORS in Chrome: Win + R -> chrome.exe --user-data-dir="C://chromeDev" --disable-web-security
 *    Open LandingPage/index.html in browser with CORS disabled
 *    Update apiUrlBaseForLocalTesting variable below if needed
 */

const versionRanges = [
  // Version ranges to probe. The range syntax is documented in: https://github.com/npm/node-semver?tab=readme-ov-file#ranges
  // Note that probing will continue until the end of the range even if a specific version failed to answer.
  '5.0 - 5.10',
  '6.0 - 6.10',
  '7.0 - 7.10'
];

const versionVariants = [
  // Variants to probe for each version
  {
    displayTemplate: 'Ed-Fi API v{{version}}',
    apiUrlTemplate: '{{baseUrl}}/v{{version}}/api/',
    docsUrlTemplate: '{{baseUrl}}/v{{version}}/docs/',
  },
  {
    displayTemplate: 'Ed-Fi API v{{version}} - Shared Instance',
    apiUrlTemplate: '{{baseUrl}}/SharedInstance_v{{version}}/api/',
    docsUrlTemplate: '{{baseUrl}}/SharedInstance_v{{version}}/docs/',
  },
  {
    displayTemplate: 'Ed-Fi API v{{version}} - Year Specific',
    apiUrlTemplate: '{{baseUrl}}/YearSpecific_v{{version}}/api/',
    docsUrlTemplate: '{{baseUrl}}/YearSpecific_v{{version}}/docs/',
  },
  {
    displayTemplate: 'Ed-Fi API v{{version}} - Multi-tenant',
    docsUrlTemplate: '{{baseUrl}}/Multitenant_v{{version}}/docs/',
    apiUrlTemplate: '{{baseUrl}}/Multitenant_v{{version}}/api/',
  }
];

const apiUrlBaseForLocalTesting = 'https://stage.api.ed-fi.org';

async function init() {

  const apiUrlBase =
    window.location.protocol === 'file:' ? apiUrlBaseForLocalTesting : `${window.location.protocol}//${window.location.host}`

  const versionsToProbe = [];
  for (let major = 0; major < 10; major++) {
    for (let minor = 0; minor < 10; minor++) {
      const version = semver.parse(`${major}.${minor}.0`);
      if (versionRanges.some(versionRange => semver.satisfies(version, versionRange))) {
        versionsToProbe.push(version);
      }
    }
  }

  // Ensure 7.3.1 is always included
  versionsToProbe.push(semver.parse('7.3.1'));

  const requests = versionsToProbe
    .reverse()
    .flatMap(version => versionVariants.map(variant => [version, variant]))
    .map(([version, variant]) => ([version, variant, buildApiProbeRequest(version, variant, apiUrlBase)]));

  const responses = await Promise.all(requests.map(([, , request]) => request));

  const succesfulResponses = requests
    .map(([version, variant,], i) => [version, variant, responses[i]])
    .filter(([, , response]) => response instanceof Response && response.status !== 404);

  createVersionRows(succesfulResponses.map(([version, variant,]) => [version, variant]), apiUrlBase);
  hideProgress();
  showVersionRows();
}

await init();

function interpolateTemplate(stringTemplate, version, baseUrl) {
  // If patch is 0, use major.minor, else use major.minor.patch
  const versionString = version.patch === 0
    ? `${version.major}.${version.minor}`
    : `${version.major}.${version.minor}.${version.patch}`;
  return stringTemplate
    .replace(/{{version}}/g, versionString)
    .replace(/{{baseUrl}}/g, baseUrl);
}

function buildApiProbeRequest(version, variant, apiUrlBase) {
  return fetch(interpolateTemplate(variant.apiUrlTemplate, version, apiUrlBase))
    // If there's an error (connection issue, time out, ...) return null instead of bubbling the exception up
    .catch(_ => null);
}

function hideProgress() {
  document.querySelector('#progress')?.classList.add('d-none');
}

function showVersionRows() {
  document.querySelector('#sections')?.classList.remove('d-none');
}

function createVersionRows(versions, baseUrl) {

  versions.forEach(([version, variant]) => {

    // @ts-ignore
    const versionRowHTML = document
      .querySelector('#versionTemplate')
      .innerHTML
      .replace(/{{apiVersion}}/g, interpolateTemplate(variant.displayTemplate, version, baseUrl));

    const versionRow = document.createElement('div');
    versionRow.innerHTML = versionRowHTML;
    versionRow.classList.add("version-row");

    const versionLinks = versionRow.querySelector('.versionLinks');

    // @ts-ignore
    versionLinks.innerHTML += document
      .querySelector('#apiLinkTemplate')
      .innerHTML
      .replace(/{{apiUrl}}/g, interpolateTemplate(variant.apiUrlTemplate, version, baseUrl));

    // @ts-ignore
    versionLinks.innerHTML += document
      .querySelector('#docsLinkTemplate')
      .innerHTML
      .replace(/{{docsUrl}}/g, interpolateTemplate(variant.docsUrlTemplate, version, baseUrl));

    // @ts-ignore
    document
      .querySelector(`#sections`)
      .querySelector('.card-body')
      .appendChild(versionRow);
  });

  if (versions.length === 0) {
    document.querySelector('#noApisMessage')?.classList.remove('d-none');
  }
}
