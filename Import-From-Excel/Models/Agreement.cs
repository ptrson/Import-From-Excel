using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Import_From_Excel.Models
{
    public class Agreement
    {
        [Key]
        public int AgreementId { get; set; }

        [StringLength(3000)]
        [Required]
        [Display(Name = "Numer")]
        public string Number { get; set; }        

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int FinancialStateId { get; set; }
        public FinancialState FinancialState { get; set; }
    }
}