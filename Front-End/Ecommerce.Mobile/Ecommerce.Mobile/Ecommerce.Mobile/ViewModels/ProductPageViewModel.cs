using Common.Models.ProductCategories;
using Common.Models.Products;
using Ecommerce.Mobile.Helpers;
using Ecommerce.Mobile.Services;
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
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;

        public ProductPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            CategoryModelList = new ObservableCollection<ProductCategory>();
            ProductList = new ObservableCollection<List<Product>>();
        }

        public ObservableCollection<ProductCategory> CategoryModelList { get; set; }
        public ObservableCollection<List<Product>> ProductList { get; set; }
        //public ObservableCollection<Products> ProductModelList { get; set; }



        private async Task GetProducts()
        {            

            var url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            var Token = Preferences.Get(Settings.Token, "");
            var response = await _apiServices.GetListAsync<ProductCategory>(url, "/api", "/ProductCategory", "",Token);
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
            var list = CategoryModelList.Select(x => x.Products).ToList();
            list.ForEach(p => ProductList.Add(p.ToList()));
           
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //_usuario = (User)parameters["Usuario"];
            await GetProducts();            
        }
    }
}
