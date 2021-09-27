using Common.Enums;
using Common.Models.Token;
using Common.Models.Users;
using WaltCommerce.Mobile.Helpers;
using WaltCommerce.Mobile.Helpers.I18n;
using WaltCommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.ViewModels
{
    public class UserProfilePageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private User _user;
        private readonly IApiServices _apiServices;
        private bool _isEnabled;
        private DelegateCommand _saveCommand;
        private string _name;
        private string _lastName;
        private string _nickname;
        private string _email;
        private bool _isRunning;
        private DateTime _birthDay;
        private string _telephone;
        private string _cellphone;
        private PersonalIdTypeEnum _selectionIdType;
        private GenderEnum _selectionGenderType;
        private string _personalId;
        private AccessToken _accessToken;
        private bool _isPasspost;
        private bool _isBusinessId;
        private bool _isMale;
        private bool _isFemale;
        private bool _isNonBinary;
        private bool _isLocalId;

        public UserProfilePageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            _isEnabled = true;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveProfile));

        private async void SaveProfile()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                return;
            }

            var valid = await ValidaDatos();
            if (!valid) return;


            User.FirstName = User.FirstName;
            User.LastName = User.LastName;
            User.NickName = NickName;
            User.Email = User.Email;
            User.Password = User.Password;
            User.Gender = SelectionGenderType;
            User.Telephone = Telephone;
            User.CellPhone = Cellphone;
            User.PersonalId = PersonalId;
            User.PersonalIdType = SelectionIdType;
            User.Dob = BirthDay;


            IsRunning = true;
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();

            var response = await _apiServices.PutAsync<User>(url, "/api", "/User", User, "", _accessToken.Token);
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

            //Update the Preference For user DAta.
            _accessToken.User = User;
            Preferences.Set(Settings.UserData, JsonConvert.SerializeObject(_accessToken));

            await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.UserCreated, Messages.Accept);
            await _navigationService.NavigateAsync("/MenuPage/NavigationPage/ProductPage");
        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

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

        public string NickName
        {
            get => _nickname;
            set => SetProperty(ref _nickname, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
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
            get => _birthDay;
            set => SetProperty(ref _birthDay, value);
        }

        public string Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        public string Cellphone
        {
            get => _cellphone;
            set => SetProperty(ref _cellphone, value);
        }

        public string PersonalId
        {
            get => _personalId;
            set => SetProperty(ref _personalId, value);
        }

        public PersonalIdTypeEnum SelectionIdType
        {
            get => _selectionIdType;
            set => SetProperty(ref _selectionIdType, value);
        }

        public GenderEnum SelectionGenderType
        {
            get => _selectionGenderType;
            set => SetProperty(ref _selectionGenderType, value);
        }

        public bool IsLocalId
        {
            get => _isLocalId;
            set => SetProperty(ref _isLocalId, value);
        }

        public bool IsPassport
        {
            get => _isPasspost;
            set => SetProperty(ref _isPasspost, value);
        }

        public bool IsBusinessId
        {
            get => _isBusinessId;
            set => SetProperty(ref _isBusinessId, value);
        }


        public bool IsMale
        {
            get => _isMale;
            set => SetProperty(ref _isMale, value);
        }

        public bool IsFemale
        {
            get => _isFemale;
            set => SetProperty(ref _isFemale, value);
        }

        public bool IsNonBinary
        {
            get => _isNonBinary;
            set => SetProperty(ref _isNonBinary, value);
        }



        private void LoadData()
        {
            FirstName = User.FirstName;
            LastName = User.LastName;
            NickName = User.NickName;
            Email = User.Email;
            BirthDay = User.Dob;
            Telephone = User.Telephone;
            Cellphone = User.CellPhone;
            PersonalId = User.PersonalId;
            SelectionIdType = User.PersonalIdType;
            SelectionGenderType = User.Gender;

            IsLocalId = User.PersonalIdType == PersonalIdTypeEnum.LocalId;
            IsPassport = User.PersonalIdType == PersonalIdTypeEnum.Passport;
            IsBusinessId = User.PersonalIdType == PersonalIdTypeEnum.BusinessId;

            IsMale = User.Gender == GenderEnum.male;
            IsFemale = User.Gender == GenderEnum.female;
            IsNonBinary = User.Gender == GenderEnum.nobinary;
        }

        public async Task<bool> ValidaDatos()
        {
            if (string.IsNullOrEmpty(FirstName)
                || string.IsNullOrEmpty(LastName)
                || string.IsNullOrEmpty(NickName)
                || string.IsNullOrEmpty(Email)
                || !DateValid.IsDate(BirthDay.ToString())
                || string.IsNullOrEmpty(Telephone)
                || string.IsNullOrEmpty(Cellphone)
                || SelectionGenderType == GenderEnum.none
                )
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustFillFields, Messages.Accept);
                return false;
            }

            return true;

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            var UserData = Preferences.Get(Settings.UserData, "");
            _accessToken = JsonConvert.DeserializeObject<AccessToken>(UserData);
            if (_accessToken is AccessToken)
            {
                User = _accessToken.User;
                LoadData();
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
