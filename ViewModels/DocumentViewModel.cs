using CommunityToolkit.Mvvm.ComponentModel;
namespace BasicAvalonia.ViewModels;
public partial class DocumentViewModel : ObservableObject
{
    [ObservableProperty]
    private string message = "Hello from the document window!";
}

