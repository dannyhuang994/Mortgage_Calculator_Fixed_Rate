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
        double yearlyIncome = ValidationMethods.GetValidDouble("Enter Applicant's Yearly Income: ");

        // Create a Home Purchase 
        HomePurchase newHomePurchase = HomePurchase.CreateHomePurchase();

        if ( newHomePurchase.DecisionToApprove(yearlyIncome) )
        {
             
            Console.WriteLine("\nCongratulation!!! Loan is Approved!\n");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine(newHomePurchase);
        }
        else
        {
            Console.WriteLine("\nSorry, Your loan is Denied.");
            Console.WriteLine("Please place more money down and look at buying a more affordable home.\n");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine(newHomePurchase);
             
        }

        Console.WriteLine(new string('*', 100));
    }

}
