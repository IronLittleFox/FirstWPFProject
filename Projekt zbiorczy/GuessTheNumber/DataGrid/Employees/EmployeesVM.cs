using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DataGrid.Employees
{
    public class EmployeesVM : ViewModelBase
    {
        private Model.Employees employeesModel;

        public EmployeesVM()
        {
            employeesModel = new Model.Employees();
            employeesModel.GenerateEmployees();
        }

        public ObservableCollection<Model.Employee> ListOfEmployees
        {
            get
            {
                return employeesModel.employees;
            }
            set
            {
                employeesModel.employees = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand addDefaultEmployee;

        public RelayCommand AddDefaultEmployee
        {
            get
            {
                return addDefaultEmployee
                    ?? (addDefaultEmployee = new RelayCommand(
                    () =>
                    {
                        Model.Employee employee = new Model.Employee
                        {
                            ID = 7,
                            name = "Nowy",
                            position = "Pracownik",
                            adress = "-------"
                        };
                        employeesModel.employees.Add(employee);
                        //RaisePropertyChanged(nameof(ListOfEmployees));
                    }));
            }
        }
    }
}
