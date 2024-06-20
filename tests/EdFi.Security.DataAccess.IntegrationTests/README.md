This project contains some lightweight integration tests suitable for use with
both SQL Server and PostgreSQL. These are quick-and-dirty, and not ready for
CI process automation.

* You must have run `initdev` and `initdev -engine PostgreSQL` locally to
  setup the databases for success.
* Run the PostgreSQL integration tests before the SQL Server integration tests,
  otherwise you'll get an exception when trying to access Entity Framework.
