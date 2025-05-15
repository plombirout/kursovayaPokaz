using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace kursovayaPokaz.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;

        }

        private bool _Executable = true;
        public bool Executable
        {
            get => _Executable;
            set
            {
                if (_Executable == value)
                {
                    _Executable = value;
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public static void Refresh()
        {
            Application.Current.Dispatcher.Invoke(() => CommandManager.InvalidateRequerySuggested());
        }

        bool ICommand.CanExecute(object? parameter) => _Executable && CanExecute(parameter);
        void ICommand.Execute(object? parameter)
        {
            if (CanExecute(parameter))
                Execute(parameter);
        }

        protected virtual bool CanExecute(object parameter) => true;
        protected abstract void Execute(object parameter);

    }
}