using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMP.BusinessEntity
{
    public class Employee : BaseSchema
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Display(Name = "Marital Status")]
        [ForeignKey("MaritalStatus")]
        public int MaritalStatusId { get; set; }    

        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        public double Salary { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
