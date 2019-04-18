using DddInPractice.Logic;
using DddInPractice.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DddInPractice.UI
{
    public class CommandInsertMoney : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly SnackMachineViewModel _snackMachineViewModel;
        private readonly Action _action;

        public CommandInsertMoney(SnackMachineViewModel snackMachineViewModel, Action action) {
            this._snackMachineViewModel = snackMachineViewModel;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
