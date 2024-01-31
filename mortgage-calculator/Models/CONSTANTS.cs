using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loan_calculator.Models
{
    public class CONSTANTS
    {

        public const bool DEBUG = false;


        // for HomePurchae 
        public const double ORIGIGINATION_FEE_PERCENTAGE = 1;

        public const double CLOSING_FEE_AND_TAXES = 2500;

        public const double LOAN_INSURANCE_PERCENTAGE = 1.0;

        public const double HOMEOWNERS_INSURANCE_PERCENTAGE = 1.0;

        public const double PROPERTY_TAX_PERCENTAGE = 1.25;

        public const double MIN_EQUITY_AT_INCEPTION_PERCENTAGE = 10;

        public const double MIN_HOUSE_PRICE = 10000;

        public const double MAX_HOUSE_PRICE = 100_000_000_000;

        public const double MIN_DOWN_PAYMENT = 0;

        public const double DECISION_THRESHOLD_PERCENTAGE = 0.25;


        // for Loan class


        public const int YEAR_MIN_TERM = 5;

        public const int YEAR_MAX_TERM = 30;

        public const double ANNUAL_INTEREST_PERCENTAGE_MIN = 1;

        public const double ANNUAL_INTEREST_PERCENTAGE_MAX = 50.0;

        public const int NUMBER_OF_PAYMENT_PER_YEAR_MIN = 1;

        public const int NUMBER_OF_PAYMENT_PER_YEAR_MAX = 12;



    }
}
