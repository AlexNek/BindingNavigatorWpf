using System.Windows;

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
    }
}