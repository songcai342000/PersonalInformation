using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "The name can only contain Norwegian alphabets and white space.")]
        [Required(ErrorMessage = "Please enter Department Name.")]
        public string PositionName { get; set; }
        public double SalaryAmount { get; set; }
        public ICollection<Person> People { get; set; }

    }
}
