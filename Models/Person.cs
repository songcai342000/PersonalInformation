using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "The mobil number is not in correct format.")]
        [Required(ErrorMessage = "Please enter Mobil number.")]
        public string Mobil { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "The given name is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Name { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "The street name is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Street { get; set; }

        [RegularExpression(@"^[0-9]+[0-9a-zA-Z\s]+$", ErrorMessage = "The street number is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Streetnumber { get; set; }

        [StringLength(10, MinimumLength = 2)]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "The post number is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Postnumber { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "The city name is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string City { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZåÅøæÆØ\s]*$", ErrorMessage = "Only alphabet and white space are allowed.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Province { get; set; }

        [StringLength(30)]
        [RegularExpression(@"^([a-z0-9A-Z_]+@([a-z0-9A-Z])+[a-z0-9A-Z_-]+[a-z0-9A-Z](\.)+[a-zA-Z]{2,})$", ErrorMessage = "The email address is not in correct format.")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }

    }
}
