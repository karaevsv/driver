using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Drivers.Classes;
using Drivers.Views;

namespace Drivers;

public partial class AuthView : UserControl
{
    public AuthView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (LoginTb.Text == "inspector" && PwdTb.Text == "inspector")
        {
            Help.MainCC.Content = new MainView();
        }
    }
}