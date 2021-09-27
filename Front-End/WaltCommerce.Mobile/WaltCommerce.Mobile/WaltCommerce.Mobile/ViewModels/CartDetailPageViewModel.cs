using Common.Models.BuyCartDetails;
using Common.Models.Token;
using WaltCommerce.Mobile.Helpers;
using WaltCommerce.Mobile.Helpers.I18n;
using WaltCommerce.Mobile.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WaltCommerce.Mobile.ViewModels
{
    public class CartDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private AccessToken _accessToken;
        private ObservableCollection<BuyCartDetail> _cartDetails;
        private DelegateCommand _decreaseButtonCmd;
        private DelegateCommand _increaseButton;
        private int _qty;
        private BuyCartDetail _cartItemSelected;
        private DelegateCommand _paymentCommand;

        public CartDetailPageViewModel(INavigationService navigationService, 
            IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            CartUserDetail = new ObservableCollection<BuyCartDetail>();
           
        }

        public DelegateCommand<object> DecreaseButtonCmd => new DelegateCommand<object>((object obj) =>
        {
            DecreaseQty(obj);
        });

        private void DecreaseQty(object obj)
        {
            var content = obj as BuyCartDetail;

            if (content.Quantity == 1)
                return;

            foreach (var item in CartUserDetail)
            {
                if (item.Id == content.Id)
                {
                    item.Quantity = item.Quantity - 1;
                    UpdateItemCart(item);
                }

            }
            ObservableCollection<BuyCartDetail> Collection = new ObservableCollection<BuyCartDetail>(CartUserDetail);
            CartUserDetail.Clear();
            CartUserDetail = new ObservableCollection<BuyCartDetail>(Collection);
        }


        public DelegateCommand<object> IncreaseButtonCmd => new DelegateCommand<object>((object obj) =>
        {
            IncreaseQty(obj);
        });

        private void IncreaseQty(object obj)
        {
            
            var content = obj as BuyCartDetail;
            foreach (var item in CartUserDetail)
            {
                if (item.Id == content.Id)
                {
                    item.Quantity = item.Quantity + 1;
                    UpdateItemCart(item);
                }

            }
            ObservableCollection<BuyCartDetail> Collection = new ObservableCollection<BuyCartDetail>(CartUserDetail);
            CartUserDetail.Clear();
            CartUserDetail = new ObservableCollection<BuyCartDetail>(Collection);
        }


        public DelegateCommand<object> DeleteButtonCmd => new DelegateCommand<object>((object obj) =>
        {
            DeleteItem(obj);
        });

        private void DeleteItem(object obj)
        {

            var content = obj as BuyCartDetail;
            CartUserDetail.Remove(content);

            DeleteItemCart(content);

            ObservableCollection<BuyCartDetail> Collection = new ObservableCollection<BuyCartDetail>(CartUserDetail);
            CartUserDetail.Clear();
            CartUserDetail = new ObservableCollection<BuyCartDetail>(Collection);
        }

        public DelegateCommand PaymentCommand => _paymentCommand ?? (_paymentCommand = new DelegateCommand(OpenPaymentPage));

        private async void OpenPaymentPage()
        {
            if (CartUserDetail.Count <= 0)
                return;

            var parameters = new NavigationParameters();
            parameters.Add("CartDetails", CartUserDetail);

            await _navigationService.NavigateAsync("PaymentPage", parameters);
        }

        public int Quantity
        {
            get => _qty;
            set => SetProperty(ref _qty, value);
        }

        public BuyCartDetail CartItemSelected
        {
            get => _cartItemSelected;
            set => SetProperty(ref _cartItemSelected, value);
        }
    



        public ObservableCollection<BuyCartDetail> CartUserDetail 
        {
            get => _cartDetails; 
            set => SetProperty(ref _cartDetails, value); 
        }

        private async void UpdateItemCart(BuyCartDetail ItemCart)
        {
            if (_accessToken is AccessToken)
            {

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                    return;
                }

                var url = App.Current.Resources["UrlAPI"].ToString();

                var response = await _apiServices.PutAsync<BuyCartDetail>(url, "/api", "/BuyCartDetail", ItemCart, "", _accessToken.Token);
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

        private async void DeleteItemCart(BuyCartDetail ItemCart)
        {
            if (_accessToken is AccessToken)
            {

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await App.Current.MainPage.DisplayAlert(Messages.Info, Messages.ConnectionError, Messages.Accept);
                    return;
                }

                var url = App.Current.Resources["UrlAPI"].ToString();

                var response = await _apiServices.DeleteAsync(url, "/api", "/BuyCartDetail", ItemCart.Id, "", _accessToken.Token);
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

        private async Task GetItemsDetail()
        {

            var url = App.Current.Resources["UrlAPI"].ToString();

            var response = await _apiServices.GetListAsync<BuyCartDetail>(url, "/api", $"/BuyCartDetail/GetCartItems?BuyCart={_accessToken.Cart.Id}", "", "");

            if (!response.IsSuccess)
            {
                if (response.Message == "")
                {
                    response.Message = Messages.ConnectionError;
                }
                await App.Current.MainPage.DisplayAlert(Messages.Info, response.Message, Messages.Accept);
                return;
            }

            var List = (List<BuyCartDetail>)response.Result;

            List.ForEach(i => CartUserDetail.Add(i));
            
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var UserData = Preferences.Get(Settings.UserData, "");
            _accessToken = JsonConvert.DeserializeObject<AccessToken>(UserData);

            if (parameters.GetNavigationMode() != Prism.Navigation.NavigationMode.Back)
            {
                if (_accessToken is AccessToken)
                {
                    await GetItemsDetail();

                }
            }
        }
    }
}
