using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BindingNavigator.View
{
    /// <summary>
    /// Interaction logic for BindingNavigatorUc.xaml
    /// </summary>
    public partial class BindingNavigatorUc : UserControl
    {
        public static readonly DependencyProperty VisibilityAddProperty = DependencyProperty.Register(
            "VisibilityAdd",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilityAddChanged));

        public static readonly DependencyProperty VisibilityDeleteProperty = DependencyProperty.Register(
            "VisibilityDelete",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilityDeleteChanged));

        public static readonly DependencyProperty VisibilitySaveProperty = DependencyProperty.Register(
            "VisibilitySave",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilitySaveChanged));

        public BindingNavigatorUc()
        {
            InitializeComponent();
        }

        private static void OnVisibilityAddChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BindingNavigatorUc control = obj as BindingNavigatorUc;
            if (control != null)
            {
                control.buttonAdd.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
                //BindingNavigatorViewModel viewModel = control.DataContext as BindingNavigatorViewModel;
                //if (viewModel != null)
                //{
                //    viewModel.VisibilityAdd = (bool)e.NewValue;
                //}
            }

            //e.NewValue
        }

        private static void OnVisibilityDeleteChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BindingNavigatorUc control = obj as BindingNavigatorUc;
            if (control != null)
            {
                control.buttonDelete.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private static void OnVisibilitySaveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BindingNavigatorUc control = obj as BindingNavigatorUc;
            if (control != null)
            {
                control.buttonSave.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Activate data store
                UIElement prevFocus = sender as UIElement;
                //Focus();
                if (prevFocus != null)
                {
                    object localValue = prevFocus.ReadLocalValue(TextBox.TextProperty);
                    BindingExpression bindingExpression = localValue as BindingExpression;
                    if (bindingExpression != null)
                    {
                        bindingExpression.UpdateSource();
                        //object bindingExpressionValue = bindingExpression.Value;
                        //   PropertyInfo property = bindingExpression.DataItem.GetType().GetProperty(bindingExpression.ParentBinding.Path.Path);
                        //if (property != null)
                        //{
                        //    int? newValue=null;
                        //    property.SetValue(bindingExpression.DataItem, newValue, null);
                        //}
                    }
                }

                //if (prevFocus != null)
                //{
                //    prevFocus.Focus();
                //}
            }
        }

        public bool VisibilityAdd
        {
            get
            {
                return (bool)GetValue(VisibilityAddProperty);
            }
            set
            {
                SetValue(VisibilityAddProperty, value);
            }
        }

        public bool VisibilityDelete
        {
            get
            {
                return (bool)GetValue(VisibilityDeleteProperty);
            }
            set
            {
                SetValue(VisibilityDeleteProperty, value);
            }
        }

        public bool VisibilitySave
        {
            get
            {
                return (bool)GetValue(VisibilitySaveProperty);
            }
            set
            {
                SetValue(VisibilitySaveProperty, value);
            }
        }
    }
}