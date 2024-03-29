﻿using System;
using System.Windows.Input;

namespace ColorPicker.Commands
{
    internal class RelayCommand<T> : ICommand
    {
        #region Properties
        public Predicate<T> CanExecuteDelegate { get; set; }
        public Action<T> ExecuteDelegate { get; set; }
        #endregion

        #region Public methods
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate != null ? CanExecuteDelegate((T)parameter) : true;
        }
        public void Execute(object parameter)
        {
            ExecuteDelegate((T)parameter);
        }
        #endregion
    }
}
