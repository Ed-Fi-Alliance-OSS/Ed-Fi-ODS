# Ed-Fi BulkLoadClient Console

Provides a docker image with BulkLoadClient Console installed as a tool.

> [!NOTE]
> This image is recommended for production use.

## Image Variants

The only supported image at this time is an Alpine-based implementation.

`edfialliance/ods-api-bulk-load-console:<version>`

## Supported Environment Variables

```none
ENV_CONSOLE_LOG_LEVEL=<log level for console logs. default: INFO>
ENV_FILE_LOG_LEVEL=<log level for file logs. default: DEBUG>
```

## BulkLoadClient Command Line Parameter Definitions

 | Option       | Long Option         | Description                                                                                               |
 |:------------:|---------------------|-----------------------------------------------------------------------------------------------------------|
 | -b           | `--baseurl`         | The base url used to derived api, metadata, oauth, and dependency urls (e.g., http://server)              |
 | -c           | `--connectionlimit` | Maximum concurrent connections to api                                                                     |
 | -d           | `--data`            | Path to folder containing the data files to be submitted. (This will always point to /var/bulkLoad/data inside the container; a mount bind to this folder is required)                                                  |
 | -e           | `--extension`       | The extension name to download Xsd Schema files for                                                       |
 | -f           | `--force`           | (Default: false) Force reload of metadata from metadata url                                               |
 | -k           | `--key`             | The web API OAuth key                                                                                     |
 | -l           | `--maxRequests`     | Max number of simultaneous API requests                                                                   |
 | -n           | `--novalidation`    | (Default: false) Do not validate the XML document against the XSD before processing                       |
 | -p           | `--profile`         | The name of an API profile to use (optional)                                                              |
 | -r           | `--retries`         | The number of times to retry submitting a resource                                                        |
 | -s           | `--secret`          | The web API OAuth secret                                                                                  |
 | -t           | `--taskcapacity`    | Maximum concurrent tasks to be buffered                                                                   |
 | -w           | `--working`         | Path to a writable folder containing the working files, such as the swagger metadata cache and hash cache. (This will always point to /var/bulkLoad/working inside the container; a mount bind to this folder is optional) |
 | -z           | `--xsdmetadataurl`  | The XSD metadata url (i.e. http://server/metadata)                                                        |
 |              | `--help`            | Display this list of options.                                                                             |
 |              | `--include-stats`   | Include timing stats.                                                                                     |
 |              | `--version`         | Display version information.                                                                              |

## Legal Information

Copyright (c) 2024 Ed-Fi Alliance, LLC and contributors.

Licensed under the [Apache License, Version
2.0]([LICENSE](https://www.apache.org/licenses/LICENSE-2.0.txt)) (the
"License").

Unless required by applicable law or agreed to in writing, software distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
CONDITIONS OF ANY KIND, either express or implied. See the License for the
specific language governing permissions and limitations under the License.

### Notice about Docker base images

As with all Docker images, these likely also contain other software which may be
under other licenses (such as Bash, etc. from the base distribution, along with
any direct or indirect dependencies of the primary software being contained).

As for any pre-built image usage, it is the image user's responsibility to
ensure that any use of this image complies with any relevant licenses for all
software contained within.