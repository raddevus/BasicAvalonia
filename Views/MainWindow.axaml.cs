using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using System.IO;

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
       var msg = new MessageBox("Do you want to continue?");
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

    private async void OpenFileButton_Clicked(object sender, RoutedEventArgs args)
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        if (files.Count >= 1)
        {
            // Open reading stream from the first file.
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // Reads all the content of file as a text.
            var fileContent = await streamReader.ReadToEndAsync();
	    System.Console.WriteLine($"{fileContent}");
        }
    }

}
