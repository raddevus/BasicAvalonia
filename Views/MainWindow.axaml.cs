using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BasicAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        System.Console.WriteLine($"Click! Celsius={Celsius.Text}");
    }
}
