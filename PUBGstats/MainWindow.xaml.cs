using System.Windows;
using PUBGstats.ViewModel;

namespace PUBGstats
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainWindowViewModel();
    }

    private void ShowAddPopupButton_OnClick(object sender, RoutedEventArgs e)
    {
      AddPopup.IsOpen = true;
    }
  }
}
