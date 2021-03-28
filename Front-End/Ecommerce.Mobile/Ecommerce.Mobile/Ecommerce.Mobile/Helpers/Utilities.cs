using Common.Models.BuyCartDetails;
using Common.Models.Token;
using Ecommerce.Mobile.Helpers.I18n;
using Ecommerce.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.Helpers
{
    public static class Utilities
    {
        public static async Task GetCountItemsCartDetail(IApiServices apiServices, AccessToken accessToken)
        {

            int count = 0;
            var url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            //var Token = Preferences.Get(Settings.Token, "");

            var response = await apiServices.GetListAsync<BuyCartDetail>(url, "/api", $"/BuyCartDetail/GetCartItems?BuyCart={accessToken.Cart.Id}", "", "");

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

            if (response.Result != null)
            {
                count = List.ToList().Select(x => x.Quantity).Sum();
            }

            Preferences.Set(Settings.ItemsCart, count);

        }
    }
}
