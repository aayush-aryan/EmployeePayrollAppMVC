using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Profileimage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
