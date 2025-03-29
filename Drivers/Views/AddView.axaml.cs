using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Drivers.Classes;
using Drivers.Data;
using Drivers.Views;
using MsBox.Avalonia;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Drivers;

public partial class AddView : UserControl
{
    int _id = -1;
    public AddView(int id = -1)
    {
        InitializeComponent();

        _id = id;
        if (_id == -1)
        {
            MainSp.DataContext = new Driver() { Photo = new Photo() };
        }
        else
        {
            var driver = Help.Db.Drivers.First(el => el.Id == _id);
            MainSp.DataContext = driver;
            using (var ms = new MemoryStream(driver.Photo.Photo1))
            {
                DriverPhoto.Source = new Bitmap(ms);
            }

            MainSp.IsEnabled = false;
            AddBtn.IsVisible = false;
            
        }
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            Title = "Open image file",
            AllowMultiple = false,
            FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
        });

        if (file.Count() > 0)
        {
            var driver = MainSp.DataContext as Driver;
            driver.Photo.Photo1 = File.ReadAllBytes(file[0].Path.LocalPath);
            DriverPhoto.Source = new Bitmap(file[0].Path.LocalPath);
        }
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            Regex regPhone = new Regex(@"\+7\(\d\d\d\)\d\d\d-\d\d\d\d");
            if (!regPhone.IsMatch(PhoneTb.Text))
            {
                await MessageBoxManager.GetMessageBoxStandard("Error", "Телефоннный номер указан не по формату",
                    MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                return;
            }

            Regex regEmail = new Regex("[^@]+@[^@]+");
            if (!regEmail.IsMatch(EmailTb.Text))
            {
                await MessageBoxManager.GetMessageBoxStandard("Error", "Почта указана не по формату",
                    MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                return;
            }

            if (_id == -1)
            {
                Help.Db.Drivers.Add(MainSp.DataContext as Driver);
            }
            Help.Db.SaveChanges();
            Help.MainCC.Content = new MainView();
        }
        catch
        {
            await MessageBoxManager.GetMessageBoxStandard("Error", "Заполнены не все данные",
                    MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
        }
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Help.MainCC.Content = new MainView();
    }
}