# Ed-Fi Web Sandbox Admin

Provides docker deployment for Sandbox Admin tool.

> [!NOTE]
> This image is not recommended for production use.

## Image Variants

The only supported image at this time is an Alpine-based implementation.

`edfialliance/ods-api-web-sandbox-admin:<version>-mssql`

## Supported Environment Variables

```none
PATH_BASE=<Segment of the url to use as base for all request.> (OPTIONAL, default admin)
OAUTH_URL=<The url path to the OAuth endpoint.> (OPTIONAL, default https://localhost/api/oauth/)
SQLSERVER_ODS_DATASOURCE=<DNS or IP Address of the SQL Server Instance, i.e. sql.somedns.org or 10.1.5.9,1433>
SQLSERVER_ADMIN_DATASOURCE=<DNS or IP Address of the SQL Server Instance that contains the Admin/Security/Master databases, i.e. sql.somedns.org or 10.1.5.9,1433>
SQLSERVER_ADMIN_USER=<SQL Username with access to SQL Server Ed-Fi Admin and Security databases, i.e. edfiadmin>
SQLSERVER_ADMIN_PASSWORD=<SQL Password for the SQLSERVER_USER with access to SQL Server Ed-Fi Admin and Security databases, i.e. password123!>
SQLSERVER_ODS_USER=<SQL Username with access to SQL Server Ed-Fi ODS databases, i.e. edfiadmin>
SQLSERVER_ODS_PASSWORD=<SQL Password for the SQLSERVER_USER with access to SQL Server Ed-Fi ODS databases, i.e. password123!>
SQLSERVER_USER=<SQL Username with access to SQL Server Ed-Fi databases. If present along with SQLSERVER_PASSWORD, will override SQLSERVER_ODS_USER and SQLSERVER_ADMIN_USER>
SQLSERVER_PASSWORD=<SQL Password for the SQLSERVER_USER with access to SQL Server Ed-Fi databases. If present along with SQLSERVER_USER, will override SQLSERVER_ODS_PASSWORD and SQLSERVER_ADMIN_PASSWORD>
ENCRYPT_CONNECTION=<true/false use encrypted connection>(OPTIONAL, default: false)
ADMIN_USER=<default admin user for sandbox admin>
ADMIN_PASSWORD=<default password for the sandbox admin user>
MINIMAL_KEY=<minimal template key>
MINIMAL_SECRET=<minimal template secret>
POPULATED_KEY=<populated template key>
POPULATED_SECRET=<populated template secret>
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
