using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Mvvm.ViewModels.Commands
{
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// The execution status logic.
        /// </summary>
        private Func<object, bool> _canExecute;
        /// <summary>
        /// The execution logic.
        /// </summary>
        private Action<object> _executeAction;
        bool canExecuteCache;

        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, null)
        {

        }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this._executeAction = executeAction;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            bool temp = _canExecute(parameter);

            if (canExecuteCache != temp)
            {
                canExecuteCache = temp;

                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }

            return canExecuteCache;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeAction.Invoke(parameter);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var canExecuteChanged = CanExecuteChanged;

            if (canExecuteChanged != null)
            {
                canExecuteChanged(this, e);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }
    }
}