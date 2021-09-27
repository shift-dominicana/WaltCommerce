using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WaltCommerce.Mobile.Controls
{
    public class AutoScrollListView : ListView
    {
        private INotifyCollectionChanged _previousObservableCollection;

        public AutoScrollListView(ListViewCachingStrategy cachingStrategy)
            : base(cachingStrategy)
        {
        }

        public AutoScrollListView()
            : base()
        {
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(ItemsSource))
            {
                if (_previousObservableCollection != null)
                {
                    _previousObservableCollection.CollectionChanged -= OnItemsSourceCollectionChanged;
                    _previousObservableCollection = null;
                }

                if (ItemsSource is INotifyCollectionChanged newObservableCollection)
                {
                    _previousObservableCollection = newObservableCollection;
                    newObservableCollection.CollectionChanged += OnItemsSourceCollectionChanged;
                }
            }
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var item in e.NewItems)
                {
                    // Scroll to the item that has just been added/updated to make it visible
                    ScrollTo(item, ScrollToPosition.MakeVisible, true);
                }
            }
        }
    }
}
