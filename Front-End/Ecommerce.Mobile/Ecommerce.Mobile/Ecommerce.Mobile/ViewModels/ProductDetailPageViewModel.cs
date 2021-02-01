using Common.Models.ProductCategories;
using Common.Models.Products;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Mobile.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private Product _product;
        private ProductCategory _category;
        private String _formatedPrice;

        public ProductDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ProductCategory Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public String Price
        {
            get => _formatedPrice;
            set => SetProperty(ref _formatedPrice, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Product = parameters.GetValue<Product>("Product");
            Price = "RD"+Product.Price.ToString("C");
            base.OnNavigatedTo(parameters);
        }
    }
}
