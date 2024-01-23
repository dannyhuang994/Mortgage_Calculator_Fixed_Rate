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
        public double Principle { get; set; }  // get from user input
        public double AnnualInterest { get; set; } // get from user input
        public int NumberOfPaymentPerYear { get; set; }  // get from user input
        public int Year { get; set; }  // get from user input and this is the number of year/term for the loan 

        /// <summary>
        /// Calculate monthly payments on the loan based on principle amount only
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double GetTermPayment()
        {
            // Payment = P * (r / n) * [  (1 + r / n)^n(t) ]    /    [  (1 + r / n)^n(t)  - 1]
            // P: Principle(loan amount)
            //r: Annual Interest Rate
            //n: Number of payments per year
            //t: Term(number of years for the loan)
            double topLeft = Principle * (AnnualInterest / NumberOfPaymentPerYear); // P * (r / n)
            double topRight = Math.Pow(( AnnualInterest / NumberOfPaymentPerYear + 1), (NumberOfPaymentPerYear * Year)); //[ (1 + r / n)^n(t)]  
            double bottom = topRight - 1; // [  (1 + r / n)^n(t)  - 1]

            double payment = topLeft * topRight / bottom;
            return payment;
        }

        public override string ToString()
        {
            return  $"Principle: {Math.Round(this.Principle, 2)} | Annual Interest: {this.AnnualInterest} |" +
                    $" #Year: {this.Year} |" +
                    $" #Payment/Year: {this.NumberOfPaymentPerYear}|" +
                    $" Each Base Payment: {Math.Round(this.GetTermPayment(), 2)} ";
        }

    }
}
