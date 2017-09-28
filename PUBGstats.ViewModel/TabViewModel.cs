namespace PUBGstats.ViewModel
{
  public class TabViewModel : ViewModelBase, ITabViewModel
  {
    public TabViewModel(IViewModelBase content, string header)
    {
      Content = content;
      Header = header;
    }

    public string Header { get; }
    public IViewModelBase Content { get; }
  }
}