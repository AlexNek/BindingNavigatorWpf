using System;

namespace BindingNavigator.NetCore.Commands
{
    internal class FirstItemCommand : NavigatorCommand
    {
        public FirstItemCommand(IViewDataManipulator viewDataManipulator)
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
            return ViewDataManipulator.CanFirst;
        }

        public override void Execute(object parameter)
        {
            ViewDataManipulator.First();
        }
    }
}