using Common.Models.ProductCategories;
using Common.Models.Products;
using Ecommerce.Mobile.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Mobile.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private DelegateCommand _viewProductCommand;
        private Product _selectedProduct;
        public ProductPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            CategoryModelList = new ObservableCollection<ProductCategory>();
            ProductList = new ObservableCollection<Product>();
        }

        public DelegateCommand ViewProductCommand => _viewProductCommand ?? (_viewProductCommand = new DelegateCommand(ViewProductDetail));


        public ObservableCollection<ProductCategory> CategoryModelList { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }
        //public ObservableCollection<Products> ProductModelList { get; set; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        private void ViewProductDetail()
        {
            var parameters = new NavigationParameters();
            parameters.Add("Product", _selectedProduct);
            var Category = CategoryModelList.Where(c=>c.Id == _selectedProduct.ProductCategoryFKey);

            var CategoryModel = new ProductCategory()
            {
                Identificator = Category.FirstOrDefault().Identificator,
                Description = Category.FirstOrDefault().Description
            };

            parameters.Add("Category", CategoryModel);
            _navigationService.NavigateAsync("ProductDetailPage", parameters);
        }

        private async Task GetProducts()
        {

            var url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            //var Token = Preferences.Get(Settings.Token, "");
            var response = await _apiServices.GetListAsync<ProductCategory>(url, "/api", "/ProductCategory", "", "");
            if (!response.IsSuccess)
            {
                if (response.Message == "")
                {
                    response.Message = "No se pudo conectar con el Servidor por favor intente más tarde.";
                }


                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Información", response.Message.ToString(), "Aceptar");
                await _navigationService.GoBackToRootAsync();
                return;
            }

            var ListProducts = (List<ProductCategory>)response.Result;
            ListProducts.ForEach(x => CategoryModelList.Add(x));
            //var list = ListProducts.Select(x => x.Products).ToList();            
            foreach (ProductCategory x in CategoryModelList)
            {

                foreach (Product y in x.Products)
                    ProductList.Add(y);

            }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //_usuario = (User)parameters["Usuario"];
            if (parameters.GetNavigationMode() != Prism.Navigation.NavigationMode.Back)
                await GetProducts();
        }
    }
}
