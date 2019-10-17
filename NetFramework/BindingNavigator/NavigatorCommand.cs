using System;
using System.Windows.Input;

namespace BindingNavigator
{
    public abstract class NavigatorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IViewDataManipulator mViewDataManipulator;

        protected NavigatorCommand(IViewDataManipulator viewDataManipulator)
        {
            mViewDataManipulator = viewDataManipulator;
        }

        public abstract bool CanExecute(object parameter);


        public abstract void Execute(object parameter);
        

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        protected IViewDataManipulator ViewDataManipulator
        {
            get
            {
                return mViewDataManipulator;
            }
        }
    }
}