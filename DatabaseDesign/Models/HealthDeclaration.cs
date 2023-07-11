using System.ComponentModel.DataAnnotations;

namespace DatabaseDesign.Models
{
    public class HealthDeclaration
    {

//        Name string
//BusinessEmail string
//CompanyName string
//Designation string
//BusinessNumber int
//LicensePlate string
//NRIC string
//QuarantineOrder bool
//CloseContact bool
//Fever bool
//Agreement bool

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? BusinessEmail { get; set; }

        [Required]
        public string? CompanyName { get; set; }
        public string? Designation { get; set;  }
        [Required]
        public int? BusinessNumber { get; set; }
        public string? LicensePlate { get; set; }

        public string? NRIC { get; set;}
        public bool? QuarantineOrder { get; set; }
        public bool? CloseContact { get; set; }

        public bool? Fever { get; set;}
        public string ? Agreement { get; set;}
    }
}
