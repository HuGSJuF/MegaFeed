using megaSite_feed.Models;
using megaSite_feed.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace megaSite_feed.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private News _selectedItem;
        private readonly HttpClient _client = new HttpClient();

        public ObservableCollection<News> NewsItems { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<News> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Notícias";
            NewsItems = new ObservableCollection<News>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<News>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                NewsItems.Clear();
                string content = _client.GetStringAsync(BaseUrl + UrlNews).Result;
                NewsConvert news = JsonConvert.DeserializeObject<NewsConvert>(content);
                List<NewConvert> items = news.News;
                foreach (var item in items)
                {
                    NewsItems.Add(new News()
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public News SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(News News)
        {
            if (News == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={News.Id}");
        }
    }
}