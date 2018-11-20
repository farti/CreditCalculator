using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCalculator.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double Installment { get; set; }
        public double MonthlyPrincipal { get; set; }
        public double MonthlyInterest { get; set; }
        public double Balance { get; set; }
        public double TotalPrincipal { get; set; }
        public double TotalInterest { get; set; }


        // https://pl.wikipedia.org/wiki/Annuita

        /// <summary>
        /// Calculate monthly details of payments base on current credit data
        /// </summary>
        /// <param name="amountOfCredit">Amount of the credit</param>
        /// <param name="termInMonths">The length of the credit in months</param>
        /// <param name="interestRatePerYear">Annual interest rate</param>
        /// <returns>List of monthly payments with details.</returns>

        public ArrayList Payments(double amountOfCredit, double termInMonths, double interestRatePerYear)
        {
            double monthlyPayment = MonthlyPayment(amountOfCredit, termInMonths, interestRatePerYear);
            double monthlyPrincipal = 0;
            double totalPrincipal = 0;
            double totalInterest = 0;
            double monthlyInterest;
            double balance = amountOfCredit;

            ArrayList payments = new ArrayList();

            for (int i = 0; i < termInMonths - 1; i++)
            {

                monthlyInterest = MonthlyInterestAmount(balance, interestRatePerYear);
                monthlyPrincipal = monthlyPayment - monthlyInterest;
                totalPrincipal = totalPrincipal + monthlyPrincipal;
                totalInterest = totalInterest + monthlyInterest;
                balance = balance - monthlyPrincipal;

                payments.Add(new Payment()
                {
                    Id = i + 1,
                    Installment = monthlyPayment,
                    MonthlyInterest = monthlyInterest,
                    MonthlyPrincipal = monthlyPrincipal,
                    Balance = balance,
                    TotalPrincipal = totalPrincipal,
                    TotalInterest = totalInterest
                });
            }

            return payments;

        }

        public double MonthlyInterestAmount(double principal, double interest)
        {
            return principal * ((interest / 100) * (1.0 / 12 / 0));
        }

        private static double AmountTotal(double termInMonths, double monthlyPayment)
        {

            return termInMonths * monthlyPayment;
        }

        private static double MonthlyPayment(double amountOfCredit, double interestRatePerYear, double termInMonths)
        {
            try
            {
                double monthlyPayment;
                double interestRate;
                interestRate = (interestRatePerYear / 100) * (1.0 / 12.0);
                monthlyPayment = (amountOfCredit * interestRate * (Math.Pow((1 + interestRate), termInMonths))) /
                                 (Math.Pow((1 + interestRate), termInMonths) - 1);
                return monthlyPayment;
            }
            catch
            {
                return 0.0;
            }
        }
    }
}