using Common.Helpers;
using Common.Models.Token;
using Common.Models.UserRequest;
using Common.Models.Users;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
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
            Title = Messages.TtRegisUser;
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
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                return;
            }

            var valid = await ValidateFormAsync();
            if (!valid) return;


            IsRunning = true;
            IsEnabled = false;
            var pass = Hasher.MD5Hash(Password);
            var url = App.Current.Resources["UrlAPI"].ToString();

            var request = new UserRequest()
            {
                Email = Email,
                Password = pass
            };

            var json = JsonConvert.SerializeObject(request);

            var response = await _apiServices.PostGenericAsync<AccessToken>(url, "/api", "/Auth/Login", json);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {

                if (response.Message == "")
                {
                    response.Message = Messages.ConnectionError;
                }

                await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                return;
            }

            var user = (AccessToken)response.Result;
            Preferences.Set(Settings.FullName, $"{user.FirstName} {user.LastName}"); 
            Preferences.Set(Settings.Token, user.Token);


            await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");
        }

        public async Task<bool> ValidateFormAsync()
        {
            if (string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Password)
               )
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustFillFields, Messages.Accept);
                return false;
            }

            return true;

        }
    }
}
