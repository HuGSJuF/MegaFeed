using megaSite_feed.Droid.Database;
using Xamarin.Forms;
using megaSite_feed.Services;
using System.IO;

[assembly: Dependency(typeof(DatabaseDroidService))]
namespace megaSite_feed.Droid.Database
{
    class DatabaseDroidService : IDataStore
    {
        public string GetArchiveData(string DataName)
        {
            string dataBasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string databaseFile = Path.Combine(dataBasePath, DataName);
            return databaseFile;
        }
    }
}