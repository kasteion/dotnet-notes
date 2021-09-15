using Prism.Ioc;
using Prism.Unity;
using PrismGettingStarted.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismGettingStarted
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Services here
            //throw new NotImplementedException();
            containerRegistry.Register<Services.ICustomerStore, Services.DBCustomerStore>();
            // Other services
        }

        protected override Window CreateShell()
        {
            //throw new NotImplementedException();
            var w = Container.Resolve<MainWindow>();
            return w;
        }
    }
}
