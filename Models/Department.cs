using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "The department name can only contain Norwegian alphabets and white space.")]
        [Required(ErrorMessage = "Please enter Department Name.")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
