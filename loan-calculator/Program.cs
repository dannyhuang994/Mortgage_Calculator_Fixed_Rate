namespace loan_calculator;
using loan_calculator.Models;
using loan_calculator.Validation;
using System;
using System.Numerics;

class Program
{
    public static void Main(string[] args)
    {
        // get input from the loan officer regarding the pertinent information around the loan

        // ask for monthly income
        double monthlyIncome = ValidationMethods.GetValidDouble("Enter Applicant's Yearly Income: ");

        // Create a Home Purchase  
        HomePurchase newHomePurchase = CreateHomePurchase();
         
        // 
        DecisionMaker decsionMaker = new DecisionMaker(monthlyIncome, newHomePurchase);

        bool decision = decsionMaker.ApproveOrDeny();

        if (decision)
        {
            Console.WriteLine($"Loan is Approved: \n {newHomePurchase}");
        }
        else
        {
            Console.WriteLine($"Loan is Denied: \n {newHomePurchase}");
        }
         
         

        //When the recommendation is to deny, display messages to suggest
        //Placing more money down and Look at buying a more affordable home.
    }

     

    public static Loan CreateLoan(double totalLoanAmount)
    {
        // TODO get user input for loan detail
        Loan newloan = new Loan();

        newloan.Principle = totalLoanAmount;

        newloan.Year = ValidationMethods.GetValidInt("Enter your number of year requested: "
                                            , CONSTANTS.YEAR_MIN_TERM
                                            , CONSTANTS.YEAR_MAX_TERM);
        newloan.AnnualInterest = ValidationMethods.GetValidDouble("Enter your annual interest requested: "
                                            , CONSTANTS.ANNUAL_INTEREST_MIN
                                            , CONSTANTS.ANNUAL_INTEREST_MAX);
        newloan.NumberOfPaymentPerYear = ValidationMethods.GetValidInt("Enter the number of payment per year: "
                                            , CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MIN
                                            , CONSTANTS.NUMBER_OF_PAYMENT_PER_YEAR_MAX);
        return newloan;
    }

    public static HomePurchase CreateHomePurchase()
    {
        // TODO get user input for Home Purchase Detail
        HomePurchase newHomePurchase = new HomePurchase();

        newHomePurchase.PurchasePrice = ValidationMethods.GetValidDouble($"Enter your home purchase price between {CONSTANTS.MIN_HOUSE_PRICE} and {CONSTANTS.MAX_HOUSE_PRICE}: "
                                                                        , CONSTANTS.MIN_HOUSE_PRICE
                                                                        , CONSTANTS.MAX_HOUSE_PRICE);
        newHomePurchase.MarketValue = ValidationMethods.GetValidDouble($"Enter current market value between {CONSTANTS.MIN_HOUSE_PRICE} and {CONSTANTS.MAX_HOUSE_PRICE}: "
                                                                        , CONSTANTS.MIN_HOUSE_PRICE
                                                                        , CONSTANTS.MAX_HOUSE_PRICE);
        newHomePurchase.DownPayment   = ValidationMethods.GetValidDouble($"Enter your total down payment: between {CONSTANTS.MIN_DOWN_PAYMENT} and {newHomePurchase.PurchasePrice}: "
                                                                        , CONSTANTS.MIN_DOWN_PAYMENT
                                                                        , newHomePurchase.PurchasePrice);
        newHomePurchase.YearlyHOA = ValidationMethods.GetValidDouble("Enter Yearly HOA Fee: ");

        double principle = newHomePurchase.GetTotalLoanValue();

        newHomePurchase.MyLoan = CreateLoan(principle);

        return newHomePurchase;
    }

}
