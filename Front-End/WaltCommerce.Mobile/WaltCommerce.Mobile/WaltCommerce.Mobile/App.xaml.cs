using WaltCommerce.Mobile.Services;
using WaltCommerce.Mobile.ViewModels;
using WaltCommerce.Mobile.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WaltCommerce.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<UserRegisterPage, UserRegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.Register<IApiServices, ApiServices>();
            containerRegistry.RegisterForNavigation<ProductPage, ProductPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<UserProfilePage, UserProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<UserAddressPage, UserAddressPageViewModel>();
            containerRegistry.RegisterForNavigation<AddressTabbedPage, AddressTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<AddressListPage, AddressListPageViewModel>();
            containerRegistry.RegisterForNavigation<UserAddressPage, UserAddressPageViewModel>();
            containerRegistry.RegisterForNavigation<CartDetailPage, CartDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentPage, PaymentPageViewModel>();
        }
    }
}
