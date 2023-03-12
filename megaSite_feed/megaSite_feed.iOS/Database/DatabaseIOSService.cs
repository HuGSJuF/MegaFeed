using megaSite_feed.iOS.Database;
using megaSite_feed.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseIOSService))]

namespace megaSite_feed.iOS.Database
{
    class DatabaseIOSService : IDataStore
    {
        public string GetArchiveData(string DataName)
        {
            string dataBasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libraryIOS = Path.Combine(dataBasePath, "..", "Library");
            string databaseFile = Path.Combine(libraryIOS, DataName);
            return databaseFile;
        }
    }
}