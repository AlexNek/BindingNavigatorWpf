using System;

namespace BindingNavigator
{
    public interface IDataChanger
    {
        //event EventHandler<int> CountChanged;

        object AddNew();

        void Delete(int viewPosition);

        void Save();
    }
}