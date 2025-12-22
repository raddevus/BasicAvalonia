using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BasicAvalonia.Views;

namespace BasicAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    private DocumentWindow singleWin;
    [RelayCommand]
    private void OpenNewWindow()
    {
        var win = new DocumentWindow
        {
            DataContext = new DocumentViewModel()
        };

        win.Show();   // non-modal
    }

    [RelayCommand]
    private void OpenStaticWindow(){
         if (singleWin == null){
            singleWin = new DocumentWindow();
            singleWin.Closing += (s, e) =>
            {
                ((DocumentWindow)s).Hide();
                e.Cancel = true;
            };
         }
         
         singleWin.Show();
    }
}
