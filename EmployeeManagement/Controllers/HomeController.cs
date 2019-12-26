using EMP.BusinessEntity;
using EMP.BusinessUtil;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        EmployeeUtil empUtil = null;
        DepartmentUtil deptUtil = null;
        MaritalStatusUtil statusUtil = null;

        public HomeController()
        {
            empUtil = new EmployeeUtil();
            deptUtil = new DepartmentUtil();
            statusUtil = new MaritalStatusUtil();                
        }

        private void InitialiseView()
        {
            var deptList = deptUtil.GetListOfDepartment();            
            var statusList = statusUtil.GetListOfStatus();

            ViewBag.Departments = deptList;
            ViewBag.Status = statusList;
        }

        public ActionResult Index()
        {
            var list = empUtil.GetListOfEmployee();
            return View(list);
        }

        [HttpPost]
        public ActionResult InsertUpdate(Employee employee)
        {
            if (ModelState.IsValid)
            {
                string result = employee.Id == 0 ? empUtil.Insert(employee) : empUtil.Update(employee);

                if (!string.IsNullOrEmpty(result))
                    ModelState.AddModelError("Error", result);
                else
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult LoadInsertUpdate(int Id)
        {
            InitialiseView();
            if (Id == 0)
                return PartialView("_InsertUpdate", new Employee());

            var emp = empUtil.GetEmployeeById(Id);
            return PartialView("_InsertUpdate", emp);
        }

        public ActionResult Delete(int Id)
        {
            string result = string.Empty;

            if (Id != 0)
                result = empUtil.Delete(Id);

            if (!string.IsNullOrEmpty(result))
                ModelState.AddModelError("Error", result);
            else
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
    }
}