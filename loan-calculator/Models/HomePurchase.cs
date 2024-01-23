using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace loan_calculator.Models
{
    public class HomePurchase
    {
        public double PurchasePrice { get; set; }  // get from user input
        //public double LoanAmount { get; set; }    
        public Loan MyLoan { get; set; }
        public double MarketValue { get; set; }    // get from user input
        public double DownPayment { get; set; }    // get from user input

        public double YearlyHOA { get; set; }    // get from user input

        public double GetTotalLoanValue()
        {
            // Total Loan Value = purhcase price - downpayment + origination fee(1% of initial loan)  + 2500 tax (CLOSING_FEE_AND_TAXES)
            double loanBase = this.PurchasePrice - DownPayment;   // now it is the loan base amount
            double originationFee = loanBase * CONSTANTS.ORIGIGINATION_FEE_PERCENTAGE / 100;
            if (CONSTANTS.DEBUG)
            {
                Console.WriteLine("*******Debugging Start *******");
                Console.WriteLine($"Loan Base Amount: {Math.Round(loanBase,2)}");
                Console.WriteLine($"Origination Fee Amount: {Math.Round(originationFee, 2)}");
                Console.WriteLine("*******Debugging End *******");
            }

            return loanBase + originationFee + CONSTANTS.CLOSING_FEE_AND_TAXES;
        }

        public double GetEquityPercentage()
        {
            ////  calculate Equity Percentage
           
            double equityPercentage = 100* ( this.MarketValue -  GetTotalLoanValue() )/ this.MarketValue;

            if (CONSTANTS.DEBUG)
            {
                Console.WriteLine("*******Debugging Start *******");
                Console.WriteLine($"Equity Percentage: {Math.Round(equityPercentage,2)}");
                Console.WriteLine("*******Debugging End *******");
            }

            return equityPercentage;
        }
    

        public double GetRequireLoanInsurancePerPayment()
        {
            // Loan insurance will be required on any loan
            // where total equity at inception is less than 10% of the current market value of the home 
            // Loan insurance will be required on any loan where the total equity at inception is less than 10 % of
            // the current market value of the home(for example, buyer is opening a $450, 000 loan
            // but only paying $32, 000 in a down payment, and the total market value of the home is $429, 500,
            // then the buyer needs to cover the 20, 500 deficit between loan amount and home value,
            // plus cover at least 10 % of the total loan(45, 000),
            // so at least $65, 500 down(10 % +deficit in home value vs.Â loan value)
            // would be required to avoid paying Loan Insurance).
            //The calculation for loan insurance is 1 percent of the initial loan value per year,
            //split into equal payments per year.

            bool requireLoanInsurancePerPayment = CONSTANTS.MIN_EQUITY_AT_INCEPTION_PERCENTAGE > this.GetEquityPercentage();
          
            if (requireLoanInsurancePerPayment)
            {
                return CONSTANTS.LOAN_INSURANCE_PERCENTAGE * this.GetTotalLoanValue() / 100 / this.MyLoan.NumberOfPaymentPerYear; 
            }

            return 0;
        }

        public double GetHOAFeePerPayment()
        {
            //  calculate HOA fee per payment
            return this.YearlyHOA/this.MyLoan.NumberOfPaymentPerYear;
        }

        public double GetEscrow()
        {
             //PROPERTY_TAX 
            double propertyTax = (CONSTANTS.PROPERTY_TAX_PERCENTAGE / 100) * this.MarketValue / this.MyLoan.NumberOfPaymentPerYear;


            //HOMEOWNERS_INSURANCE  
            double homeOwnerInsurance = (CONSTANTS.HOMEOWNERS_INSURANCE_PERCENTAGE / 100) * this.MarketValue / this.MyLoan.NumberOfPaymentPerYear;
            
            if (CONSTANTS.DEBUG)
            {
                Console.WriteLine("*******Debugging Start *******");
                Console.WriteLine($"Property Tax Per Payment: {Math.Round(propertyTax,2)} | HomeOwner Insurance Per Payment: { Math.Round(homeOwnerInsurance,2)}");
                Console.WriteLine("*******Debugging End *******");
            }
            return propertyTax + homeOwnerInsurance;
        }

        public double GetMonthlyPayment()
        {
            // calculate monthly payment for the mortgage
            // loan base payment + HOA fee + Ecrow + Loan Insurance + 
            double total = this.GetRequireLoanInsurancePerPayment() + GetHOAFeePerPayment() + this.MyLoan.GetTermPayment() + GetEscrow();
            return total;
        }

        public override string ToString()
        {
            return $" {this.MyLoan.ToString()} | " +
                   $" Loan Insurance Per Payment required: { Math.Round(this.GetRequireLoanInsurancePerPayment(), 2)} | " +
                   $" HOA Fee: {Math.Round(GetHOAFeePerPayment(),2)} | " +
                   $" ESCROW Fee: {Math.Round( GetEscrow(),2) }| " +
                   $" Total Monthly Payment: {Math.Round(this.GetMonthlyPayment())} "; 
        }
    }
}
