using EMP.BusinessEntity;
using EMP.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.BusinessUtil
{
    public class MaritalStatusUtil
    {
        UnitOfWork<MaritalStatus> unitOfWork = null;

        public MaritalStatusUtil()
        {
            unitOfWork = new UnitOfWork<MaritalStatus>();
        }

        public List<MaritalStatus> GetListOfStatus()
        {
            var list = unitOfWork.Repository.GetAll().ToList();
            return list;
        }
    }
}
