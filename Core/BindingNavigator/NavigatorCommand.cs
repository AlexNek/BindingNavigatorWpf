using System;
using System.Windows.Input;

namespace BindingNavigator.NetCore
{
    /// <summary>
    /// Class NavigatorCommand.
    /// Indented to use internally but you can create the new commands too
    /// Implements the <see cref="System.Windows.Input.ICommand" />
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public abstract class NavigatorCommand : ICommand
    {
        /// <summary>
        /// Occurs when CanExecute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// The view data manipulator implementation
        /// </summary>
        private readonly IViewDataManipulator mViewDataManipulator;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigatorCommand"/> class.
        /// </summary>
        /// <param name="viewDataManipulator">The view data manipulator.</param>
        protected NavigatorCommand(IViewDataManipulator viewDataManipulator)
        {
            mViewDataManipulator = viewDataManipulator;
        }

        /// <summary>
        /// Determines whether command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns><c>true</c> if this instance can be executed; otherwise, <c>false</c>.</returns>
        public abstract bool CanExecute(object parameter);


        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public abstract void Execute(object parameter);


        /// <summary>
        /// Called when CanExecute must be changed.
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the view data manipulator.
        /// </summary>
        /// <value>The view data manipulator.</value>
        protected IViewDataManipulator ViewDataManipulator
        {
            get
            {
                return mViewDataManipulator;
            }
        }
    }
}