namespace Watermark.Repository.DatabaseInitalization
{
    public interface IDatabaseInitalizationFactory
    {
        void CreateDatabase(string server, string databaseName, bool trustedConnection = true, bool multipleActiveResultSets = true);
    }
}