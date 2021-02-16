using Common.Models.ProductCategories;
using Common.Models.Products;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;


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

             SimilarProducts = new ObservableCollection<Product>();
             FullProductList = new ObservableCollection<Product>();
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

        public ObservableCollection<Product> SimilarProducts { get; set; }
        public ObservableCollection<Product> FullProductList { get; set; }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Product = parameters.GetValue<Product>("Product");
            FullProductList = parameters.GetValue<ObservableCollection<Product>>("AllProducts");
            try
            {  
                foreach (Product p in FullProductList) {
                    if (p.SharedId != null) {
                        if (p.SharedId.Equals(Product.SharedId)) {
                            SimilarProducts.Add(p);
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

    }
}
