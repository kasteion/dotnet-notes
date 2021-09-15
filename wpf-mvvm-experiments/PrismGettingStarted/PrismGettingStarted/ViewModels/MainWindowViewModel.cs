using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismGettingStarted.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private Services.ICustomerStore _customerStore = null;

        public MainWindowViewModel(Services.ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }

        public ObservableCollection<string> Customers { get; private set; } = new ObservableCollection<string>();

        private string _selectedCustomer;

        public string SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { 
                if (SetProperty<string>(ref _selectedCustomer, value)) 
                {
                    Debug.WriteLine(_selectedCustomer ?? "No customer selected");
                } 
            }
        }

        private DelegateCommand _commandLoad = null;
        public DelegateCommand CommandLoad => _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));

        private void CommandLoadExecute()
        {
            Customers.Clear();
            var list = _customerStore.GetAll();
            foreach(string item in list)
            {
                Customers.Add(item);
            }
        }
    }
}
