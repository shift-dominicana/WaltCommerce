using Common.Models.Users;
using Ecommerce.Mobile.Fonts;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;
        private Menu _menu;
        private string _fullname;
        private User _user;
        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            _fullname = Preferences.Get(Settings.FullName,"");
            LoadMenus();
        }
        

        public List<Menu> Menus { get; set; }
        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));


        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value);
        }

        public Menu Menu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
        }
        

        private void LoadMenus()
        {
            Menus = new List<Menu>
            {
                new Menu
                {
                    Icon = IconFont.DoorOpen,
                    Page = "UserProfilePage",
                    Title = Messages.MenuOptProfile
                },
                new Menu
                {
                    Icon = IconFont.EnvelopeOpenText,
                    Page = "AddressListPage",
                    Title = Messages.MenuOptAddresses
                },
                new Menu
                {
                    Icon = IconFont.InfoCircle,
                    Page = "OrdersPage",
                    Title = Messages.MenuOptOrders
                },
                new Menu
                {
                    Icon = IconFont.Mobile,
                    Page = "ProductPage",
                    Title = Messages.MenuOptProducts
                },
                new Menu
                {
                    Icon = IconFont.SignOutAlt,
                    Page = "LoginPage",
                    Title = Messages.MenuOptLogOut
                }
            };

        }

        private async void SelectMenu()
        {
            if (Menu.Page.Equals("LoginPage"))
            {
                var confirm = await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.AskLogOut, Messages.Accept, Messages.Cancel);
                if (confirm)
                {
                    await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                }

                return;
            }

            Preferences.Set(Settings.ActualPage, Menu.Page);
            var parameter = new NavigationParameters();
            await _navigationService.NavigateAsync($"/MenuPage/NavigationPage/{Menu.Page}", parameter);

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            User = (User)parameters["User"];
            base.OnNavigatedTo(parameters);
        }
     
    }
}