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

        bool toApprove = newHomePurchase.DecisionToApprove(yearlyIncome);
        while (!toApprove)
        {
            // ask user to increase down payment or provide more income
            double newDownPayment = ValidationMethods.GetValidDouble($"Please Enter a Higher Down Payment Amount, {newHomePurchase.DownPayment} is too low: ");
            yearlyIncome = ValidationMethods.GetValidDouble("Update Applicant's Yearly Income: ");

            newHomePurchase.UpdateDownPayment(newDownPayment);
            toApprove = newHomePurchase.DecisionToApprove(yearlyIncome);
        }
        
    }

}
