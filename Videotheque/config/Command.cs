﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Videotheque.config
{
    class Command : ICommand
    {

            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public event EventHandler CanExecuteChanged;

            public Command(Action execute) : this(execute, null) { }

            public Command(Action execute, Func<bool> canExecute)
            {
                if (execute == null)
                {
                    throw new ArgumentNullException("execute");
                }

                _execute = execute;
                _canExecute = canExecute;
            }


            public void OnCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute();
            }

            public virtual void Execute(object parameter)
            {
                if (CanExecute(parameter) && _execute != null)
                {
                    _execute();
                }
            }
        }
    }