using Common.Models.BuyCartDetails;
using Common.Models.Token;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
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

namespace Ecommerce.Mobile.ViewModels
{
    public class CartDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private AccessToken _accessToken;
        private ObservableCollection<BuyCartDetail> _cartDetails;

        public CartDetailPageViewModel(INavigationService navigationService, 
            IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            CartUserDetail = new ObservableCollection<BuyCartDetail>();
        }

        public ObservableCollection<BuyCartDetail> CartUserDetail 
        {
            get => _cartDetails; 
            set => SetProperty(ref _cartDetails, value); 
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
            if (_accessToken is AccessToken)
            {
                await GetItemsDetail(); 

            }
        }
    }
}
