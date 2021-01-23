
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Ecommerce.Mobile.Helpers
{
    public static class Settings
    {
        private const string _token = "token";
        private const string _isLogin = "isLogin";
        private const string _fullName = "FullName";

        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_token, value);
        }

        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(_isLogin, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isLogin, value);
        }

        public static string FullName
        {
            get => AppSettings.GetValueOrDefault(_fullName, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_fullName, value);
        }
    }
}
