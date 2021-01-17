using Common.Models.Users;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Models;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private DelegateCommand _userRegisterCommand;
        private DelegateCommand _loginCommand;
        private string _email;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;

        public LoginPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            _isEnabled = true;
        }

        public DelegateCommand UserRegisterCommand => _userRegisterCommand ?? (_userRegisterCommand = new DelegateCommand(RegisterUser));
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(LoginAction));


        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
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

        private async void RegisterUser()
        {
            await _navigationService.NavigateAsync("UserRegisterPage");
        }

        private async void LoginAction()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Informacion", "No se pudo conectar a internet por favor intente más tarde.", "Aceptar");
                return;
            }

            var valid = await ValidateFormAsync();
            if (!valid) return;


            IsRunning = true;
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiServices.GetGenericAsync<User>(url, "/api", "/User/Authenticate/",$"{Email}/{Password}");

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {

                if (response.Message == "")
                {
                    response.Message = "No se pudo conectar con el servidor por favor intente más tarde.";
                }

                await App.Current.MainPage.DisplayAlert("Información", response.Message, "Aceptar");
                return;
            }

            var user = (User)response.Result;
            Preferences.Set("nombreCompleto", $"{user.FirstName} {user.LastName}");
                       
            await _navigationService.NavigateAsync("/MenuPage/NavigationPage/UserRegisterPage");
        }

        public async Task<bool> ValidateFormAsync()
        {
            if (string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Password)
               )
            {
                await App.Current.MainPage.DisplayAlert("Información", "Debe completar todos los campos para poder procesar la soliciúd.", "Aceptar");
                return false;
            }

            return true;

        }
    }
}
