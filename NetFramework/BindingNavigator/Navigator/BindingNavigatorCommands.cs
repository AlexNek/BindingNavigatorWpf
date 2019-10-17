using System;
using System.Linq;
using System.Windows.Input;

namespace BindingNavigator.Navigator
{
    public static class BindingNavigatorCommands
    {
        private enum CommandId : byte
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

        private static readonly object mSyncRoot = new object();

        private static readonly RoutedUICommand[] mCachedCommands =
            new RoutedUICommand[Enum.GetNames(typeof(CommandId)).Count()];

        private static RoutedUICommand EnsureCommand(CommandId idCommand)
        {
            RoutedUICommand command = null;
            lock (mSyncRoot)
            {
                command = mCachedCommands[(int)idCommand];
                if (command == null)
                {
                    RoutedUICommand routedUiCommand = new RoutedUICommand(
                        Enum.GetName(typeof(CommandId), idCommand),
                        Enum.GetName(typeof(CommandId), idCommand),
                        typeof(BindingNavigatorCommands));
                    command = mCachedCommands[(int)idCommand] = routedUiCommand;
                }
            }

            return command;
        }

        public static RoutedUICommand AddRecord
        {
            get
            {
                return EnsureCommand(CommandId.AddRecord);
            }
        }

        public static RoutedUICommand DeleteRecord
        {
            get
            {
                return EnsureCommand(CommandId.DeleteRecord);
            }
        }

        public static RoutedUICommand FirstRecord
        {
            get
            {
                return EnsureCommand(CommandId.FirstRecord);
            }
        }

        public static RoutedUICommand GoToRecord
        {
            get
            {
                return EnsureCommand(CommandId.GoToRecord);
            }
        }

        public static RoutedUICommand LastRecord
        {
            get
            {
                return EnsureCommand(CommandId.LastRecord);
            }
        }

        public static RoutedUICommand NextRecord
        {
            get
            {
                return EnsureCommand(CommandId.NextRecord);
            }
        }

        public static RoutedUICommand PreviousRecord
        {
            get
            {
                return EnsureCommand(CommandId.PreviousRecord);
            }
        }

        public static RoutedUICommand Save
        {
            get
            {
                return EnsureCommand(CommandId.Save);
            }
        }
    }
}