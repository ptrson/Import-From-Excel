using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Import_From_Excel.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [StringLength(300)]
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [StringLength(300)]
        [Display(Name = "Drugie imię")]
        public string SecondName { get; set; }

        [StringLength(300)]
        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [StringLength(300)]
        [Required]
        [Display(Name = "PESEL")]
        [RegularExpression("[0-9]", ErrorMessage = "PESEL może składać się tylko z cyfr")]
        public string NationalIdentificationNumber { get; set; }

        [StringLength(300)]
        [Required]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        [Required]
        [Display(Name = "Telefon 2")]
        public string PhoneNumber2 { get; set; }

        public virtual ICollection<Agreement> Agreements { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}