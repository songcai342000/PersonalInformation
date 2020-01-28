using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
    public class FullPersonInfor
    {
        public string Name { get; set; }
        public string Mobil { get; set; }
        public string Street { get; set; }
        public string Streetnumber { get; set; }
        public string Postnumber { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }

    }
}
