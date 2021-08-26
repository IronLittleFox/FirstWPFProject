using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DataGrid.Person.Model
{
    public class Persons
    {
        public ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public void GeneratePersons()
        {
            Person person = new Person
            {
                Id = 1,
                Name = "Kowalski"
            };
            Adress Adress = new Adress
            {
                Street = "Majowa",
                Number = "5"
            };
            person.Adress = new ObservableCollection<Adress>();
            person.Adress.Add(Adress);
            persons.Add(person);

            person = new Person
            {
                Id = 2,
                Name = "Nowak"
            };
            Adress = new Adress
            {
                Street = "Kwiatowa",
                Number = "77"
            };
            person.Adress = new ObservableCollection<Adress>();
            person.Adress.Add(Adress);
            persons.Add(person);

            person = new Person
            {
                Id = 3,
                Name = "Nieznany",
            };
            Adress = new Adress
            {
                Street = "Lipcowa",
                Number = "2"
            };
            person.Adress = new ObservableCollection<Adress>();
            person.Adress.Add(Adress);
            persons.Add(person);
        }
    }
}
