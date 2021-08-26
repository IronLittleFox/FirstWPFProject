using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DataGrid.Employees.Model
{
    public class Employees
    {
        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public void GenerateEmployees()
        {
            Employee employee = new Employee
            {
                ID = 1,
                name = "Kowalski",
                position = "Kierownik",
                adress = "ul. Majowa 5"
            };
            employees.Add(employee);

            employee = new Employee
            {
                ID = 2,
                name = "Nowak",
                position = "Dyrektor",
                adress = "ul. Kwiatowa 77"
            };
            employees.Add(employee);

            employee = new Employee
            {
                ID = 3,
                name = "Nieznany",
                position = "Prezes",
                adress = "ul. Lipcowa 2"
            };
            employees.Add(employee);
        }
    }
}
