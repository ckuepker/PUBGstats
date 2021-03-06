﻿using System.Windows.Input;

namespace PUBGstats.ViewModel.Command
{
  public interface IRelayCommand<T> : ICommand
  {
    bool CanExecute();
    void Execute();
  }
}
