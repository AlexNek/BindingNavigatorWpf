# How to use BindingNavigator


1. Reference BindingNavigator.dll. Load over Visual Studio nuget packet manager, packet `BindingNavigator`
2. Add grid and binding navigator in XAML inside `DockPanel`. You can use any panel type but scrollbars is easy to get into DockPanel.
```XML
<DockPanel>
    <View:BindingNavigatorUc DockPanel.Dock="Bottom" DataContext="{Binding BindingNavigatorDataContext}"/>
    <DataGrid ItemsSource="{Binding Customers}" SelectedIndex="{Binding SelectedIndex}" SelectionChanged="Grid_OnSelectionChanged">
</DockPanel>
```
3. This control intended to use together with [MVVM Pattern](https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/). You need to define some properties in your view model:
```C#
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
```

4. Default navigator implementation use `ObservableCollection` so define the data source as ObservableCollection
```C#
        private readonly ObservableCollection<CustomerItemUi> mCustomers = new ObservableCollection<CustomerItemUi>();
```

5. Create data manipulation class. Here is sample for `ObservableCollection`
```C#
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
            //TODO
        }
    }
```

6. Init BindingNavigator
```C#
IDataChanger dataChanger = new IssueItemDataChanger(mCustomers);
mViewDataManipulator = new ObservableCollectionDataManipulator<CustomerItemUi>(mCustomers, dataChanger);
mViewDataManipulator.SelectionChanged += DataManipulator_SelectionChanged;

mBindingNavigatorDataContext = new BindingNavigatorViewModel(mViewDataManipulator);
mBindingNavigatorDataContext.DataCount = mCustomers.Count;
mBindingNavigatorDataContext.CurrentPosition = 0;
```

7. Implement `DataManipulator_SelectionChanged` that you can sync binding navigator with grid position
```C#
        private void DataManipulator_SelectionChanged(object sender, int? selectionIndex)
        {
            if (selectionIndex.HasValue)
            {
                if (selectionIndex >= 0 && selectionIndex < mCustomers.Count)
                {
                    SelectedIndex = selectionIndex.Value;
                }
            }
        }
```
8. Implement Grid_OnSelectionChanged on view and ChangeSelection on view model that grid can sync row selection with navigator
```C#
        private void Grid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object eOriginalSource = e.OriginalSource;
            //new selection
            IList addedItems = e.AddedItems;
            if (addedItems.Count > 0)
            {
                mViewModel.ChangeSelection(addedItems[0]);
            }
        }
```

```C#
        public void ChangeSelection(object selectedItem)
        {
            CustomerItemUi itemUi = selectedItem as CustomerItemUi;
            if (itemUi != null)
            {
                int selectedIndex = mCustomers.IndexOf(itemUi);

                if (selectedIndex >= 0)
                {
                    mViewDataManipulator.ToAbsolutePosition(selectedIndex);
                }
            }
        }
```