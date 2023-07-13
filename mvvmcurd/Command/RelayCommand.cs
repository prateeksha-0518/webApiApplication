using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvmcurd.Command
{
    public class RelayCommand : ICommand
    {    
      private Action DoWork;
     public RelayCommand(Action work)
        {
            DoWork = work;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            DoWork();
        }
    }
}


