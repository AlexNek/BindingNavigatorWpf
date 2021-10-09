using System;

namespace BindingNavigator.NetCore.Commands
{
    internal class DeleteItemCommand : NavigatorCommand
    {
        public DeleteItemCommand(IViewDataManipulator viewDataManipulator)
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
            return ViewDataManipulator.GetDataChanger != null && ViewDataManipulator.CanDelete;
        }

        public override void Execute(object parameter)
        {
            IDataChanger dataChanger = ViewDataManipulator.GetDataChanger;
            if (ViewDataManipulator.Current != null)
            {
                dataChanger.Delete(ViewDataManipulator.Current.Value);
                OnCanExecuteChanged();
            }
        }
    }
}