using System.Windows.Input;

namespace WPF.Utils
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action execute;

        public RelayCommand(Action executeAction)
        {
            execute = executeAction;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute();
        }
    }
}
