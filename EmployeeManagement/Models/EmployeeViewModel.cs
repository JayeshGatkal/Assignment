using EMP.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string MaritalStatus { get; set; }

        public double Salary { get; set; }

        public string Location { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}