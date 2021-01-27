using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Mobile.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ProductDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
