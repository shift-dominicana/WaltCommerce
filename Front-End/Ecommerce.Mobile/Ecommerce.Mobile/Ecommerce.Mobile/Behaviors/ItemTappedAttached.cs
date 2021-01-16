using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ecommerce.Mobile.Behaviors
{
    //Reference Code: https://forums.xamarin.com/discussion/72970/listview-selecteditem-using-mvvm-and-xaml
    public static class ItemTappedAttached
    {
        public static readonly BindableProperty CommandProperty =
        BindableProperty.CreateAttached(
            propertyName: "Command",
            returnType: typeof(ICommand),
            declaringType: typeof(ListView),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            validateValue: null,
            propertyChanged: OnItemTappedChanged);

        public static ICommand GetItemTapped(BindableObject bindable)
        {
            return (ICommand)bindable.GetValue(CommandProperty);
        }

        public static void SetItemTapped(BindableObject bindable, ICommand value)
        {
            bindable.SetValue(CommandProperty, value);
        }

        public static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ListView;
            if (control != null)
                control.ItemTapped += OnItemTapped;
        }

        private static void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var control = sender as ListView;
            var command = GetItemTapped(control);

            //if (command != null && command.CanExecute(e.Item))
            if (command != null)
                command.Execute(e.Item);
        }
    }
}
