# Ed-Fi ODS Database

Provides a Docker image of the Ed-Fi ODS database's "minimal template",
containing a small set of sample (fake) school and student data, running on
Microsoft SQL Server 2022.

SA user is disabled after initial setup.

> [!NOTE]
> By running this container on an Ubuntu 22.04 host (per the
> [published guidelines](https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/install/windows/support-policy-sql-server#guidelines)), 
> this image is suitable for production use (under the [Express License](#sql-server-2022-express-license-overview)). 

## Image Variants

The only supported image at this time is an Ubuntu-based implementation using
[Microsoft SQL Server 2022](https://mcr.microsoft.com/product/mssql/server/about).

`edfialliance/ods-api-db-ods-minimal:<version>-mssql`

## Supported Environment Variables

```none
MSSQL_PID=<Set the SQL Server edition or product key. Default: Express>
SQLSERVER_USER=<default SqlServer database user>
SQLSERVER_PASSWORD=<password for default SqlServer user. This value is also used for SA user.>
TPDM_ENABLED=<true/false include TPDM tables> (OPTIONAL, default: true)
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
