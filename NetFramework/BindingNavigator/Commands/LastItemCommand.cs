using System;

namespace BindingNavigator.Commands
{
    internal class LastItemCommand : NavigatorCommand
    {
        public LastItemCommand(IViewDataManipulator viewDataManipulator)
            : base(viewDataManipulator)
        {
            if (viewDataManipulator == null)
            {
                throw new ArgumentNullException(nameof(viewDataManipulator));
            }
            viewDataManipulator.SelectionChanged += ViewDataManipulator_SelectionChanged;
        }

        private void ViewDataManipulator_SelectionChanged(object sender, int? pos)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return ViewDataManipulator.CanLast;
        }

        public override void Execute(object parameter)
        {
            ViewDataManipulator.Last();
        }
    }
}