using System.Collections;
using System.Windows;
using System.Windows.Controls;

using BindingNavigator.Wpf.Demo.ViewModel;

namespace BindingNavigator.Wpf.Demo.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVm mViewModel;
        public MainWindow()
        {
            mViewModel = new MainWindowVm();
            DataContext = mViewModel;
            InitializeComponent();
        }

        private void Grid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object eOriginalSource = e.OriginalSource;
            //new selection
            IList addedItems = e.AddedItems;
            if (addedItems.Count > 0)
            {
                mViewModel.ChangeSelection(addedItems[0]);
            }

            //old selection
            IList eRemovedItems = e.RemovedItems;
        }
    }
}