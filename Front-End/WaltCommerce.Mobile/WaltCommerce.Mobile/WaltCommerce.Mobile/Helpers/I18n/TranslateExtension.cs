using Common.Helpers.Interfaces;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaltCommerce.Mobile.Helpers.I18n
{
    //[ContentProperty("Text")]
    //public class TranslateExtension : IMarkupExtension
    //{
    //    const string ResourceId = "Common.Resources";

    //    public string Text { get; set; }

    //    public object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (Text == null)
    //            return null;

    //        ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

    //        return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
    //    }
    //}


    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private const string ResourceId = "Ecommerce.Mobile.Resources.Resource";
        private static  Lazy<ResourceManager> ResMgr =
            new Lazy<ResourceManager>(() => new ResourceManager(
                ResourceId,
                typeof(TranslateExtension).GetTypeInfo().Assembly));

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            
            if (Text == null)
            {
                return "";
            }

            try
            {
                string translation = ResMgr.Value.GetString(Text, ci);

                if (translation == null)
                {
#if DEBUG
                    throw new ArgumentException(
                        string.Format(
                            "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                            Text, ResourceId, ci.Name), "Text");
#else
            translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
                }
                return translation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "";
        }

    }
}
