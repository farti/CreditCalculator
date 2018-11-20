using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditCalculator.Models
{
    public class Credit
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the amount of credit.")]
        public double AmountOfCredit { get; set; }

        [Required(ErrorMessage = "Please enter the interest rate.")]
        public double InterestRatePerYear { get; set; }

        [Required(ErrorMessage = "Please enter the number of month.")]
        public double TermInMonths { get; set; }

        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
    }
}