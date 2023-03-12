using megaSite_feed.Models;
using megaSite_feed.Services;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace megaSite_feed.Data
{
    class Database
    {
        private SQLiteConnection _connection;
        public Database()
        {
            var dep = DependencyService.Get<IDataStore>();
            string database = dep.GetArchiveData("database.sql");

            _connection = new SQLiteConnection(database);
            _connection.CreateTable<News>();
        }

        public void addNewItem(News News)
        {
            _connection.Insert(News);
        }

        public News getItem(int itemId)
        {
            return _connection.Table<News>().Where(i => i.Id == itemId).FirstOrDefault();
        }

        public List<News> getAllItem()
        {
            return _connection.Table<News>().ToList();
        }
        public void DeleteItem(News News)
        {
            _connection.Delete(News);
        }
    }
}
