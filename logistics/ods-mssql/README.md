# Instructions

These files are useful for starting a local MSSQL development environment.
The PowerShell scripts `start.ps` and `stop.ps` are for convenience, but are not
required.

You may optionally create a `.env` file in this directory to override the following values:

| Variable    | Default Value |
| ----------- | ------------- |
| MSSQL_PID   | Developer     |
| MSSQL_PORT  | 1433          |
| SA_PASSWORD | P@ssw0rd      |

After starting the container, you can run `initdev` with the following command:

```pwsh
initdev -MssqlSaPassword P@ssw0rd `
    -DbServerBackupDirectory /var/opt/mssql/data `
    -LocalDbBackupDirectory .\logistics\ods-mssql\data
```

> [!NOTE]
> You may see the following error messages; apparently these are irrelevant though, as the process completes, creating all expected databases.
>
> ```shell
> MethodInvocationException: Exception calling "ReadFileList" with "1" argument(s): "An exception occurred while executing a Transact-SQL statement
> or batch."
> MethodInvocationException: Exception calling "ReadBackupHeader" with "1" argument(s): "An exception occurred while executing a Transact-SQL
> statement or batch."
> MethodInvocationException: Exception calling "SqlRestore" with "1" argument(s): "Restore failed for Server 'YOUR_MACHINE_NAME'. "
> Setting db_owner: sa
> InvalidOperation: You cannot call a method on a null-valued expression.
> ```
