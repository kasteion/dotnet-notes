using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfPersona.Conection;

namespace WpfPersona
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DBConection _connection = new DBConection();

        public static DBConection Connection
        {
            get { return App._connection; }
        }
    }
}
