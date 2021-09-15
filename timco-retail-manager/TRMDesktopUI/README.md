# TRMWPFUserInterface

New WPF App .NET Framewor 4.7.2 Project

- Right Click -- Properties -- Change Assembly Name

## Add Caliburn.Micro

- Right Click -- Manage NuGet Package
- Search for Caliburn.Micro & Install

## Structure

1) Create Models, Views And ViewModels directories.
2) Create a class `ViewModels/ShellViewModel.cs`

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel
    {
    }
}

```

3) Create a Windws(WPF) `Views/ShellView.xaml`
4) Create a class `./Bootstrapper.cs`

```cs
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // The ViewModel lauchs the View...
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
```

5) Delete from App.xaml

```
StartupUri="MainWindow.xaml"
```

6) And add to App.xaml

```
<Application x:Class="TRMDesktopUI.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:TRMDesktopUI">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <local:Bootstrapper x:Key="Bootstrapper" />
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

7) Delete MainWindow.xaml

## Dependency Injections in WPF

On Bootstrapper.cs

```cs
private SimpleContainer _container = new SimpleContainer();

protected override void Configure()
{
    _container.Instance(_container);
    _container
        .Singleton<IWindowManager, WindowManager>()
        .Singleton<IEventAggregator, EventAggregator>();

    GetType().Assembly.GetTypes()
        .Where(type => type.IsClass)
        .Where(type => type.Name.EndsWith("ViewModel"))
        .ToList()
        .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
}

protected override object GetInstance(Type service, string key)
{
    return _container.GetInstance(service, key);
}

protected override IEnumerable<object> GetAllInstances(Type service)
{
    return _container.GetAllInstances(service);
}

protected override void BuildUp(object instance)
{
    _container.BuildUp(instance);
}
```

Then how to add a class with DI? We can...

Create a class Calculations.cs

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI
{
    public class Calculations
    {
        public List<string> Register { get; set; } = new List<string>();

        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
```

And if we select the class name (Calculations) and press Ctrl + . --> Extract Interface for Visual Studio to create our interface and make this new class an implementation of our interface.

Then in Bootstrapper.cs

```cs
protected override void Configure()
        {
            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            // Here we can register our interface and class PerRequest
            _container
                .PerRequest<ICalculations, Calculations>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }
```

And use DI in our ShellViewModel.cs

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel
    {
        private ICalculations _calculations;

        public ShellViewModel(ICalculations calculations)
        {
            _calculations = calculations;
        }
    }
}
```

## WPF Login form Creation

One view at a time inside the ShellView...

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Caliburn.Micro
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    // Inherits from Conductor
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;

        // Dependency Injection LoginViewModel
        public ShellViewModel(LoginViewModel loginVM)
        {
            _loginVM = loginVM;
            ActivateItemAsync(_loginVM);
        }
    }
}
```