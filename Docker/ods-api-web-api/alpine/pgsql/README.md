# Ed-Fi Web ODS/API

Provides docker deployment for Ed-Fi ODS/API.

> [!NOTE]
> This image is suitable for production use.

## Image Variants

The only supported image at this time is an Alpine-based implementation.

`edfialliance/ods-api-web-api:<version>`

## Supported Environment Variables

```none
ODS_VIRTUAL_NAME=<The url path to the api, used to define the api's url> (OPTIONAL, default: api)
PATH_BASE=<Segment of the url to use as base for all request.> (OPTIONAL, default ${ODS_VIRTUAL_NAME})
TPDM_ENABLED=<true/false include TPDM tables> (OPTIONAL, default: true)
POSTGRES_DB=<default PostgreSQL database> (OPTIONAL, default: postgres)
POSTGRES_USER=<default PostgreSQL database user>
POSTGRES_PASSWORD=<password for default PostgreSQL user>
POSTGRES_PORT=<port that PostgreSQL run on> (OPTIONAL, default: 5432)
ADMIN_POSTGRES_HOST=<container-resolved name of the PostgreSQL instance containing the Admin and Security databases>
ODS_POSTGRES_HOST=<container-resolved name of the PostgreSQL instance containing the ODS database>
ODS_WAIT_POSTGRES_HOSTS=<space-separated list of PostgreSQL hosts that should be reachable before starting the api (used by multi-server)> (OPTIONAL)
ODS_CONNECTION_STRING_ENCRYPTION_KEY=<base64-encoded 256-bit key>
NPG_POOLING_ENABLED=<Enables or disables client-side pooling> (OPTIONAL, default: false)
NPG_API_MAX_POOL_SIZE_ADMIN=<The maximum number of connections for the EdFi_Admin database from each Ed-Fi ODS API container.> (REQUIRED if NPG_POOLING_ENABLED is set to true)
NPG_API_MAX_POOL_SIZE_SECURITY=<The maximum number of connections for the EdFi_Security database from each Ed-Fi ODS API container.> (REQUIRED if NPG_POOLING_ENABLED is set to true)
NPG_API_MAX_POOL_SIZE_MASTER=<The maximum number of connections for the 'postgres' default database from each Ed-Fi ODS API container.> (REQUIRED if NPG_POOLING_ENABLED is set to true)
```

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
