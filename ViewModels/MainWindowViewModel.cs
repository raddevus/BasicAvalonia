using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BasicAvalonia.Views;

namespace BasicAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    private DocumentWindow singleWin;
    private bool shouldCancel = true;
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
                e.Cancel = shouldCancel;
            };
         }
         
         singleWin.Show();
    }

    public void OnWindowClosed()
    {
       System.Console.WriteLine("Closing...");
       shouldCancel = false;
       singleWin.Close();
       singleWin = null;
    }
}
