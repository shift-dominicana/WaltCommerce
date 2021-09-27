using Common.Enums;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.Views
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
        }

        private void OnGenderTypeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;

                if (radioButton.IsChecked)
                {
                    switch (radioButton.Value)
                    {
                        case "1":
                            GenderSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, GenderEnum.male);
                            break;
                        case "2":
                            GenderSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, GenderEnum.female);
                            break;
                        case "3":
                            GenderSelectedValue.SetValue(RadioButtonGroup.SelectedValueProperty, GenderEnum.nobinary);
                            break;
                    }
                }

            }

        }
        
    }
}
