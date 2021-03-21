using Common.Models.ProductCategories;
using Common.Models.Products;
using Common.Models.Token;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private DelegateCommand _viewProductCommand;
        private Product _selectedProduct;
        private DelegateCommand _categoryCommand;
        private ProductCategory _categorySelected;
        private bool _isBusy;
        private int _itemValue;
        private DelegateCommand _viewCartCommand;


        public ProductPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            CategoryModelList = new ObservableCollection<ProductCategory>();
            ProductList = new ObservableCollection<Product>();
            FullProductList = new ObservableCollection<Product>();
            IsBusy = true;

        }

        public DelegateCommand ViewProductCommand => _viewProductCommand ?? (_viewProductCommand = new DelegateCommand(ViewProductDetail));        
        public DelegateCommand CategoryCommand => _categoryCommand ?? (_categoryCommand = new DelegateCommand(CategoryFilter));
        public DelegateCommand<string> FilterCommand => new DelegateCommand<string>((string text) =>
        {
            FIlterData(text);
        });

        public DelegateCommand ViewCartCommand => _viewCartCommand ?? (_viewCartCommand = new DelegateCommand(OpenCartDetail));


        public ObservableCollection<ProductCategory> CategoryModelList { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Product> FullProductList { get; set; }        

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public int ItemValue
        {
            get => _itemValue;
            set => SetProperty(ref _itemValue, value);
        }

        public ProductCategory CategorySelected
        {
            get => _categorySelected;
            set => SetProperty(ref _categorySelected, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private async void ViewProductDetail()
        {
            if (SelectedProduct == null) return;
           
            var parameters = new NavigationParameters();
            parameters.Add("Product", SelectedProduct);
            parameters.Add("AllProducts", FullProductList);
            
           await _navigationService.NavigateAsync("ProductDetailPage", parameters);                                   
        }

        private async Task GetProducts()
        {
            
            var url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            //var Token = Preferences.Get(Settings.Token, "");
            IsBusy = true;
            var response = await _apiServices.GetListAsync<ProductCategory>(url, "/api", "/ProductCategory", "", "");
            //await Task.Delay(TimeSpan.FromSeconds(10));            
            if (!response.IsSuccess)
            {
                if (response.Message == "")
                {
                    response.Message = Messages.ConnectionError;
                }


                await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                await _navigationService.GoBackToRootAsync();
                return;
            }

            var ListCategories = (List<ProductCategory>)response.Result;
            ListCategories.ForEach(x => CategoryModelList.Add(x));

            //var list = ListCategories.Select(x => x.Products).ToList();            
            foreach (ProductCategory x in CategoryModelList)
            {

                foreach (Product y in x.Products)
                {
                    ProductList.Add(y);
                }

            }
            
            FullProductList = new ObservableCollection<Product>(ProductList);
            IsBusy = false;
        }

        private  void CategoryFilter()
        {
            ProductList.Clear();
            foreach (ProductCategory x in CategoryModelList)
            {
                if (x.Id == CategorySelected.Id) 
                {
                    foreach (var Product in x.Products)
                    {
                        ProductList.Add(Product);
                    }
                
                }                              
            }
        }

        private void FIlterData(string text)
        {
            ProductList.Clear();
            
            text = text?.ToLower()??"";
            var list = FullProductList.Where(f => f.Name.ToLower().Contains(text)).ToList();

            list.ForEach(l => ProductList.Add(l));

        }


        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //null for select the same product multiple times
            SelectedProduct = null;
            if (parameters.GetNavigationMode() != Prism.Navigation.NavigationMode.Back)
                await GetProducts();

            ItemValue = Preferences.Get(Settings.ItemsCart, 0);

        }

        private async void OpenCartDetail()
        {
            await _navigationService.NavigateAsync("CartDetailPage");
        }
    }
}
