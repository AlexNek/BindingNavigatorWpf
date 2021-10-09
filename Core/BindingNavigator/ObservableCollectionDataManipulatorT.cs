using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BindingNavigator.NetCore
{
    /// <summary>
    /// Class ObservableCollectionDataManipulator.
    /// Implements the <see cref="IViewDataManipulator" />
    /// </summary>
    /// <typeparam name="T">data item type</typeparam>
    /// <seealso cref="IViewDataManipulator" />
    public class ObservableCollectionDataManipulator<T> : IViewDataManipulator
    {
        /// <summary>
        /// Occurs when selection/selected view position changed.
        /// </summary>
        public event EventHandler<int?> SelectionChanged;

        /// <summary>
        /// Occurs when data items count changed.
        /// </summary>
        public event EventHandler<int> CountChanged;

        /// <summary>
        /// The data collection for the view
        /// </summary>
        private readonly ObservableCollection<T> mDataView;

        /// <summary>
        /// The data changer implementation
        /// </summary>
        private readonly IDataChanger mDataChanger;

        /// <summary>
        /// The current position. Null if not set
        /// </summary>
        private int? mCurrent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableCollectionDataManipulator{T}"/> class.
        /// </summary>
        /// <param name="dataView">The data view.</param>
        /// <param name="dataChanger">The data changer implementation.</param>
        /// <exception cref="ArgumentNullException">dataView</exception>
        public ObservableCollectionDataManipulator(ObservableCollection<T> dataView, IDataChanger dataChanger)
        {
            mDataView = dataView ?? throw new ArgumentNullException(nameof(dataView));
            mDataChanger = dataChanger;
            dataView.CollectionChanged += DataView_CollectionChanged;
        }

        /// <summary>
        /// Move to the first item. [0]
        /// </summary>
        public void First()
        {
            if (CanFirst)
            {
                mCurrent = 0;
                OnSelectionChanged(mCurrent.Value);
            }
        }

        /// <summary>
        /// Move to the last item. [count - 1]
        /// </summary>
        public void Last()
        {
            if (CanLast)
            {
                mCurrent = mDataView.Count - 1;
                OnSelectionChanged(mCurrent.Value);
            }
        }

        /// <summary>
        /// Move to the next item. i + 1
        /// </summary>
        public void Next()
        {
            if (CanNext)
            {
                if (mCurrent.HasValue)
                {
                    mCurrent++;
                    OnSelectionChanged(mCurrent.Value);
                }
            }
        }

        /// <summary>
        /// Move to the previous item. i - 1
        /// </summary>
        public void Prev()
        {
            if (CanPrev)
            {
                if (mCurrent.HasValue)
                {
                    mCurrent--;
                    OnSelectionChanged(mCurrent.Value);
                }
            }
        }

        /// <summary>
        /// Move to absolute position.
        /// </summary>
        /// <param name="pos">The position.</param>
        public void ToAbsolutePosition(int pos)
        {
            //if( mCurrent != pos)
            if (pos >= 0)
            {
                mCurrent = pos;
                OnSelectionChanged(mCurrent.Value);
            }
            else
            {
                mCurrent = null;
                OnSelectionChanged(-1);
            }
        }

        /// <summary>
        /// Called when items count changed.
        /// </summary>
        /// <param name="count">The count.</param>
        protected virtual void OnCountChanged(int count)
        {
            CountChanged?.Invoke(this, count);
            if (Current >= count)
            {
                ToAbsolutePosition(count - 1);
            }
        }

        /// <summary>
        /// Called when selection changed.
        /// </summary>
        /// <param name="position">The selected position.</param>
        protected virtual void OnSelectionChanged(int position)
        {
            SelectionChanged?.Invoke(this, position);
        }

        /// <summary>
        /// Handles the CollectionChanged event of the data collection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void DataView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove
                                                              || e.Action == NotifyCollectionChangedAction.Reset)
            {
                OnCountChanged(mDataView.Count);
            }
        }

        /// <summary>
        /// Gets a value indicating whether current selected item can be deleted.
        /// </summary>
        /// <value><c>true</c> if this instance can delete; otherwise, <c>false</c>.</value>
        public bool CanDelete
        {
            get
            {
                return mDataView.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the first item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        public bool CanFirst
        {
            get
            {
                return (!mCurrent.HasValue || mCurrent > 0) && mDataView.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the last item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        public bool CanLast
        {
            get
            {
                return (!mCurrent.HasValue || mCurrent < mDataView.Count - 1) && mDataView.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the next item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        public bool CanNext
        {
            get
            {
                return mCurrent.HasValue && mCurrent < mDataView.Count - 1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether current selected item can be move to the previous item
        /// </summary>
        /// <value><c>true</c> if moving is possible; otherwise, <c>false</c>.</value>
        public bool CanPrev
        {
            get
            {
                return mCurrent.HasValue && mCurrent > 0;
            }
        }

        /// <summary>
        /// Gets the current/selected item position.
        /// </summary>
        /// <value>The current.</value>
        public int? Current
        {
            get
            {
                return mCurrent;
            }
        }

        /// <summary>
        /// Gets the get data changer interface implementation
        /// </summary>
        /// <value>The get data changer.</value>
        public IDataChanger GetDataChanger
        {
            get
            {
                return mDataChanger;
            }
        }
    }
}