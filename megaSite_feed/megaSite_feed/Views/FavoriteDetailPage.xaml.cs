using megaSite_feed.ViewModels;
using Xamarin.Forms;

namespace megaSite_feed.Views
{
    public partial class FavoriteDetailPage : ContentPage
    {
        public FavoriteDetailPage()
        {
            InitializeComponent();
            BindingContext = new FavoriteDetailViewModel();
        }
    }
}