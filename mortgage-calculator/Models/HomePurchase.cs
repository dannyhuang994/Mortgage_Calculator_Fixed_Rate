using loan_calculator.Validation;
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
        public double MarketValue { get; set; }    // get from user input
        public double DownPayment { get; set; }    // get from user input
        public double YearlyHOA { get; set; }    // get from user input
        public Loan CurrentLoan { get; set; }  // We can later turn this into a list of loans so one home purchase can be splited by two or more loans

        /// <summary>
        /// Method to prompt user to enter required field to create a home purchase
        /// </summary>
        /// <returns>HomePurchase object with Loan calculated </returns>
        public static HomePurchase CreateHomePurchase()
        {
            // TODO get user input for Home Purchase Detail
            HomePurchase newHomePurchase = new HomePurchase();

            newHomePurchase.PurchasePrice = ValidationMethods.GetValidDouble($"Enter your home purchase price between {CONSTANTS.MIN_HOUSE_PRICE:C0} and {CONSTANTS.MAX_HOUSE_PRICE:C0}: "
                                                                            , CONSTANTS.MIN_HOUSE_PRICE
                                                                            , CONSTANTS.MAX_HOUSE_PRICE);
            newHomePurchase.MarketValue = ValidationMethods.GetValidDouble($"Enter current market value between {CONSTANTS.MIN_HOUSE_PRICE:C0} and {CONSTANTS.MAX_HOUSE_PRICE:C0}: "
                                                                            , CONSTANTS.MIN_HOUSE_PRICE
                                                                            , CONSTANTS.MAX_HOUSE_PRICE);
            newHomePurchase.DownPayment = ValidationMethods.GetValidDouble($"Enter your total down payment: between {CONSTANTS.MIN_DOWN_PAYMENT:C0} and {newHomePurchase.PurchasePrice:C0}: "
                                                                            , CONSTANTS.MIN_DOWN_PAYMENT
                                                                            , newHomePurchase.PurchasePrice);
            newHomePurchase.YearlyHOA = ValidationMethods.GetValidDouble("Enter Yearly HOA Fee: ");

            double principal = newHomePurchase.GetTotalLoanAmountRequired();

            newHomePurchase.CurrentLoan = Loan.CreateLoan(principal);

            return newHomePurchase;
        }

        public void UpdateDownPayment(double newDownPayment)
        {
            DownPayment = newDownPayment;
            CurrentLoan.Principal = GetTotalLoanAmountRequired(); // adjusting the principal in total amount borrowed
        }

        public double GetTotalLoanAmountRequired()
        {
            // Total Loan Value = purhcase price - downpayment + origination fee(1% of initial loan)  + 2500 tax (CLOSING_FEE_AND_TAXES)

            double loanBase = PurchasePrice - DownPayment;   // the loan base amount
            double originationFee = loanBase * CONSTANTS.ORIGIGINATION_FEE_PERCENTAGE / 100;

            return loanBase + originationFee + CONSTANTS.CLOSING_FEE_AND_TAXES;
        }

        public double GetEquityPercentage()
        {
            ////  calculate Equity Percentage

            double equityPercentage = 100 * (MarketValue - GetTotalLoanAmountRequired()) / MarketValue;

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

            bool requireLoanInsurancePerPayment = CONSTANTS.MIN_EQUITY_AT_INCEPTION_PERCENTAGE > GetEquityPercentage();

            if (requireLoanInsurancePerPayment)
            {
                return CONSTANTS.LOAN_INSURANCE_PERCENTAGE * GetTotalLoanAmountRequired() / 100 / CurrentLoan.NumberOfPaymentPerYear;
            }

            return 0;
        }

        public double GetHOAFeePerPayment()
        {
            //  calculate HOA fee per payment
            return this.YearlyHOA / this.CurrentLoan.NumberOfPaymentPerYear;
        }

        public double GetEscrow()
        {
            return GetPropertyTaxPerPayment() + GetHomeOwnerInsurancePerPayment();
        }

        public double GetPropertyTaxPerPayment()
        {
            return (CONSTANTS.PROPERTY_TAX_PERCENTAGE / 100) * MarketValue / CurrentLoan.NumberOfPaymentPerYear;
        }

        public double GetHomeOwnerInsurancePerPayment()
        {
            return (CONSTANTS.HOMEOWNERS_INSURANCE_PERCENTAGE / 100) * MarketValue / CurrentLoan.NumberOfPaymentPerYear;
        }

        public double GetMonthlyPayment()
        {
            // calculate monthly payment for the mortgage
            // loan base payment + HOA fee + Ecrow + Loan Insurance + 
            double total = GetRequireLoanInsurancePerPayment() + GetHOAFeePerPayment() + CurrentLoan.GetTermPayment() + GetEscrow();
            return total;
        }

        public bool DecisionToApprove(double yearlyIncome)
        {
            bool decisionToApprove = CONSTANTS.DECISION_THRESHOLD_PERCENTAGE * yearlyIncome / CurrentLoan.NumberOfPaymentPerYear > GetMonthlyPayment();

            if (decisionToApprove)
            {

                Console.WriteLine("\nCongratulation!!! Loan is Approved!\n");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine(this);
            }
            else
            {
                Console.WriteLine("\nSorry, Your loan is Denied.");
                Console.WriteLine("Please place more money down and look at buying a more affordable home.\n");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine(this);

            }

            Console.WriteLine(new string('*', 100));
            Console.WriteLine();

            return decisionToApprove;
        }

        /// <summary>
        /// To Print the output nicely
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"*    {this.CurrentLoan.ToString()}" + "*\n" +
                   $"*    Loan Insurance Per Payment required: {GetRequireLoanInsurancePerPayment():C2} ".PadRight(99, ' ') + "*\n" +
                   $"*    HOA Fee Per Payment: {GetHOAFeePerPayment():C2} ".PadRight(99, ' ') + "*\n" +
                   $"*    ESCROW Fee Per Payment: {GetEscrow():C2} ".PadRight(99, ' ') + "*\n" +
                   $"*        Property Tax Per Payment: {GetPropertyTaxPerPayment():C2} ".PadRight(99, ' ') + "*\n" +
                   $"*        HomeOwner Insurance Per Payment: {GetHomeOwnerInsurancePerPayment():C2} ".PadRight(99, ' ') + "*\n" +
                   $"*    Total Monthly Payment: {GetMonthlyPayment():C2}".PadRight(99, ' ') + "*";
        }
    }
}
