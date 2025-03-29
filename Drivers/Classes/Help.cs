using Avalonia.Controls;
using Drivers.Data;
using Drivers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Classes
{
    public static class Help
    {
        public static MainWindow MainWnd;
        public static ContentControl MainCC;
        public static GaiContext Db = new GaiContext();
    }
}
