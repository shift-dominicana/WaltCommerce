using Common.Models.Users;
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

        public UserProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
    }
}
