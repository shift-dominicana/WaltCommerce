using Common.Models.BuyCartDetails;
using Ecommerce.Mobile.Models;
using Ecommerce.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Mobile.Helpers.CartDetail
{
    public static class CartDetail_ApiCalls
    {
        private static  IApiServices _apiService;

        public static async Task<List<Response<BuyCartDetail>>> GetBuyCartDetail(int BuyCartId)
        {
            _apiService = new ApiServices();
            var url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            //var Token = Preferences.Get(Settings.Token, "");
            
            var response = await _apiService.GetListAsync<BuyCartDetail>(url, "/api", $"/BuyCartDetail/GetCartItems?BuyCart={BuyCartId}", "", "");

            if (!response.IsSuccess)
                return null;

            return (List<Response<BuyCartDetail>>)response.Result;

        }

        public async static Task<int> GetCountItemsDetail(int BuyCartId) 
        {
            var List = await GetBuyCartDetail(BuyCartId);


            if (List != null)
            {
                return List.ToList().Select(x => x.Result.Quantity).Sum();
            }

            return 0;
        }
    }
}
