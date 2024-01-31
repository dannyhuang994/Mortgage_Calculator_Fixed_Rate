using loan_calculator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace loan_calculator.Models
{
    public class Loan
    {
        public double Principal { get; set; }  // calculated from user input 
        public double AnnualInterestPercentage { get; set; } // get from user input
        public int NumberOfPaymentPerYear { get; set; }  // get from user input
        public int TermsInYear { get; set; }  // get from user input and this is the number of year/term for the loan 

        public static Loan CreateLoan(double totalLoanAmount)
        {
            // TODO get user input for loan detail
            Loan newloan = new Loan();

            newloan.Principal = totalLoanAmount;

            newloan.TermsInYear = ValidationMethods.GetValidInt("Enter Your Number of Years (Term) requested: "
                                                , CONSTANTS.YEAR_MIN_TERM
                                                , CONSTANTS.YEAR_MAX_TERM);
            newloan.AnnualInterestPercentage = ValidationMethods.GetValidDouble("Enter your Annual Interest Rate Percentage requested: "
                                                , CONSTANTS.ANNUAL_INTEREST_PERCENTAGE_MIN
                                                , CONSTANTS.ANNUAL_INTEREST_PERCENTAGE_MAX);
            newloan.NumberOfPaymentPerYear = ValidationMethods.GetValidInt($"Enter the Number of Payments Per Year between" +
                                                 $" {CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MIN} and {CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MAX}: "
                                                , CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MIN
                                                , CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MAX);
            return newloan;
        }

        /// <summary>
        /// Calculate monthly payments on the loan based on principal amount only
        /// </summary>
        /// <returns>Base Periodic Payment Amount for Loan</returns>
        public double GetTermPayment()
        {
            // Payment = P * (r / n) * [  (1 + r / n)^n(t) ]    /    [  (1 + r / n)^n(t)  - 1]
            // P: Principal (loan amount)
            //r: Annual Interest Rate
            //n: Number of payments per year
            //t: Term(number of years for the loan)
            double r = AnnualInterestPercentage / 100;

            double topLeft = Principal * (r / NumberOfPaymentPerYear); // P * (r / n)
            double topRight = Math.Pow((r / NumberOfPaymentPerYear + 1), (NumberOfPaymentPerYear * TermsInYear)); //[ (1 + r / n)^n(t)]  
            double bottom = topRight - 1; // [  (1 + r / n)^n(t)  - 1]

            return topLeft * topRight / bottom; ;
        }

        public override string ToString()
        {
            return $"Principal: {Math.Round(Principal, 2)} | Annual Interest: {AnnualInterestPercentage}% | Term: {TermsInYear} Years | #Payments Per Year: {NumberOfPaymentPerYear}".PadRight(94, ' ') + "*\n" +
                    $"*    Base Payment: {Math.Round(GetTermPayment(), 2)}".PadRight(99, ' ');
        }

    }
}
