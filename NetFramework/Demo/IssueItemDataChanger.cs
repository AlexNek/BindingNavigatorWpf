using System.Collections.ObjectModel;

using BindingNavigator.Wpf.Demo.Model;

namespace BindingNavigator.Wpf.Demo
{
    public class IssueItemDataChanger : IDataChanger
    {
        private readonly ObservableCollection<CustomerItemUi> mItems;

        public IssueItemDataChanger(ObservableCollection<CustomerItemUi> items)
        {
            mItems = items;
        }

        public object AddNew()
        {
            CustomerItemUi newItem = new CustomerItemUi ();
            mItems.Add(newItem);
            return newItem;
        }

        public void Delete(int viewPosition)
        {
            if (viewPosition >= 0 && viewPosition < mItems.Count)
            {
                mItems.RemoveAt(viewPosition);
            }
        }

        public void Save()
        {
        }
    }
}