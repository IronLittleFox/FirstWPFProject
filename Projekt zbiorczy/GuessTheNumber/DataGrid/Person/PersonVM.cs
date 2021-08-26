using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuessTheNumber.DataGrid.Person.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DataGrid.Person
{
    public class PersonVM : ViewModelBase
    {
        private readonly Persons personsModel;

        public PersonVM() : base()
        {
            //if (!ViewModelBase.IsInDesignModeStatic)
            {
                personsModel = new Persons();
                personsModel.GeneratePersons();
            }
        }

        public ObservableCollection<Model.Person> ListOfPersons
        {
            get
            {
                return personsModel.persons;
            }
            set
            {
                personsModel.persons = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged()
        {
            throw new NotImplementedException();
        }

        private RelayCommand addDefaultPerson;

        public RelayCommand AddDefaultPerson
        {
            get
            {
                return addDefaultPerson
                    ?? (addDefaultPerson = new RelayCommand(
                    () =>
                    {
                        Model.Person person = new Model.Person
                        {
                            Id = 7,
                            Name = "Nowy"
                        };
                        Adress Adress = new Adress
                        {
                                Street = "------",
                                Number = "-----"
                        };
                        person.Adress = new ObservableCollection<Adress>();
                        person.Adress.Add(Adress);
                        personsModel.persons.Add(person);
                        //RaisePropertyChanged(nameof(ListOfEmployees));
                    }));
            }
        }
    }
}
