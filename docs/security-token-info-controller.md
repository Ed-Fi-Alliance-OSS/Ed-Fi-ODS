# Security Analysis: TokenInfoController

**File:** `Application/EdFi.Ods.Features/Controllers/TokenInfoController.cs`
**Date:** 2026-03-26
**Branch reviewed:** `origin/main` (commit `39cd8d17b`)

---

## Finding 1 — Token Enumeration via Differential Responses (Medium)

**Lines:** 105–118 (pre-fix)

In GUID mode, an authenticated caller could probe whether any arbitrary GUID token
belongs to another client by observing the response code:

- `404 Not Found` → token does not exist in the database
- `401 Unauthorized` → token exists but is owned by a different API client

This differential allows enumeration of valid access tokens belonging to other vendors.
A timing side-channel reinforces it: the DB lookup occurs before the ownership check,
so `401` responses are measurably slower than `404` responses.

**Fix:** Return `404` for both cases — whether the token doesn't exist or belongs to
another client — so the caller learns nothing about tokens it doesn't own.

---

## Finding 2 — Submitted Token Ignored in JWT Mode (Low–Medium)

**Lines:** 80–103 (pre-fix)

When `AccessTokenType` is `jwt`, the token value in `tokenInfoRequest.Token` was only
checked for nullness. Any non-null string passed as the `token` parameter was silently
accepted, and the introspection then operated on the JTI extracted from the caller's
own authenticated JWT (the `Authorization: Bearer` header) rather than from the
submitted token.

This violates [RFC 7662 §2](https://tools.ietf.org/html/rfc7662#section-2), which
defines `token` as the specific token to be introspected. A caller submitting
`token=garbage` in JWT mode would receive their own token's metadata back without
any error, which is misleading and could mask integration bugs or misuse.

**Fix:** In JWT mode, compare `tokenInfoRequest.Token` against the raw Bearer token
from the `Authorization` header. Return `400 Bad Request` if they do not match.

---

## Finding 3 — Error Messages Leak Token Mode Configuration (Low)

**Lines:** 84–91 and 96–103 (pre-fix)

The two `BadRequest` branches returned different error detail strings:

| Branch | Message |
|--------|---------|
| GUID parse failure | `"The token was not present, or was not processable as a GUID value."` |
| JWT JTI parse failure | `"The token was not present, or was not processable."` |

The phrase "as a GUID value" reveals that the backend is operating in GUID token mode,
leaking internal configuration to any caller who can trigger the error path.

**Fix:** Use the same message text for both branches.

---

## Summary

| # | Severity | Status |
|---|----------|--------|
| 1 | Medium | Fixed — `401` collapsed to `404` for unknown/foreign tokens |
| 2 | Low–Medium | Fixed — submitted token validated against `Authorization` header in JWT mode |
| 3 | Low | Fixed — error messages normalized to identical text |
| 4 (CSRF) | Low | Not fixed — no cookie auth in use; tracked for awareness only |
