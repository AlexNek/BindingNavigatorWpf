using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetCore.Demo.Common
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}