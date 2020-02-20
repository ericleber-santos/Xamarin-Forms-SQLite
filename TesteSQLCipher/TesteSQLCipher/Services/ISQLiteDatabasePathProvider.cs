using SQLite;

namespace TesteSQLCipher.Services
{
    public interface ISQLiteDatabasePathProvider
    {
        string GetDBPath();       
    }
}
