using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BasicAvalonia.Views;

namespace BasicAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private void OpenNewWindow()
    {
        var win = new DocumentWindow
        {
            DataContext = new DocumentViewModel()
        };

        win.Show();   // non-modal
    }
}
