using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

using BasicAvalonia.Views;
using BasicAvalonia.Models;
using BasicAvalonia.Services;

namespace BasicAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   private readonly IPokeService pokeService;
   [ObservableProperty] private PokeData? data;
    public string Greeting { get; } = "Welcome to Avalonia!";
    private DocumentWindow singleWin;
    private bool shouldCancel = true;

    public MainWindowViewModel(IPokeService svc){
         pokeService = svc;
    }

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

   [RelayCommand]
   private async Task LoadDataAsync() {
      System.Console.WriteLine("LoadDataAsync...");
      Data = await pokeService.GetDataAsync();
      System.Console.WriteLine($"{Data}");
   }

    public void OnWindowClosed()
    {
       System.Console.WriteLine("Closing...");
       if (singleWin != null){
          shouldCancel = false;
          singleWin.Close();
          singleWin = null;
       }
    }
}
