using Common.Models.Token;
using Common.Models.Users;
using Common.Models.UsersAddresses;
using Ecommerce.Mobile.Fonts;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class AddressListPageViewModel : ViewModelBase
    {
        private DelegateCommand _addressChangeCommand;
        private UserAddress _addressSelected;
        private INavigationService _navigationService;
        private IApiServices _apiServices;
        private User _user;
        private AccessToken _preferences;
        private DelegateCommand _newAddreesClicked;

        public AddressListPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            AddressesList = new ObservableCollection<UserAddress>();
        }

        public DelegateCommand AddressChangeCommand => _addressChangeCommand ?? (_addressChangeCommand = new DelegateCommand(AddressChanged));
        public DelegateCommand AddAddressCommand => _newAddreesClicked ?? (_newAddreesClicked = new DelegateCommand(GoToCreateAddress));

        private void NewAddress_Clicked()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<UserAddress> AddressesList { get; set; }

        public UserAddress AddressSelected
        {
            get => _addressSelected;
            set => SetProperty(ref _addressSelected, value);
        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public string PlusFont = IconFont.PlusCircle;

        public void AddressChanged()
        {
            if (AddressSelected == null) return;
            var parameters = new NavigationParameters();
            parameters.Add("SelectedAddress", _addressSelected);
            _navigationService.NavigateAsync("UserAddressPage", parameters);
        }

        private void GoToCreateAddress() {
            _navigationService.NavigateAsync("UserAddressPage");
        }

        private async void GetAddress()
        {
            AddressesList.Clear();
            var url = App.Current.Resources["UrlAPI"].ToString();
            //var Token = Preferences.Get(Settings.Token, "");
            var response = await _apiServices.GetListAsync<UserAddress>(url, "/api", $"/UserAddress/GetUserAddresses/{User.Id}", "", "");         
            if (!response.IsSuccess)
            {
                if (response.Message == "")
                {
                    response.Message = Messages.ConnectionError;
                }

                await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                return;
            }

            var Addresses = (List<UserAddress>)response.Result;
            Addresses.ForEach(x => AddressesList.Add(x));

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //null for select the same address multiple times
            AddressSelected = null;
            
            var UserData = Preferences.Get(Settings.UserData, "");
            _preferences= JsonConvert.DeserializeObject<AccessToken>(UserData);
            if (_preferences is AccessToken)
            {
                User = _preferences.User;
                base.OnNavigatedTo(parameters);
                GetAddress();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustLogIn, Messages.Accept);
                await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");
            }

        }
    }
}
