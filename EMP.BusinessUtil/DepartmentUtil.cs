using EMP.BusinessEntity;
using EMP.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.BusinessUtil
{
    public class DepartmentUtil
    {

        UnitOfWork<Department> unitOfWork = null;

        public DepartmentUtil()
        {
            unitOfWork = new UnitOfWork<Department>();
        }

        public List<Department> GetListOfDepartment()
        {
            var list = unitOfWork.Repository.GetAll().ToList();
            return list;
        }
    }
}
