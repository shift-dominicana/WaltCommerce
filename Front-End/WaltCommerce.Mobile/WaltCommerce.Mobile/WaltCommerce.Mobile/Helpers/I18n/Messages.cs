using Common.Helpers.Interfaces;
using WaltCommerce.Mobile.Resources;
using System.Globalization;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.Helpers.I18n
{
    public class Messages
    {
        static Messages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept => Resource.Accept;
        public static string ConnectionError => Resource.ErrorConnection;
        public static string Info => Resource.InfoMessage;
        public static string MustFillFields => Resource.MustFillFields;
        public static string Cancel => Resource.Cancel;
        public static string Close => Resource.Close;

        //LoginPageViewModel.cs
        public static string Culture { get; set; }
        public static string TtLogin => Resource.TtLogin;
        public static string SignIn => Resource.SignIn;
        public static string LogIn => Resource.LogIn;
        public static string PhEmail => Resource.PhEmail;
        public static string PhPassword => Resource.PhPassword;

        //UserRegister
        public static string UserCreated => Resource.UserCreated;
        public static string TtRegisUser => Resource.TtRegisUser;


        //Menu
        public static string MenuOptProfile => Resource.MenuOptProfile;
        public static string MenuOptAddresses => Resource.MenuOptAddresses;
        public static string MenuOptOrders => Resource.MenuOptOrders;
        public static string MenuOptLogOut => Resource.MenuOptLogOut;
        public static string MenuOptProducts => Resource.MenuOptProducts;
        public static string AskLogOut => Resource.AskLogOut;

        //Profile
        public static string MustLogIn => Resource.MustLogIn;
        public static string MustAccount => Resource.MustAccount;

        public static string TimeOutMessage => Resource.TimeOutMessage;

        //Address
        public static string CreateAddressMsg => Resource.CreateAddressMsg;
        public static string UpdateAddressMsg => Resource.UpdateAddressMsg;

        //Categories
        public static string CategoryAll => Resource.categoryAll;


    }
}
