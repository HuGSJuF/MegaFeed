using megaSite_feed.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace megaSite_feed.Services
{
    public class MockDataStore : IDataWeb<News>
    {
        readonly List<News> newsItems;
        private const string BaseUrl = "https://www.vagalume.com.br";
        private const string UrlNews = "/news/index.js";
        private readonly HttpClient _client = new HttpClient();

        public MockDataStore()
        {
            newsItems = new List<News>();

            string content = _client.GetStringAsync(BaseUrl + UrlNews).Result;
            NewsConvert posts = JsonConvert.DeserializeObject<NewsConvert>(content);
            List<NewConvert> itemsRest = posts.News;
            foreach (var item in itemsRest)
            {
                newsItems.Add(new News()
                {
                    Id = item.Id,
                    Headline = item.Headline,
                    Kicker = item.Kicker,
                    Inserted = item.Inserted,
                    Modified = item.Modified,
                    Pic_src = BaseUrl + item.Pic_src,
                    Pic_caption = item.Pic_caption,
                    Pic_height = item.Pic_height,
                    Pic_width = item.Pic_width,
                    Url = item.Url
                });
            }

        }

        public async Task<bool> AddItemAsync(News item)
        {
            newsItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(News item)
        {
            var oldItem = newsItems.Where((News arg) => arg.Id == item.Id).FirstOrDefault();
            newsItems.Remove(oldItem);
            newsItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = newsItems.Where((News arg) => arg.Id == id).FirstOrDefault();
            newsItems.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<News> GetItemAsync(int id)
        {
            return await Task.FromResult(newsItems.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<News>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(newsItems);
        }
    }
}