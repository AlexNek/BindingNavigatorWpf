using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BindingNavigator.Navigator
{
    /// <summary>
    /// Class BindingNavigator.
    /// Implements the <see cref="Alex.CommonSmall.NotifyPropertyChanged" />
    /// https://weblogs.thinktecture.com/cnagel/2010/08/bindingnavigator-for-wpf-part-1---creating.html
    /// https://weblogs.thinktecture.com/cnagel/2010/08/bindingnavigator-for-wpf-part-2using.html
    /// Christian Nagel blog 
    /// </summary>
    /// <seealso cref="Alex.CommonSmall.NotifyPropertyChanged" />
    public class BindingNavigator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly CommandBindingCollection mCommandBindings = new CommandBindingCollection();

        private readonly CollectionViewSource mDataSource;

        public BindingNavigator(IEnumerable dataSource)
        {
            mDataSource = new CollectionViewSource();
            mDataSource.Source = dataSource;

            InitializeCommands();
        }

        public void InitializeCommands()
        {
            var nextCommand = new CommandBinding(BindingNavigatorCommands.NextRecord, OnNextRecord);
            mCommandBindings.Add(nextCommand);

            var previousCommand = new CommandBinding(BindingNavigatorCommands.PreviousRecord, OnPreviousRecord);
            mCommandBindings.Add(previousCommand);

            var firstCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnFirstRecord);
            mCommandBindings.Add(firstCommand);

            var lastCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnLastRecord);
            mCommandBindings.Add(lastCommand);

            var gotoCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnGotoRecord);
            mCommandBindings.Add(gotoCommand);

            var addCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnAddRecord);
            mCommandBindings.Add(addCommand);

            var saveCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnSaveRecord);
            mCommandBindings.Add(saveCommand);

            var deleteCommand = new CommandBinding(BindingNavigatorCommands.FirstRecord, OnDeleteRecord);
            mCommandBindings.Add(deleteCommand);
        }

        public static void OnNextRecord(object sender, ExecutedRoutedEventArgs e)
        {
            Contract.Requires(sender is FrameworkElement, "sender must be a FrameworkElement");
            Contract.Requires(
                (sender as FrameworkElement).DataContext is BindingNavigator,
                "sender.DataContext must be a BindingNavigator");

            BindingNavigator bindingNavigator = (sender as FrameworkElement).DataContext as BindingNavigator;
            if (bindingNavigator != null)
            {
                bindingNavigator.OnNextRecord();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnAddRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnDeleteRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnFirstRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnGotoRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnLastRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnNextRecord()
        {
            mDataSource.View.MoveCurrentToNext();
            if (mDataSource.View.IsCurrentAfterLast)
            {
                mDataSource.View.MoveCurrentToLast();
            }

            OnPropertyChanged("CurrentPosition");
        }

        private void OnPreviousRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnSaveRecord(object sender, ExecutedRoutedEventArgs e)
        {
        }

        public CommandBindingCollection CommandBindings
        {
            get
            {
                return mCommandBindings;
            }
        }

        public ICollectionView View
        {
            get
            {
                return mDataSource.View;
            }
        }
    }
}