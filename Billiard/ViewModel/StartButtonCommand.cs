using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StartButtonCommand : ICommand
    {
        ViewModelApi buttonViewModel;
        bool flag = true;
        public StartButtonCommand(ViewModelApi viewModel)
        {
            buttonViewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return flag; // czy przycisk jest klikalny
        }

        public void Execute(object? parameter)
        {
            buttonViewModel.ButtonStartClick();
            flag = false;
        }
    }
}
