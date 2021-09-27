using Common.Enums;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.Views
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void OnObtainMethodCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;

                if (radioButton.IsChecked)
                {
                    switch (radioButton.Value)
                    {
                        case "1":
                            ObtainMethodSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, false);
                            PickerAddress.IsVisible = true;
                            CashOption.IsEnabled = false;
                            BankTranferOption.SetValue(RadioButton.IsCheckedProperty, true);
                            break;
                        case "2":
                            ObtainMethodSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, true);
                            PickerAddress.IsVisible = false;
                            CashOption.IsEnabled = true;
                            break;
                    }
                }

            }

        }

        private void OnPayMethodCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;

                if (radioButton.IsChecked)
                {
                    switch (radioButton.Value)
                    {
                        case "1":
                            PayMethodSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, PayModeEnum.CASH);
                            break;
                        case "2":
                            PayMethodSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, PayModeEnum.TRANSFER);
                            break;
                    }
                }

            }

        }
    }
}
