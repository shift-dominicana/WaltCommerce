using Common.Models.Users;
using Ecommerce.Mobile.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Mobile.ViewModels
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
        private int _selectionIdType;
        private int _selectionGenderType;
        private string _personalId;

        public UserProfilePageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            _isEnabled = true;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveProfile));

        private void SaveProfile()
        {
            //throw new NotImplementedException();
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

        public int SelectionIdType 
        { 
            get=>_selectionIdType;
            set => SetProperty(ref _selectionIdType, value);
        }

        public int SelectionGenderType
        {
            get => _selectionGenderType;
            set => SetProperty(ref _selectionGenderType, value);
        }
    }
}
