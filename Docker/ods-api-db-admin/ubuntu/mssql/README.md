# Ed-Fi Admin Databases

Provides docker deployment for **_EdFi_Admin_** and **_EdFi_Security_** database
implementations on Microsoft SQL Server 2022. The databases are installed when the image is
started for the first time.

SA user is disabled after initial setup.

> [!NOTE]
> This image does not include any pre-installed vendors and running as a container on an Ubuntu 22.04 host (as per the
> [published guidelines](https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/install/windows/support-policy-sql-server#guidelines)), 
> is suitable for production use (under the [Express License](#sql-server-2022-express-license-overview)).

## Image Variants

The only supported image at this time is an Ubuntu-based implementation using
[Microsoft SQL Server 2022](https://mcr.microsoft.com/product/mssql/server/about).

`edfialliance/ods-api-db-admin:<version>-mssql`

## Supported Environment Variables

```none
MSSQL_PID=<Set the SQL Server edition or product key. Default: Express>
SQLSERVER_USER=<default SqlServer database user>
SQLSERVER_PASSWORD=<password for default SqlServer user. This value is also used for SA user.>
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

### SQL Server 2022 Express License Overview

[SQL Server 2022 Express license](https://www.microsoft.com/en-us/Useterms/Retail/SQLServer2022/SQLServer2022DeveloperExpressEvaluation/Useterms_Retail_SQLServer2022_SQLServer2022DeveloperExpressEvaluation_English.htm) is suitable for production use in certain scenarios,
particularly for small-scale applications with limited resource needs.

Limitations in Production are
- Maximum database size is 10 GB per database
- Supports 1 socket or 4 cores, and a maximum of 1410 MB of memory per instance.
- Lacks some advanced features available in paid editions, such as SQL Server Agent
for job scheduling, integration services, and advanced analytics.

If you need to use/have aquired a different license, you can specify the 
SQL Server edition or product key using the `MSSQL_PID` environment variable.
Valid values are:

- Express
- Web
- Standard
- Enterprise
- EnterpriseCore
- A product key

If specifying a product key, it must be in the form of #####-#####-#####-#####-#####,
where '#' is a number or a letter.
