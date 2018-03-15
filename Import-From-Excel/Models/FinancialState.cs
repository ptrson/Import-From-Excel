using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Import_From_Excel.Models
{
    public class FinancialState
    {
        [Key]
        public int FinancialStateId { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal OutstandingLiabilites { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal Interests { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal PenaltyInterests { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal? Fees { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal CourtFees { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal? RepresentationCourtFees { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal? VindicationCosts { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal? RepresentationVindicationCosts { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}