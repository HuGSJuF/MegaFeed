using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace megaSite_feed.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Sobre Nós";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://megasite.net.br"));
        }

        public ICommand OpenWebCommand { get; }
    }
}