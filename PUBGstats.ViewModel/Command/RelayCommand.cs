using System;

namespace PUBGstats.ViewModel.Command
{
  public class RelayCommand<T> : IRelayCommand<T>
  {
    private readonly Action<T> _execute;
    private readonly Predicate<T> _canExecute;

    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
      _execute = execute;
      _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
      _execute((T) parameter);
    }

    public event EventHandler CanExecuteChanged;
  }
}