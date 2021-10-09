using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BindingNavigator.NetCore.View
{
    /// <summary>
    /// Interaction logic for BindingNavigatorUc.xaml
    /// Implements the <see cref="System.Windows.Controls.UserControl" />
    /// Implements the <see cref="System.Windows.Markup.IComponentConnector" />
    /// </summary>
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class BindingNavigatorUc : UserControl
    {
        /// <summary>
        /// The add button visibility dependency property
        /// </summary>
        public static readonly DependencyProperty VisibilityAddProperty = DependencyProperty.Register(
            "VisibilityAdd",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilityAddChanged));

        /// <summary>
        /// The delete button visibility dependency property
        /// </summary>
        public static readonly DependencyProperty VisibilityDeleteProperty = DependencyProperty.Register(
            "VisibilityDelete",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilityDeleteChanged));

        /// <summary>
        /// The save button visibility dependency property
        /// </summary>
        public static readonly DependencyProperty VisibilitySaveProperty = DependencyProperty.Register(
            "VisibilitySave",
            typeof(bool),
            typeof(BindingNavigatorUc),
            new PropertyMetadata(true, OnVisibilitySaveChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingNavigatorUc"/> class.
        /// </summary>
        public BindingNavigatorUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the <see cref="E:VisibilityAddChanged" /> event.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
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
        }

        /// <summary>
        /// Handles the <see cref="E:VisibilityDeleteChanged" /> event.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnVisibilityDeleteChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BindingNavigatorUc control = obj as BindingNavigatorUc;
            if (control != null)
            {
                control.buttonDelete.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:VisibilitySaveChanged" /> event.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnVisibilitySaveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BindingNavigatorUc control = obj as BindingNavigatorUc;
            if (control != null)
            {
                control.buttonSave.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles the OnKeyDown event of the TextBox control.
        /// We want to move selection after Enter key
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UIElement element = sender as UIElement;
                if (element != null)
                {
                    object localValue = element.ReadLocalValue(TextBox.TextProperty);
                    BindingExpression bindingExpression = localValue as BindingExpression;
                    if (bindingExpression != null)
                    {
                        bindingExpression.UpdateSource();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [visibility add].
        /// </summary>
        /// <value><c>true</c> if add button is visible; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets or sets a value indicating whether [visibility delete].
        /// </summary>
        /// <value><c>true</c> if delete button is visible; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets or sets a value indicating whether [visibility save].
        /// </summary>
        /// <value><c>true</c> if save button is visible; otherwise, <c>false</c>.</value>
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