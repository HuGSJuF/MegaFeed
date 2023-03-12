using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using megaSite_feed.Data;
using megaSite_feed.Models;
using megaSite_feed.Views;

namespace megaSite_feed.ViewModels
{
    class FavoritesViewModel : BaseViewModel
    {
        private News _selectedItem;
        public ObservableCollection<News> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<News> ItemTapped { get; }

        public FavoritesViewModel()
        {
            Title = "Meus Favoritos";
            Items = new ObservableCollection<News>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<News>(OnItemSelected);
        }
        async Task ExecuteLoadItemsCommand()
        {
            Database database = new Database();
            IsBusy = true;

            try
            {
                if (Items != null) { Items.Clear(); }
                var items = database.getAllItem();
                if (items.Count > 0 )
                {
                    foreach (var item in items)
                    {
                        Items.Add(new News()
                        {
                            Id = item.Id,
                            Headline = item.Headline,
                            Kicker = item.Kicker,
                            Inserted = item.Inserted,
                            Modified = item.Modified,
                            Pic_src = item.Pic_src,
                            Pic_caption = item.Pic_caption,
                            Pic_height = item.Pic_height,
                            Pic_width = item.Pic_width,
                            Url = item.Url
                        });
                    }
                }
                else
                {
                    Items.Add(new News()
                    {
                        Id = 0,
                        Headline = "Ops!",
                        Kicker = "Você ainda não possui notícias salvas nos favoritos",
                        Inserted = DateTime.Now,
                        Pic_height = 140,
                        Pic_width = 190,
                        Pic_src = "not_found.png",
                    }) ;
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
        async void OnItemSelected(News item)
        {
            if (item == null) { return; }
            else if (item != null && item.Id == 0) { await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}"); }
            else if (item != null && item.Id > 0) { await Shell.Current.GoToAsync($"{nameof(FavoriteDetailPage)}?{nameof(FavoriteDetailViewModel.ItemId)}={item.Id}"); }         
            
        }
    }
}