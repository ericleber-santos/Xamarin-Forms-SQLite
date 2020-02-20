using System;
using System.IO;
using TesteSQLCipher.Droid;
using TesteSQLCipher.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace TesteSQLCipher.Droid
{
    public class SQLiteAndroid : ISQLiteDatabasePathProvider
    {  
        public string GetDBPath()
        {  
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testecipher.db3"); 
        }
    }
}