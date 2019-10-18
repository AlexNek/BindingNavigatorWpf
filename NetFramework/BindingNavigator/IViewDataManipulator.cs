using System;

namespace BindingNavigator
{
    /// <summary>
    /// Interface IViewDataManipulator
    /// Must implement navigation commands and storage of IDataChanger implementation
    /// </summary>
    public interface IViewDataManipulator
    {
        /// <summary>
        /// Occurs when selection/selected view position changed.
        /// </summary>
        event EventHandler<int?> SelectionChanged;

        /// <summary>
        /// Occurs when data items count changed.
        /// </summary>
        event EventHandler<int> CountChanged;

        /// <summary>
        /// Move to the first item. [0]
        /// </summary>
        void First();

        /// <summary>
        /// Move to the last item. [count - 1]
        /// </summary>
        void Last();

        /// <summary>
        /// Move to the next item. i + 1
        /// </summary>
        void Next();

        /// <summary>
        /// Move to the previous item. i - 1
        /// </summary>
        void Prev();

        /// <summary>
        /// Move to absolute position.
        /// </summary>
        /// <param name="pos">The position.</param>
        void ToAbsolutePosition(int pos);

        /// <summary>
        /// Gets a value indicating whether current selected item can be deleted.
        /// </summary>
        /// <value><c>true</c> if this instance can delete; otherwise, <c>false</c>.</value>
        bool CanDelete { get; }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the first item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        bool CanFirst { get; }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the last item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        bool CanLast { get; }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the next item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        bool CanNext { get; }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the previous item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        bool CanPrev { get; }

        /// <summary>
        /// Gets the current/selected item position.
        /// </summary>
        /// <value>The current.</value>
        int? Current { get; }

        /// <summary>
        /// Gets the get data changer interface implementation
        /// </summary>
        /// <value>The get data changer.</value>
        IDataChanger GetDataChanger { get; }
    }
}