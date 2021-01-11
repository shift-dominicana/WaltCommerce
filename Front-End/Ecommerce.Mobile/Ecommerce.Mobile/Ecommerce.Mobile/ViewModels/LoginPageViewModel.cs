using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _userRegisterCommand;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand UserRegisterCommand => _userRegisterCommand ?? (_userRegisterCommand = new DelegateCommand(RegisterUser));

        private async void RegisterUser()
        {
            await _navigationService.NavigateAsync("UserRegisterPage");
        }
    }
}
