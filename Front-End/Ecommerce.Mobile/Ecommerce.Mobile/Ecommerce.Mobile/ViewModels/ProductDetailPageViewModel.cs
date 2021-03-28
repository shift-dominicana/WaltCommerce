
using Common.Models.BuyCartDetails;
using Common.Models.ProductCategories;
using Common.Models.Products;
using Common.Models.Token;
using Common.Models.Users;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private Product _product;
        private Product _selectedProductColor;
        private ProductCategory _category;

        private DelegateCommand _decreaseButtonCmd;
        private DelegateCommand _increaseButton;

        private AccessToken _accessToken;
        private User _user;
        private DelegateCommand _shoppingCarCommand;
        private int _qty;
        private DelegateCommand _changeColorCommand;

        public ProductDetailPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            SimilarProducts = new ObservableCollection<Product>();
            FullProductList = new ObservableCollection<Product>();
            Qty = 1;
        }

        public DelegateCommand ShoppingCarCommand => _shoppingCarCommand ?? (_shoppingCarCommand = new DelegateCommand(AddToShoppingCar));

        public DelegateCommand DecreaseButtonCmd => _decreaseButtonCmd ?? (_decreaseButtonCmd = new DelegateCommand(DecreaseQty));

        private void DecreaseQty()
        {
            if (Qty == 1)
                return;

            Qty--;
        }

        public DelegateCommand IncreaseButtonCmd => _increaseButton ?? (_increaseButton = new DelegateCommand(IncreaseQty));

        private void IncreaseQty()
        {
            Qty ++;
        }

        public DelegateCommand ChangeColorCommand => _changeColorCommand ?? (_changeColorCommand = new DelegateCommand(ChangeProduct));

        private async void ChangeProduct()
        {
            if (_selectedProductColor == null) return;

            var parameters = new NavigationParameters();
            parameters.Add("Product", _selectedProductColor);
            parameters.Add("AllProducts", FullProductList);

            await _navigationService.NavigateAsync("../ProductDetailPage", parameters);
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

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public int Qty
        {
            get => _qty;
            set => SetProperty(ref _qty, value);
        }


        public Product SelectedColor
        {
            get => _selectedProductColor;
            set => SetProperty(ref _selectedProductColor, value);
        }

        public ObservableCollection<Product> SimilarProducts { get; set; }
        public ObservableCollection<Product> FullProductList { get; set; }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Product = parameters.GetValue<Product>("Product");
            FullProductList = parameters.GetValue<ObservableCollection<Product>>("AllProducts");
            try
            {
                foreach (Product p in FullProductList)
                {
                    if (p.SharedId != null)
                    {
                        if (p.SharedId.Equals(Product.SharedId))
                        {
                            SimilarProducts.Add(p);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var UserData = Preferences.Get(Settings.UserData, "");
            _accessToken = JsonConvert.DeserializeObject<AccessToken>(UserData);

        }


        private async void AddToShoppingCar()
        {
            if (_accessToken is AccessToken)
            {

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                    return;
                }

                var shopping = new BuyCartDetail()
                {
                    IsDeleted = false,
                    CreationDate = DateTime.Now,
                    CreatedBy = "Admin",
                    Product = this.Product,
                    BuyCart = _accessToken.Cart,
                    Quantity = Qty,

                };

                var url = App.Current.Resources["UrlAPI"].ToString();

                var response = await _apiServices.PostAsync<BuyCartDetail>(url, "/api", "/BuyCartDetail", shopping, "", _accessToken.Token);
                if (!response.IsSuccess)
                {
                    if (response.Message == "")
                    {
                        response.Message = Messages.ConnectionError;
                    }
                    await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                    return;
                }


                await Utilities.GetCountItemsCartDetail(_apiServices, _accessToken);


            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.MustAccount, Messages.Accept);

            }
        }

    }
}
