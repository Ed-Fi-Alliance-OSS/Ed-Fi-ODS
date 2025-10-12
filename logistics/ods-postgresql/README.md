# Instructions

These files are useful for starting a local PostgreSQL development environment.
The PowerShell scripts `start.ps` and `stop.ps` are for convenience, but are not
required.

You may optionally create a `.env` file in this directory containing the port to which postgres should be mapped.

You can specify the following values in the `.env` file:

* `POSTGRES_PORT`

The default value in [docker-compose.yml](./docker-compose.yml) result in the following contents for the `.env` file:

```none
POSTGRES_PORT=5432
```

This will allow the container to work with the default connection strings used during `initdev -Engine PostgreSql`