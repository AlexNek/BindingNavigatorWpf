using System;

namespace BindingNavigator.Commands
{
    internal class NextItemCommand : NavigatorCommand
    {
        public NextItemCommand(IViewDataManipulator viewDataManipulator)
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
            return ViewDataManipulator.CanNext;
        }

        public override void Execute(object parameter)
        {
            ViewDataManipulator.Next();
        }
    }
}