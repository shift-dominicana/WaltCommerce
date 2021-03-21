using Ecommerce.Mobile.Helpers;
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


            _idPage = Preferences.Get(Settings.ActualPage, "");
            if (_idPage.Equals("UserProfilePage")
                || _idPage.Equals("AddressListPage")
                || _idPage.Equals("OrdersPage"))
             
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    base.OnBackButtonPressed();
                    await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");   
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