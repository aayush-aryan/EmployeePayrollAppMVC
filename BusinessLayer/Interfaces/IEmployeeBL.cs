using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public interface IEmployeeBL
    {
        public string AddEmployee(EmployeeModel emp);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public string DeleteEmployee(int? id);
        public string UpdateEmployee(EmployeeModel emp);
    }
}
