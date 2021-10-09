using System;

namespace BindingNavigator.NetCore.Commands
{
    internal class PrevItemCommand : NavigatorCommand
    {
        public PrevItemCommand(IViewDataManipulator viewDataManipulator)
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
            return ViewDataManipulator.CanPrev;
        }

        public override void Execute(object parameter)
        {
            ViewDataManipulator.Prev();
        }
    }
}