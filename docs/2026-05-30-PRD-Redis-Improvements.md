# PRD: Redis External Cache Performance and Resilience Improvements

- **Owner**: Stephen Fuqua
- **Tracking Issue**:
  [#1343](https://github.com/Ed-Fi-Alliance-OSS/Ed-Fi-ODS/issues/1343)
- **Target Release**: ODS/API v7.3.3
- **Last Updated**: 2026-06-07

## 1. Product Overview

The Ed-Fi ODS/API provides an optional external caching feature that offloads
descriptor, person identifier, and API client details caching to Redis. This
allows multi-server deployments to share cache state and reduces per-process
memory usage when serving many ODS contexts.

This PRD defines requirements for resolving critical performance and reliability
defects in the Redis caching implementation that cause unexpected timeouts and
degraded API response times — defeating the feature's purpose.

## 2. Strategic Alignment

- **User-reported defects**: Multiple deployments report Redis-related timeouts
  and poor performance when the feature is enabled.
- **Scalability enablement**: External caching is a prerequisite for
  cost-effective horizontal scaling of the API tier. If it doesn't work
  reliably, organizations cannot scale.
- **Operational cost**: Current failure modes require application restarts to
  recover, increasing support burden.
- **Platform trust**: A shipped feature that harms performance erodes confidence
  in the platform.

## 3. Target Users and Personas

### API Platform Administrator

- **Motivation:** Deploy a performant, horizontally-scaled Ed-Fi API with shared
  cache.
- **Pain point:** Enabling Redis caching causes timeouts instead of improving
  performance. No visibility into cache health. Recovery requires restarts.
- **Success criteria:** Redis caching delivers measurably lower latency than
  uncached operation under normal conditions, and degrades gracefully (not
  catastrophically) under Redis failure.

### API Consumer (Source System Integration Developer)

- **Motivation:** Reliable, fast API responses for large-scale data operations.
- **Pain point:** Intermittent 500 errors and slow responses when Redis is
  enabled on the target API.
- **Success criteria:** Consistent sub-second response times for typical paged
  requests.

## 4. Jobs to Be Done

| #   | When...                                              | I want to...                                                                      | So that...                                                          |
| --- | ---------------------------------------------------- | --------------------------------------------------------------------------------- | ------------------------------------------------------------------- |
| 1   | I enable Redis caching on a multi-server deployment  | have API response times improve (or at minimum not degrade)                       | I benefit from shared cache without sacrificing performance         |
| 2   | Redis experiences a transient outage or network blip | the API continues serving requests (uncached) without throwing errors             | my integrations are not disrupted by infrastructure issues          |
| 3   | I configure Redis for my environment                 | tune connection timeouts, retries, and failure thresholds                         | the cache adapts to my network characteristics and SLA requirements |
| 4   | the API cold-starts or the cache expires             | cache initialization proceeds without overwhelming Redis or the database          | other concurrent requests are not blocked or slowed                 |
| 5   | I operate the API in production                      | have visibility into cache health, circuit breaker state, and expiration behavior | I can proactively diagnose issues before users are impacted         |

## 5. Current State (Observed Defects)

The following defects were identified through code analysis (source: issue #343):

| ID  | Defect                                                                                                                             | Severity | Impact                                                               |
| --- | ---------------------------------------------------------------------------------------------------------------------------------- | -------- | -------------------------------------------------------------------- |
| D-1 | Descriptor cache uses synchronous `IDistributedCache.GetString()`, blocking threads. 3000+ blocking round-trips per paged request. | Critical | 1.5s+ latency per request; thread pool starvation under concurrency. |
| D-2 | No configurable Redis connection timeouts. Default 5s `syncTimeout` hit under load.                                                | Critical | Direct cause of reported `RedisTimeoutException`.                    |
| D-3 | Expiration (PEXPIRE) sent fire-and-forget; silent failures cause stale data or premature eviction.                                 | High     | Unbounded memory growth or thundering herd on re-initialization.     |
| D-4 | Background cache initialization has no concurrency control. Race conditions trigger duplicate full-table scans.                    | High     | Database and Redis contention during cold start.                     |
| D-5 | No connection resilience. Redis failure = every request throws until restart.                                                      | High     | Complete service disruption on transient Redis issues.               |
| D-6 | LINQ allocations on every cache read/write in hot path.                                                                            | Medium   | GC pressure, increased P99 latency.                                  |
| D-7 | No L1 cache tier; all-or-nothing architecture (memory vs. Redis).                                                                  | Medium   | Unnecessary Redis traffic for small, hot, rarely-changing data.      |

## 6. Functional Requirements

### FR-PERF: Descriptor Cache Performance

| ID        | Requirement                                                                                                                                    | Priority |
| --------- | ---------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-PERF-1 | The system SHALL provide an in-process (L1) cache tier in front of Redis for descriptor lookups with a configurable TTL (default: 10 seconds). | SHALL    |
| FR-PERF-2 | L1 cache lookups SHALL be synchronous in-memory operations with no network I/O.                                                                | SHALL    |
| FR-PERF-3 | On L1 cache miss, the system SHALL access Redis asynchronously (non-blocking).                                                                 | SHALL    |
| FR-PERF-4 | On L2 (Redis) hit, the system SHALL populate L1 before returning the result.                                                                   | SHALL    |
| FR-PERF-5 | The L1 cache TTL SHOULD be independently configurable per cache type (descriptors, API client details).                                        | SHOULD   |

### FR-CONN: Connection Configuration

| ID        | Requirement                                                                                                                                                                                           | Priority |
| --------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-CONN-1 | The system SHALL expose configurable Redis connection parameters: `SyncTimeoutMs`, `AsyncTimeoutMs`, `ConnectTimeoutMs`, `ConnectRetry`, `AbortOnConnectFail`, `KeepAliveSeconds`, `Ssl`, `Password`. | SHALL    |
| FR-CONN-2 | Default values SHALL be production-friendly: syncTimeout=10000ms, asyncTimeout=10000ms, connectTimeout=10000ms, connectRetry=5, abortOnConnectFail=false, keepAlive=30s.                              | SHALL    |
| FR-CONN-3 | Connection options SHALL be applied consistently to both the `IRedisConnectionProvider` and the `IDistributedCache` Redis registrations.                                                              | SHALL    |

### Redis Configuration Reference

`ApiSettings:Services:Redis` supports the following settings:

```json
"Redis": {
  "Configuration": "",
  "SyncTimeoutMs": 10000,
  "AsyncTimeoutMs": 10000,
  "ConnectTimeoutMs": 10000,
  "ConnectRetry": 5,
  "AbortOnConnectFail": false,
  "KeepAliveSeconds": 30,
  "Ssl": false,
  "Password": ""
}
```

### FR-RESIL: Connection Resilience

| ID         | Requirement                                                                                                                                     | Priority |
| ---------- | ----------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-RESIL-1 | The system SHALL implement a circuit breaker around Redis operations that opens after a configurable failure threshold.                         | SHALL    |
| FR-RESIL-2 | When the circuit breaker is open, Redis operations SHALL fail fast and the API SHALL degrade gracefully to uncached (database-direct) behavior. | SHALL    |
| FR-RESIL-3 | The system SHALL NOT require application restart to recover from transient Redis unavailability.                                                | SHALL    |
| FR-RESIL-4 | The system SHALL log connection state transitions (connected, failed, restored) at appropriate severity levels.                                 | SHALL    |
| FR-RESIL-5 | The system SHOULD log circuit breaker state transitions (closed → open → half-open → closed).                                                   | SHOULD   |

### FR-EXPIRE: Expiration Reliability

| ID          | Requirement                                                                                                                      | Priority |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-EXPIRE-1 | Cache expiration commands SHALL be pipelined with the associated data operation (not sent as separate fire-and-forget commands). | SHALL    |
| FR-EXPIRE-2 | Failed expiration commands SHALL be logged at Warning level for operator visibility.                                             | SHALL    |
| FR-EXPIRE-3 | The system SHALL NOT use `CommandFlags.FireAndForget` for expiration operations.                                                 | SHALL    |

### FR-INIT: Cache Initialization

| ID        | Requirement                                                                                                                                                         | Priority |
| --------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-INIT-1 | Background cache initialization SHALL be protected by a distributed lock so that only one instance initializes a given (ODS instance, person type) cache at a time. | SHALL    |
| FR-INIT-2 | The initialization marker check-and-set SHALL be atomic (Redis SET NX).                                                                                             | SHALL    |
| FR-INIT-3 | Bulk cache writes during initialization SHALL use batches no larger than 10,000 entries to avoid blocking the Redis event loop.                                     | SHALL    |
| FR-INIT-4 | Background initialization SHALL support cancellation (application shutdown) and a maximum timeout (default: 60 seconds).                                            | SHALL    |
| FR-INIT-5 | Bulk cache write size SHALL be configurable | SHALL |

### FR-ALLOC: Hot-Path Efficiency

| ID         | Requirement                                                                                                          | Priority |
| ---------- | -------------------------------------------------------------------------------------------------------------------- | -------- |
| FR-ALLOC-1 | Cache read and write operations SHALL NOT allocate intermediate LINQ iterators or delegate closures in the hot path. | SHALL    |
| FR-ALLOC-2 | Type conversion from/to `RedisValue` SHOULD use direct typed overrides rather than runtime type-switching.           | SHOULD   |
| FR-ALLOC-3 | Batch slicing SHALL NOT use LINQ `Skip`/`Take`; fixed-size array copy or span slicing SHALL be used instead.         | SHALL    |

## 7. Non-Functional Requirements

### NFR-PERF: Performance

| ID         | Requirement                                                                                                                                                                                    |
| ---------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NFR-PERF-1 | A paged GET request for 500 studentSchoolAssociations with Redis caching enabled SHALL NOT add more than 50ms of cache-related latency (excluding cold start) under normal Redis connectivity. |
| NFR-PERF-2 | L1 cache hit ratio for descriptors SHOULD exceed 99% under steady-state operation.                                                                                                             |
| NFR-PERF-3 | P99 response time with Redis enabled SHALL be within 2× of the in-memory-only cache P99 under equivalent load.                                                                                 |

### NFR-RELI: Reliability

| ID         | Requirement                                                                                                            |
| ---------- | ---------------------------------------------------------------------------------------------------------------------- |
| NFR-RELI-1 | The API SHALL remain available (HTTP 200 responses) during Redis outages lasting up to 5 minutes.                      |
| NFR-RELI-2 | After Redis recovery, the system SHALL resume caching within 60 seconds without operator intervention.                 |
| NFR-RELI-3 | Cache key expiration SHALL be reliable — keys SHALL NOT persist beyond 2× their configured TTL under normal operation. |

### NFR-OBS: Observability

| ID        | Requirement                                                                                |
| --------- | ------------------------------------------------------------------------------------------ |
| NFR-OBS-1 | Redis connection state changes SHALL be logged (Error for failures, Info for restoration). |
| NFR-OBS-2 | Circuit breaker transitions SHALL be logged (Error for open, Info for close).              |
| NFR-OBS-3 | Expiration failures SHALL be logged at Warning level with the affected cache key.          |

### NFR-COMPAT: Compatibility

| ID           | Requirement                                                                                                              |
| ------------ | ------------------------------------------------------------------------------------------------------------------------ |
| NFR-COMPAT-1 | All changes SHALL be backward compatible — deployments with external cache disabled SHALL experience no behavior change. |
| NFR-COMPAT-2 | Existing `appsettings.json` configurations without new Redis fields SHALL work with production-friendly defaults.        |
| NFR-COMPAT-3 | The solution SHALL support Redis 6.x and 7.x.                                                                            |

### NFR-SEC: Security

| ID        | Requirement                                                        |
| --------- | ------------------------------------------------------------------ |
| NFR-SEC-1 | Redis password SHALL NOT be logged in plain text at any log level. |
| NFR-SEC-2 | SSL/TLS connections to Redis SHALL be configurable.                |

## 8. System Architecture

### Component Overview

| Component                    | Responsibility                                        | Runtime            |
| ---------------------------- | ----------------------------------------------------- | ------------------ |
| `TieredCacheProvider`        | L1 (MemoryCache) + L2 (Redis) composition             | In-process         |
| `AsyncExternalCacheProvider` | Async Redis access via IDistributedCache              | In-process → Redis |
| `AsyncCachingInterceptor`    | DynamicProxy interceptor with sync L1 path + async L2 | In-process         |
| `RedisCacheResilience`       | Polly circuit breaker wrapping Redis operations       | In-process         |
| `RedisConnectionProvider`    | Managed ConnectionMultiplexer with event handling     | In-process → Redis |
| `RedisMapCache`              | Person cache HASH operations with IBatch pipelining   | In-process → Redis |

### Data Flow (Cache Hit)

```
Request → CachingInterceptor
  → L1 MemoryCache check (sync, ~0.001ms)
    → HIT: return immediately
    → MISS: AsyncExternalCacheProvider.GetStringAsync (Redis, ~0.5ms)
      → Circuit open? → return default (degrade to DB)
      → HIT: populate L1, return
      → MISS: invoke underlying provider, cache in L1+L2, return
```

### Dependencies

| Dependency                          | Version    | Purpose                    |
| ----------------------------------- | ---------- | -------------------------- |
| StackExchange.Redis                 | (existing) | Redis client               |
| Polly                               | 8.5.x      | Circuit breaker resilience |
| Microsoft.Extensions.Caching.Memory | (existing) | L1 in-process cache        |
| Castle.Core                         | (existing) | DynamicProxy interception  |

## 9. Out of Scope

| Item                                                 | Rationale                                                                 |
| ---------------------------------------------------- | ------------------------------------------------------------------------- |
| Redis Cluster/Sentinel replica-aware routing         | Future optimization; current fix focuses on correctness and resilience.   |
| Cache value compression                              | Modest benefit for the data sizes involved; can be added later.           |
| Distributed cache invalidation (pub/sub)             | L1 TTL-based expiration is sufficient for descriptor staleness tolerance. |
| Metrics/telemetry export (Prometheus, OpenTelemetry) | Desirable but separate effort; logging provides interim visibility.       |
| Migration to `IDistributedCache` for person caches   | Person caches use `IMapCache` (Redis HASH); different abstraction.        |
| Load testing / benchmarking harness                  | Separate effort; this PRD defines expected characteristics.               |

## 10. Glossary

| Term                | Definition                                                                               |
| ------------------- | ---------------------------------------------------------------------------------------- |
| **L1 cache**        | Short-lived in-process `IMemoryCache` acting as first-tier cache.                        |
| **L2 cache**        | Redis distributed cache acting as second-tier shared cache.                              |
| **Circuit breaker** | Resilience pattern that stops calling a failing service after threshold breaches.        |
| **Descriptor**      | A reference data value (e.g., grade level, subject) mapped from URI to ODS-specific ID.  |
| **USI**             | Unique Student Identifier — the ODS surrogate key for a person.                          |
| **UniqueId**        | The cross-system stable identifier for a person (e.g., state student ID).                |
| **Map cache**       | A Redis HASH used to store key→value mappings for person identifier resolution.          |
| **Fire-and-forget** | A Redis command flag that sends a command without waiting for or checking the response.  |
| **IBatch**          | StackExchange.Redis API for pipelining multiple commands in a single network round-trip. |

## 11. Release Criteria

- [ ] All SHALL requirements implemented and passing unit tests.
- [ ] Build succeeds with zero errors and zero new warnings.
- [ ] Existing unit tests continue to pass (no regressions).
- [ ] Manual smoke test: API serves requests during simulated Redis outage
  (docker stop redis).
- [ ] Manual smoke test: API resumes caching after Redis recovery without
  restart.
- [ ] Configuration documentation updated in Implementation repository.
