using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using BindingNavigator.NetCore.Commands;

namespace BindingNavigator.NetCore.ViewModel
{
    public class BindingNavigatorViewModel : INotifyPropertyChanged
    {
        private enum ECommandId : byte
        {
            NullRecord = 0,

            NextRecord = 1,

            PreviousRecord = 2,

            FirstRecord = 3,

            LastRecord = 4,

            GoToRecord = 5,

            AddRecord = 6,

            Save = 7,

            DeleteRecord = 8
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly NavigatorCommand[] mCachedCommands =
            new NavigatorCommand[Enum.GetNames(typeof(ECommandId)).Length];

        private readonly object mSyncRoot = new object();

        private readonly IViewDataManipulator mViewDataManipulator;

        private int? mCurrentPosition;

        private int mDataCount;

        private bool mVisibilityAdd = true;

        public BindingNavigatorViewModel(IViewDataManipulator viewDataManipulator)
        {
            mViewDataManipulator = viewDataManipulator;
            mViewDataManipulator.SelectionChanged += OnSelectionChanged;
            mViewDataManipulator.CountChanged += OnCountChanged;
        }

        private void OnCountChanged(object sender, int count)
        {
            DataCount = count;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand EnsureCommand(ECommandId idCommand)
        {
            NavigatorCommand command = null;
            lock (mSyncRoot)
            {
                command = mCachedCommands[(int)idCommand];
                if (command == null)
                {
                    switch (idCommand)
                    {
                        case ECommandId.NullRecord:
                            break;
                        case ECommandId.NextRecord:
                            command = new NextItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.PreviousRecord:
                            command = new PrevItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.FirstRecord:
                            command = new FirstItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.LastRecord:
                            command = new LastItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.GoToRecord:
                            break;
                        case ECommandId.AddRecord:
                            command = new AddItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.Save:
                            command = new SaveItemCommand(mViewDataManipulator);
                            break;
                        case ECommandId.DeleteRecord:
                            command = new DeleteItemCommand(mViewDataManipulator);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(idCommand), idCommand, null);
                    }

                    if (command != null)
                    {
                        mCachedCommands[(int)idCommand] = command;
                    }
                }
            }

            return command;
        }

        private void OnSelectionChanged(object sender, int? newSelection)
        {
            CurrentPosition = newSelection;
        }

        public ICommand CommandAddRecord
        {
            get
            {
                return EnsureCommand(ECommandId.AddRecord);
            }
        }

        public ICommand CommandDeleteRecord
        {
            get
            {
                return EnsureCommand(ECommandId.DeleteRecord);
            }
        }

        public ICommand CommandFirstRecord
        {
            get
            {
                return EnsureCommand(ECommandId.FirstRecord);
            }
        }

        public ICommand CommandGoToRecord
        {
            get
            {
                return EnsureCommand(ECommandId.GoToRecord);
            }
        }

        public ICommand CommandLastRecord
        {
            get
            {
                return EnsureCommand(ECommandId.LastRecord);
            }
        }

        public ICommand CommandNextRecord
        {
            get
            {
                return EnsureCommand(ECommandId.NextRecord);
            }
        }

        public ICommand CommandPreviousRecord
        {
            get
            {
                return EnsureCommand(ECommandId.PreviousRecord);
            }
        }

        public ICommand CommandSave
        {
            get
            {
                return EnsureCommand(ECommandId.Save);
            }
        }

        public int? CurrentPosition
        {
            get
            {
                return mCurrentPosition;
            }
            set
            {
                if (mCurrentPosition != value)
                {
                    mCurrentPosition = value;
                    OnPropertyChanged();
                    if (mViewDataManipulator != null && mCurrentPosition != null)
                    {
                        mViewDataManipulator.ToAbsolutePosition(mCurrentPosition.Value);
                    }
                }
            }
        }

        public int DataCount
        {
            get
            {
                return mDataCount;
            }
            set
            {
                mDataCount = value;
                OnPropertyChanged();
            }
        }

        public bool VisibilityAdd
        {
            get
            {
                return mVisibilityAdd;
            }
            set
            {
                mVisibilityAdd = value;
                OnPropertyChanged();
            }
        }
    }
}