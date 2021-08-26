using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DataGrid.Person.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Adress> Adress { get; set; }
    }
}
