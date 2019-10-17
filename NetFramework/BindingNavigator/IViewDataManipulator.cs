using System;

namespace BindingNavigator
{
    public interface IViewDataManipulator
    {
        event EventHandler<int?> SelectionChanged;

        event EventHandler<int> CountChanged;

        void First();

        void Last();

        void Next();

        void Prev();

        void ToAbsolutePosition(int pos);

        bool CanDelete { get; }

        bool CanFirst { get; }

        bool CanLast { get; }

        bool CanNext { get; }

        bool CanPrev { get; }

        int? Current { get; }

        IDataChanger GetDataChanger { get; }
    }
}