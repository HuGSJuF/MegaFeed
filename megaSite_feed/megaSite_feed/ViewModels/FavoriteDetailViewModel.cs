using megaSite_feed.Data;
using megaSite_feed.Models;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace megaSite_feed.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    class FavoriteDetailViewModel : BaseViewModel
    {
        public Command DeleteItemCommand { get; }
        public FavoriteDetailViewModel()
        {
            DeleteItemCommand = new Command(DeleteFavorite);
        }
        private ICommand _tapCommand;

        private int itemId;
        private string headline;
        private string kicker;
        private DateTime inserted;
        private DateTime modified;
        private string pic_src;
        private string pic_caption;
        private int pic_height;
        private int pic_width;
        private string url;


        public int Id { get; set; }

        public string Headline
        {
            get => headline;
            set => SetProperty(ref headline, value);
        }

        public string Kicker
        {
            get => kicker;
            set => SetProperty(ref kicker, value);
        }

        public DateTime Inserted
        {
            get => inserted;
            set => SetProperty(ref inserted, value);
        }

        public DateTime Modified
        {
            get => modified;
            set => SetProperty(ref modified, value);
        }

        public string Pic_src
        {
            get => pic_src;
            set => SetProperty(ref pic_src, value);
        }

        public string Pic_caption
        {
            get => pic_caption;
            set => SetProperty(ref pic_caption, value);
        }

        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }
        public int Pic_height
        {
            get => pic_height;
            set => SetProperty(ref pic_height, value);
        }
        public int Pic_width
        {
            get => pic_width;
            set => SetProperty(ref pic_width, value);
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; LoadItemId(value); }
        }

        [Obsolete]
        public ICommand TapCommand =>  _tapCommand ?? (_tapCommand = new Command<string>(OpenUrl));

        [Obsolete]
        void OpenUrl(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Headline = item.Headline;
                Kicker = item.Kicker;
                Inserted = item.Inserted;
                Modified = item.Modified;
                Pic_src = item.Pic_src;
                Pic_caption = item.Pic_caption;
                Pic_height = item.Pic_height;
                Pic_width = item.Pic_width;
                Url = item.Url;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ocorreu um erro ao carregar a notícia!");
            }
        }

        public async void DeleteFavorite(object obj)
        {
            News item = new News();
            item.Headline = Headline;
            item.Id = Id;
            item.Headline = Headline;
            item.Kicker = Kicker;
            item.Inserted = Inserted;
            item.Modified = Modified;
            item.Pic_src = Pic_src;
            item.Pic_caption = Pic_caption;
            item.Pic_height = Pic_height;
            item.Pic_width = Pic_width;
            item.Url = Url;

            Database database = new Database();
            var itemDataExist = database.getItem(item.Id);
            if (itemDataExist == null)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível excluir o item dos favoritos!", "OK");
                return;
            }
            database.DeleteItem(item);
            await Application.Current.MainPage.DisplayAlert("", "O item foi excluido dos seu favoritos!", "OK");
            await Shell.Current.GoToAsync("//FavoritesPage");

        }
    }
}
