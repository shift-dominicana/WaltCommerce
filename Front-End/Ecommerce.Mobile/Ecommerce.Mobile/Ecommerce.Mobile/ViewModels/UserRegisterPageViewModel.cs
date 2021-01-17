using Common.Models.Users;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Models;
using Ecommerce.Mobile.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class UserRegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private string _name;
        private string _password;
        private string _email;
        private string _lastName;
        private DelegateCommand _saveCommand;
        private bool _isRunning;
        private bool _isEnabled;
        private string _confirmPassword;
        private DateTime _birthDay;
        private string _telephone;

        public UserRegisterPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            _isEnabled = true;
            Title = "Add User";
    }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(RegisterUserPost));


        public string FirstName
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
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

        public DateTime BirthDay
        { 
            get =>_birthDay; 
            set =>SetProperty(ref _birthDay,value); 
        }

        public string Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        private async void RegisterUserPost()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Informacion", "No se pudo conectar a internet por favor intente más tarde.", "Aceptar");
                return;
            }

            var valid = await ValidaDatosAsync();
            if (!valid) return;
            var usuario = new User()
            {
                FirstName = FirstName,
                LastName =  LastName,
                Email =  Email,
                Password =  Password,
                Gender = Common.Enums.GenderEnum.male,
                Telephone = Telephone,
                Dob = BirthDay
                
            };

            IsRunning = true;
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();

            var response = await _apiServices.PostAsync<User>(url, "/api", "/User", usuario);
            if (!response.IsSuccess)
            {

                IsRunning = false;
                IsEnabled = true;
                if (response.Message == "")
                {
                    response.Message = "No se pudo conectar con el servidor por favor intente más tarde.";
                }                
                await App.Current.MainPage.DisplayAlert("Información", response.Message, "Aceptar");
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            await App.Current.MainPage.DisplayAlert("Información", "El usuario fue Creado con éxito", "Aceptar");            
            await _navigationService.NavigateAsync("LoginPage");
        }


        public async Task<bool> ValidaDatosAsync()
        {
            if (string.IsNullOrEmpty(FirstName)
                || string.IsNullOrEmpty(LastName)
                || string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Password)
                || string.IsNullOrEmpty(ConfirmPassword)
                || !DateValid.IsDate(BirthDay.ToString())
                || string.IsNullOrEmpty(Telephone)
                )
            {
                await App.Current.MainPage.DisplayAlert("Información", "Debe completar todos los campos para poder procesar la soliciúd.", "Aceptar");
                return false;
            }

            return true;

        }
    }
}

