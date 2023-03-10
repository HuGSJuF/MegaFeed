using megaSite_feed.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace megaSite_feed.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}