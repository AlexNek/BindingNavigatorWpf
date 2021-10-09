using System.Collections.ObjectModel;

using BindingNavigator.NetCore;

using NetCore.Demo.Model;

namespace NetCore.Demo
{
    public class CustomerItemDataChanger : IDataChanger
    {
        private readonly ObservableCollection<CustomerItemUi> mItems;

        public CustomerItemDataChanger(ObservableCollection<CustomerItemUi> items)
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
            //TODO
        }
    }
}