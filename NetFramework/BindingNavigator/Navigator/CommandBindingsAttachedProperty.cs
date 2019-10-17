using System.Windows;
using System.Windows.Input;

namespace BindingNavigator.Navigator
{
    /// <summary>
    /// Class CommandBindingsAttachedProperty.
    /// https://weblogs.thinktecture.com/cnagel/2010/08/bindingnavigator-for-wpf-part-1---creating.html
    /// https://weblogs.thinktecture.com/cnagel/2010/08/bindingnavigator-for-wpf-part-2using.html
    /// Christian Nagel blog
    /// Implements the <see cref="System.Windows.DependencyObject" />
    /// </summary>
    /// <seealso cref="System.Windows.DependencyObject" />
    public class CommandBindingsAttachedProperty : DependencyObject
    {
        public static readonly DependencyProperty RegisterCommandBindingsProperty = DependencyProperty.RegisterAttached(
            "RegisterCommandBindings",
            typeof(CommandBindingCollection),
            typeof(CommandBindingsAttachedProperty),
            new PropertyMetadata(null, OnRegisterCommandBindingChanged));

        public static CommandBindingCollection GetRegisterCommandBindings(UIElement element)
        {
            return (CommandBindingCollection)element.GetValue(RegisterCommandBindingsProperty);
        }

        public static void SetRegisterCommandBindings(UIElement element, CommandBindingCollection value)
        {
            element.SetValue(RegisterCommandBindingsProperty, value);
        }

        private static void OnRegisterCommandBindingChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element != null)
            {
                CommandBindingCollection bindings = e.NewValue as CommandBindingCollection;
                if (bindings != null)
                {
                    element.CommandBindings.AddRange(bindings);
                }
            }
        }
    }
}