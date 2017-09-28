namespace PUBGstats.ViewModel
{
  public interface ITabViewModel
  {
    string Header { get; }
    IViewModelBase Content { get; }
  }
}