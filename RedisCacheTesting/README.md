# Ed-Fi Redis and Redis-Commander Docker Compose
Docker compose file that creates a Redis and Redis-Commander environments for testing Redis support

## Images

The compose file creates and runs the following images:
* redis (latest)
    * Port: 6379
    * Named: redis
* redis-commander (latest)
    * Port: 8081

## Configuration
The top level port mappings are in the docker-compose.yml.


## Running Docker-Compose
To bring up the environment:

`cd [repository root]\RedisCacheTesting`

`docker-compose up -d`

This command will install the images and run them in detached mode.

To bring the environment down:

`docker-compose down`

This will stop the services and remove them.

## Running the apps
Launch your local instance of redis-commander, by default at [http://localhost:8081](http://localhost:8081/), to view the current state of redis.

Configure local dev Ed-Fi API development environment to use redis for external caching.

In appsettings.json, update the caching section similar to the following:
```
"Caching": {
    "ExternalCacheProvider": "Redis",
    "Descriptors": {
        "UseExternalCache": true,
        "AbsoluteExpirationSeconds": 1800
    },
    "PersonUniqueIdToUsi": {
        "UseExternalCache": true,
        "AbsoluteExpirationSeconds": 0,
        "SlidingExpirationSeconds": 14400,
        "UseProgressiveLoading": false,
        "CacheSuppression": {
            "Student": false,
            "Staff": false,
            "Parent": false,
            "Contact": false
        }
    },
    "ApiClientDetails":{
        "UseExternalCache": true,
        "AbsoluteExpirationSeconds": 900
    },
    "Security": {
        "AbsoluteExpirationMinutes": 10
    },
    "Profiles": {
        "AbsoluteExpirationSeconds": 1800
    },
    "OdsInstances": {
        "AbsoluteExpirationSeconds": 300
    }
},
"Services": {
    "Redis": {
        "Configuration": "localhost"
    }
}
```