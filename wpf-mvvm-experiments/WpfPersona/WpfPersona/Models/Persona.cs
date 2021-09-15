using System;
using System.Collections.ObjectModel;

namespace WpfPersona.Models
{
    public class PersonaCollection: ObservableCollection<Persona>
    {

    }
    public class Persona
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private DateTime _birthday;

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public Persona()
        {

        }

        public Persona(int id, string name, DateTime birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday; 
        }
    }
}
