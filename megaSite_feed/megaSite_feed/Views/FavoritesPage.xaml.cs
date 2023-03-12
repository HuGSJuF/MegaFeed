using megaSite_feed.ViewModels;
using Xamarin.Forms;

namespace megaSite_feed.Views
{
    public partial class FavoritesPage : ContentPage
    {
        FavoritesViewModel _favoritesViewModel;

        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = _favoritesViewModel = new FavoritesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _favoritesViewModel.OnAppearing();
        }
    }
}