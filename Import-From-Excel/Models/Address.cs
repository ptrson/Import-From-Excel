using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Import_From_Excel.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Nazwa ulicy")]
        public string StreetName { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Nr budynku")]
        public string StreetNumber { get; set; }

        [StringLength(300)]
        [Display(Name = "Nr lokalu")]
        public string FlatNumber { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Kod Pocztowy")]
        public string PostCode { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Miasto")]
        public string PostOfficeCity { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Nazwa ulicy koresp")]
        public string CorrespondenceStreetName { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Nr budynku koresp")]
        public string CorrespondenceStreetnumber { get; set; }

        [StringLength(300)]
        [Display(Name = "Nr lokalu koresp")]
        public string CorrespondenceFlatNumber { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Kod pocztowy koresp")]
        public string CorrespondencePostCode { get; set; }

        [StringLength(300)]
        //[Required]
        [Display(Name = "Miasto koresp")]
        public string CorrespondencePostOfficeCity { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}