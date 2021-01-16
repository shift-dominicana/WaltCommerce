using Prism.Navigation;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ecommerce.Mobile.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        private readonly INavigationService _navigationService;
        private string _idPage;
        public MenuPage(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }


        protected override bool OnBackButtonPressed()
        {

            var navStack = Detail.Navigation.NavigationStack;
            var lastNavigated = navStack.Last();


            _idPage = Preferences.Get("menuPage", "default_value");
            if (_idPage.Equals("GatewayPageViewModel")
                || _idPage.Equals("DetailOpenRequestPageViewModel")
                || _idPage.Equals("ChatPageViewModel")
                || _idPage.Equals("OpenRequestPageViewModel"))
             
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (await DisplayAlert("Información", "¿Esta seguro que desea cerrar la sesión?", "Salir", "Cancelar"))
                    {
                        base.OnBackButtonPressed();

                        await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                    }
                });
            }
            else
            {
                return base.OnBackButtonPressed();
            }

            return true;
        }
    }
}