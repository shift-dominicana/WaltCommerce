using System;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.Views
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void MasterDetailButton_Pressed(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
            //open the master detail page when button is clicked.
            //MasterDetailPage.IsPresentedProperty.Equals(true);
            //MenuNavigation.IsPresentedProperty.Equals(true);
        }
    }
}

