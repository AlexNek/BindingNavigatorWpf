using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using BindingNavigator.ViewModel;
using BindingNavigator.Wpf.Demo.Model;

namespace BindingNavigator.Wpf.Demo.ViewModel
{
    internal class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ObservableCollection<CustomerItemUi> mCustomers = new ObservableCollection<CustomerItemUi>();

        private BindingNavigatorViewModel mBindingNavigatorDataContext;

        private int mSelectedIndex;

        private CustomerItemUi mSelectedItem;

        public MainWindowVm()
        {
            // Grid data used from
            // https://www.wpftutorial.net/DataGrid.html
            mCustomers.Add(
                new CustomerItemUi
                    {
                        Firstname = "Christian",
                        LastName = "Moser",
                        Gender = CustomerItemUi.EGender.Male,
                        WebSite = new Uri("http://wwww.wpftutorial.net"),
                        ReceiveNewsletter = true
                    });
            mCustomers.Add(
                new CustomerItemUi
                    {
                        Firstname = "Peter",
                        LastName = "Meyer",
                        Gender = CustomerItemUi.EGender.Male,
                        WebSite = new Uri("http://www.petermeyer.com"),
                        ReceiveNewsletter = false
                    });
            mCustomers.Add(
                new CustomerItemUi
                    {
                        Firstname = "Lisa",
                        LastName = "Simpson",
                        Gender = CustomerItemUi.EGender.Female,
                        WebSite = new Uri("http://www.onthesimpsom.com"),
                        ReceiveNewsletter = false
                    });
            mCustomers.Add(
                new CustomerItemUi
                    {
                        Firstname = "Betty",
                        LastName = "Bossy",
                        Gender = CustomerItemUi.EGender.Female,
                        WebSite = new Uri("http://www.bettybossy.ch"),
                        ReceiveNewsletter = false
                    });

            //clear selection
            SelectedIndex = -1;

            IDataChanger getDataChanger = new IssueItemDataChanger(mCustomers);
            ObservableCollectionDataManipulator<CustomerItemUi> viewDataManipulator =
                new ObservableCollectionDataManipulator<CustomerItemUi>(mCustomers, getDataChanger);
            viewDataManipulator.SelectionChanged += DataManipulator_SelectionChanged;

            mBindingNavigatorDataContext = new BindingNavigatorViewModel(viewDataManipulator);
            mBindingNavigatorDataContext.DataCount = mCustomers.Count;
            mBindingNavigatorDataContext.CurrentPosition = 0;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DataManipulator_SelectionChanged(object sender, int? selectionIndex)
        {
            if (selectionIndex.HasValue)
            {
                if (selectionIndex >= 0 && selectionIndex < mCustomers.Count)
                {
                    SelectedIndex = selectionIndex.Value;
                    if (selectionIndex.Value == 0)
                    {
                        SelectedItem = mCustomers[selectionIndex.Value];
                    }
                }
            }
        }

        public BindingNavigatorViewModel BindingNavigatorDataContext
        {
            get
            {
                return mBindingNavigatorDataContext;
            }
            set
            {
                mBindingNavigatorDataContext = value;
            }
        }

        public ObservableCollection<CustomerItemUi> Customers
        {
            get
            {
                return mCustomers;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return mSelectedIndex;
            }
            set
            {
                mSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// Hack for default selectedIndex error
        /// </summary>
        /// <value>The selected item.</value>
        public CustomerItemUi SelectedItem
        {
            get
            {
                return mSelectedItem;
            }
            set
            {
                mSelectedItem = value;
                OnPropertyChanged();
            }
        }
    }
}