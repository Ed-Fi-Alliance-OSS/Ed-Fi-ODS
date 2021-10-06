namespace Test.Common
{
    public interface IDatabaseHelper
    {
        public void CopyDatabase(string originalDatabaseName, string newDatabaseName);
        public void DropMatchingDatabases(string databaseNamePattern);
    }
}
