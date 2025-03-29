using Avalonia.Controls;
using Drivers.Classes;

namespace Drivers.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.MainCC = MainCC;
        Help.MainWnd = this;
        Help.MainCC.Content = new AuthView();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}
