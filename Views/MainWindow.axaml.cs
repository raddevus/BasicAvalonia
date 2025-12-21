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
       if (double.TryParse(Celsius.Text, out double C))
       {
           var F = C * (9d / 5d) + 32;
           Fahrenheit.Text = F.ToString("0.0");
       }
       else
       {
           Celsius.Text = "0";
           Fahrenheit.Text = "0";
       }
    }

    private async void OnAskQuestionClick(object? sender, RoutedEventArgs e){
       var msg = new MessageBox("Select a file?");
    bool result =  await msg.ShowDialog<bool>(this);

    if (result)
    {
        // User clicked OK
         System.Console.WriteLine("User selected OK");

    }
    else
    {
        // User clicked Cancel
        System.Console.WriteLine("User cancelled");
    }
    }

}
