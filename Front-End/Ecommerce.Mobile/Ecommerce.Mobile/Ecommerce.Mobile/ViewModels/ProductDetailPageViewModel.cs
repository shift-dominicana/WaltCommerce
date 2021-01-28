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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Product = parameters.GetValue<Product>("Product");
            Category = Product.ProductCategory;
        }
    }
}
