using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BasicAvalonia.Views;

public partial class MessageBox : Window
{
   public MessageBox(): this("default message") {
   }
    public MessageBox(string message)
    {
        InitializeComponent();
        MessageText.Text = message;
    }

    private void Ok_Click(object? sender, RoutedEventArgs e)
    {
        Close(true);
    }

    private void Cancel_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}

