using System;

namespace BindingNavigator.Commands
{
    internal class AddItemCommand : NavigatorCommand
    {
        public AddItemCommand(IViewDataManipulator viewDataManipulator)
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
            return ViewDataManipulator.GetDataChanger !=null;
        }

        public override void Execute(object parameter)
        {
            IDataChanger dataChanger = ViewDataManipulator.GetDataChanger;
            dataChanger.AddNew();
            OnCanExecuteChanged();
        }
    }
}