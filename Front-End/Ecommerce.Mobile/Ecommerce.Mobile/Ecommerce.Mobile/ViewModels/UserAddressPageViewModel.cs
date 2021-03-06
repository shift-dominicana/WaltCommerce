using Common.Models.Token;
using Common.Models.Users;
using Common.Models.UsersAddresses;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Models;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Ecommerce.Mobile.Helpers;



namespace Ecommerce.Mobile.ViewModels
{
    public class UserAddressPageViewModel : ViewModelBase
    {
        private DelegateCommand _saveCommand;
        private string _addressName;
        private string _province;
        private string _city;
        private string _sector;
        private string _street;
        private string _houseNumber;
        private string _reference;
        private string _telephone;
        private bool _isRunning;
        private bool _isEnabled;
        private UserAddress _address;
        private INavigationService _navigationService;
        private IApiServices _apiServices;
        private AccessToken _accessToken;
        private User _user;

        public UserAddressPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            _isEnabled = true;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveLocation));

        private async void SaveLocation()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                return;
            }

            var valid = await ValidaDatos();
            if (!valid) return;

            IsRunning = true;
            IsEnabled = false;

            Address.Name = AddressName;
            Address.Province = Province;
            Address.City = City;
            Address.Sector = Sector;
            Address.Street = Street;
            Address.HouseNumber = HouseNumber;
            Address.Reference = Reference;
            Address.Telephone = Telephone;
            Address.User = User;

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Address.Latitude = location.Latitude;
                    Address.Longitude = location.Longitude;
                    Debug.WriteLine($"{Address.Latitude} , {Address.Longitude}");
                }
                else
                {
                    Debug.WriteLine($"No GPS");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine($"Something is Wrong: {fnsEx.Message}");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Debug.WriteLine($"Something is Wrong: {fneEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine($"Something is Wrong: {pEx.Message}");
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine($"Something is Wrong: {ex.Message}");
            }

            var url = App.Current.Resources["UrlAPI"].ToString();
            Response<object> response = null;

            if (Address.Id == 0)
            {
                response = await _apiServices.PostAsync<UserAddress>(url, "/api", "/UserAddress", Address, "", "");
            }
            else
            {
                response = await _apiServices.PutAsync<UserAddress>(url, "/api", "/UserAddress", Address, "", "");
            }

            if (!response.IsSuccess)
            {

                IsRunning = false;
                IsEnabled = true;
                if (response.Message == "")
                {
                    response.Message = Messages.ConnectionError;
                }
                await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.UserCreated, Messages.Accept);
            await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");

        }

        public async Task<bool> ValidaDatos()
        {
            if (string.IsNullOrEmpty(AddressName)
                || string.IsNullOrEmpty(Province)
                || string.IsNullOrEmpty(City)
                || string.IsNullOrEmpty(Sector)
                || string.IsNullOrEmpty(Street)
                || string.IsNullOrEmpty(HouseNumber)
                || string.IsNullOrEmpty(Reference)
                )
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustFillFields, Messages.Accept);
                return false;
            }

            return true;

        }

        public UserAddress Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public string AddressName
        {
            get => _addressName;
            set => SetProperty(ref _addressName, value);
        }

        public string Province
        {
            get => _province;
            set => SetProperty(ref _province, value);
        }

        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public string Sector
        {
            get => _sector;
            set => SetProperty(ref _sector, value);
        }

        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }

        public string HouseNumber
        {
            get => _houseNumber;
            set => SetProperty(ref _houseNumber, value);
        }

        public string Reference
        {
            get => _reference;
            set => SetProperty(ref _reference, value);
        }

        public string Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            Address = new UserAddress();

            var UserData = Preferences.Get(Settings.UserData, "");
            _accessToken = JsonConvert.DeserializeObject<AccessToken>(UserData);
            if (_accessToken is AccessToken)
            {
                User = _accessToken.User;
                base.OnNavigatedTo(parameters);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustLogIn, Messages.Accept);
                await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");
            }
        }
    }
}
