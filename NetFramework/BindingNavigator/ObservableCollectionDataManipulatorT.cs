using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BindingNavigator
{
    public class ObservableCollectionDataManipulator<T> : IViewDataManipulator
    {
        public event EventHandler<int?> SelectionChanged;

        public event EventHandler<int> CountChanged;

        private readonly ObservableCollection<T> mDataView;

        private readonly IDataChanger mGetDataChanger;

        private int? mCurrent;

        public ObservableCollectionDataManipulator(ObservableCollection<T> dataView, IDataChanger getDataChanger)
        {
            mDataView = dataView ?? throw new ArgumentNullException(nameof(dataView));
            mGetDataChanger = getDataChanger;
            dataView.CollectionChanged += DataView_CollectionChanged;
        }

        public void First()
        {
            if (CanFirst)
            {
                mCurrent = 0;
                OnSelectionChanged(mCurrent.Value);
            }
        }

        public void Last()
        {
            if (CanLast)
            {
                mCurrent = mDataView.Count - 1;
                OnSelectionChanged(mCurrent.Value);
            }
        }

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

        protected virtual void OnCountChanged(int count)
        {
            CountChanged?.Invoke(this, count);
            if (Current >= count)
            {
                ToAbsolutePosition(count - 1);
            }
        }

        protected virtual void OnSelectionChanged(int position)
        {
            SelectionChanged?.Invoke(this, position);
        }

        private void DataView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove
                                                              || e.Action == NotifyCollectionChangedAction.Reset)
            {
                OnCountChanged(mDataView.Count);
            }
        }

        public bool CanDelete
        {
            get
            {
                return mDataView.Count > 0;
            }
        }

        public bool CanFirst
        {
            get
            {
                return (!mCurrent.HasValue || mCurrent > 0) && mDataView.Count > 0;
            }
        }

        public bool CanLast
        {
            get
            {
                return (!mCurrent.HasValue || mCurrent < mDataView.Count - 1) && mDataView.Count > 0;
            }
        }

        public bool CanNext
        {
            get
            {
                return mCurrent.HasValue && mCurrent < mDataView.Count - 1;
            }
        }

        public bool CanPrev
        {
            get
            {
                return mCurrent.HasValue && mCurrent > 0;
            }
        }

        public int? Current
        {
            get
            {
                return mCurrent;
            }
        }

        public IDataChanger GetDataChanger
        {
            get
            {
                return mGetDataChanger;
            }
        }
    }
}