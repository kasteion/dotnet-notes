using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPersona.Core;
using WpfPersona.Core.Commands;
using WpfPersona.Models;

namespace WpfPersona.ViewModels
{
    public class PersonaViewModel : Link
    {
        private PersonaCollection _listaPersonas = new PersonaCollection();

        public PersonaCollection ListaPersonas
        {
            get { return _listaPersonas; }
            set { 
                _listaPersonas = value;
                RaisePropertyChanged("ListaPersonas");
            }
        }

        private Persona _currentPersona;

        public Persona CurrentPersona
        {
            get { return _currentPersona; }
            set { 
                _currentPersona = value;
                RaisePropertyChanged("CurrentPersona");
            }
        }

        public PersonaViewModel()
        {

        }

        private ICommand _listarPersonasCommand;

        public ICommand ListarPersonasCommand
        {
            get 
            { 
                if (_listarPersonasCommand == null) 
                { 
                    _listarPersonasCommand = new RelayCommand(new Action(ListarPersonas)); 
                }
                return _listarPersonasCommand;
            }
        }

        private void ListarPersonas()
        {
            ListaPersonas = App.Connection.ListarPersonas();
        }

    }
}
