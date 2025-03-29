using Avalonia.Controls;
using Drivers.Classes;
using Drivers.Data;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using System.Linq;

namespace Drivers.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        loadData();
    }

    private void loadData()
    {
        Help.Db.Drivers.Load();
        Help.Db.Photos.Load();
        DriversDG.ItemsSource = Help.Db.Drivers.ToList();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Help.MainCC.Content = new AddView();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selected = DriversDG.SelectedItem as Driver;

        if (selected != null)
        {
            Help.MainCC.Content = new AddView(selected.Id);
        }
    }

    private async void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selected = DriversDG.SelectedItem as Driver;

        if (selected != null)
        {
            var res = await MessageBoxManager.GetMessageBoxStandard("Удаление", "Вы уверены?",
                MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Question).ShowAsync();
            if (res == MsBox.Avalonia.Enums.ButtonResult.Yes)
            {
                Help.Db.Drivers.Remove(selected);
                Help.Db.SaveChanges();
                Help.MainCC.Content = new MainView();
            }
        }
    }
}
