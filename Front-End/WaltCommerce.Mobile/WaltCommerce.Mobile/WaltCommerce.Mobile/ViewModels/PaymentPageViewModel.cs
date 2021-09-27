using Common.Models.BuyCartDetails;
using Common.Models.Token;
using Common.Models.UsersAddresses;
using WaltCommerce.Mobile.Helpers;
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
    public class PaymentPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private AccessToken _accessToken;
        private ObservableCollection<BuyCartDetail> _cartDetails;
        private float _totalReceipt;
        private float _subTotalReceipt;
        private bool _isDelivery;
        private bool _isPickup;
        private bool _isCash;
        private bool _isBankTransfer;
        private UserAddress _selectedAddress;

        public PaymentPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            CartUserDetail = new ObservableCollection<BuyCartDetail>();
            _navigationService = navigationService;
            _apiServices = apiServices;
            UserAddresses = new ObservableCollection<UserAddress>();
            _isDelivery = true;
            _isBankTransfer = true;
        }

        public ObservableCollection<BuyCartDetail> CartUserDetail
        {
            get => _cartDetails;
            set => SetProperty(ref _cartDetails, value);
        }

        public ObservableCollection<UserAddress> UserAddresses
        {
            get; set;
        }

        public float SubTotalReceipt { get=> _subTotalReceipt; set=>SetProperty(ref _subTotalReceipt, value); }
        public float TotalReceipt { get => _totalReceipt; set => SetProperty(ref _totalReceipt, value); }

        public bool IsDelivery
        {
            get => _isDelivery;
            set => SetProperty(ref _isDelivery, value);
        }

        public bool IsPickup
        {
            get => _isPickup;
            set => SetProperty(ref _isPickup, value);
        }

        public bool IsCash
        {
            get => _isCash;
            set => SetProperty(ref _isCash, value);
        }

        public bool IsBankTransfer
        {
            get => _isBankTransfer;
            set => SetProperty(ref _isBankTransfer, value);
        }

        public UserAddress SelectedAddress
        {
            get => _selectedAddress;
            set => SetProperty(ref _selectedAddress, value);
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var UserData = Preferences.Get(Settings.UserData, "");
            _accessToken = JsonConvert.DeserializeObject<AccessToken>(UserData);
            CartUserDetail = parameters.GetValue<ObservableCollection<BuyCartDetail>>("CartDetails");

            SubTotalReceipt = CartUserDetail.ToList().Sum(r => r.Total);
            TotalReceipt = SubTotalReceipt; //TODO: Add Taxes

            var List = await Utilities.GetAddress(_apiServices, _accessToken.User.Id);
            UserAddresses.Clear();
            List.ForEach(x => UserAddresses.Add(x));
            UserAddresses.Add(new UserAddress() { Id = 0, Name = "Otra Direccion" });

            if (_accessToken is AccessToken)
            {
               // await GetItemsDetail();

            }
        }
    }   
}
