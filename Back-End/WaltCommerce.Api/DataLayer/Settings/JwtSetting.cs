namespace DataLayer.Settings
{
    public class JwtSetting
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecretKey { get; set; }
    }
}
