using EMP.BusinessEntity;
using EMP.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.BusinessUtil
{
    public class EmployeeUtil
    {
        UnitOfWork<Employee> unitOfWork = null;

        public EmployeeUtil()
        {
            unitOfWork = new UnitOfWork<Employee>();
        }

        public List<Employee> GetListOfEmployee()
        {
            var list = unitOfWork.Repository.GetWithInclude(e => e.DepartmentId > 0, new string[] { "Department", "MaritalStatus" }).ToList();
            return list;
        }

        public Employee GetEmployeeById(int Id)
        {
            var emp = unitOfWork.Repository.GetWithInclude(e => e.Id == Id, new string[] { "Department", "MaritalStatus" }).FirstOrDefault();
            return emp;
        }

        public string Insert(Employee emp)
        {
            string result = string.Empty;
            unitOfWork.Repository.Insert(emp);
            unitOfWork.Save();
            return result;
        }

        public string Update(Employee emp)
        {
            string result = string.Empty;
            unitOfWork.Repository.Update(emp);
            unitOfWork.Save();
            return result;
        }

        public string Delete(int id)
        {
            string result = string.Empty;
            var emp = unitOfWork.Repository.GetById(id);
            unitOfWork.Repository.Delete(emp);
            unitOfWork.Save();
            return result;
        }
    }
}
