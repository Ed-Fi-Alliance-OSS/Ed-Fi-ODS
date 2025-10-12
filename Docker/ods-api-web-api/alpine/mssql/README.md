# Ed-Fi Web ODS/API

Provides docker deployment for Ed-Fi ODS/API.

> [!NOTE]
> This image is suitable for production use.

## Image Variants

The only supported image at this time is an Alpine-based implementation.

`edfialliance/ods-api-web-api:<version>-mssql`

## Supported Environment Variables

```none
PATH_BASE=<Segment of the url to use as base for all request.> (OPTIONAL, default api)
SQLSERVER_ADMIN_DATASOURCE=<DNS or IP Address of the SQL Server Instance that contains the Admin/Security/Master databases, can also be a docker container, i.e. sql.somedns.org, ed-fi-db-admin, or 10.1.5.9,1433>
SQLSERVER_USER=<SQL Username with access to SQL Server Ed-Fi Admin and Security databases.>
SQLSERVER_PASSWORD=<SQL Password for the SQLSERVER_USER with access to SQL Server Ed-Fi Admin and Security databases.>
TPDM_ENABLED=<true/false load TPDM extension> (OPTIONAL, default: true)
ENCRYPT_CONNECTION=<true/false use encrypted connection>(OPTIONAL, default: false)
ODS_CONNECTION_STRING_ENCRYPTION_KEY=<base64-encoded 256-bit key>
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
