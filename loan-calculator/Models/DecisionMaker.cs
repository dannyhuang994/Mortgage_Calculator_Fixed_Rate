using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace loan_calculator.Models
{
    public class DecisionMaker
    {
        public double YearlyIncome { get; set; }
        public HomePurchase NewHomePurchase { get; set; }

       

        public DecisionMaker(double yearlyIncome, HomePurchase newHomePurchase)
        {
            this.YearlyIncome = yearlyIncome;
            this.NewHomePurchase = newHomePurchase;
        }

        public bool ApproveOrDeny()
        {
            return YearlyIncome / NewHomePurchase.MyLoan.NumberOfPaymentPerYear * 0.25 > this.NewHomePurchase.GetMonthlyPayment();
        }
    }

     
}
