## Mortgage Calculator (.Net Console Application with C#)

### Description
This is a mortgage calculator for a fixed-rate interest loan. The console will prompt user to enter their yearly income, purchase price of home, market value, total down payment, yearly HOA fee, number of years for loan repayment, APR (fixed at the time of home purchase), and number of payment per year. 

There are some assumption made on the homeowner insurance percentage, orignation fee percentage, closing fee and taxes. These variables are store in [/Models/CONSTANTS.cs](./mortgage-calculator/Models/CONSTANTS.cs).
Update the numbers as you need. 


### 
To Run the Application, run the following Command

``` bash
dotnet run
```


### Sample Output
``` plaintext
Enter Applicant's Yearly Income: 
100000
Enter your home purchase price between $10,000 and $100,000,000,000:
450000
Enter current market value between $10,000 and $100,000,000,000:
455000
Enter your total down payment: between $0 and $450,000:
200000
Enter Yearly HOA Fee:
2000
Enter Your Number of Years (Term) requested:
30
Enter your Annual Interest Rate Percentage requested:
5
Enter the Number of Payments Per Year between 1 and 12:
12

Sorry, Your loan is Denied.
Please place more money down and look at buying a more affordable home.

****************************************************************************************************
*    Principal: $255,000.00 | Annual Interest: 5.00% | Term: 30 Years | #Payments Per Year: 12     *
*    Base Payment: $1,368.90                                                                       *
*    Loan Insurance Per Payment required: $0.00                                                    *
*    HOA Fee Per Payment: $166.67                                                                  *
*    ESCROW Fee Per Payment: $853.12                                                               *
*        Property Tax Per Payment: $473.96                                                         *
*        HomeOwner Insurance Per Payment: $379.17                                                  *
*    Total Monthly Payment: $2,388.69                                                              *
****************************************************************************************************

Please Enter a Higher Down Payment Amount, $200,000 is too low:
300000
Update Applicant's Yearly Income: 
100000

Congratulation!!! Loan is Approved!

****************************************************************************************************
*    Principal: $154,000.00 | Annual Interest: 5.00% | Term: 30 Years | #Payments Per Year: 12     *
*    Base Payment: $826.71                                                                         *
*    Loan Insurance Per Payment required: $0.00                                                    *
*    HOA Fee Per Payment: $166.67                                                                  *
*    ESCROW Fee Per Payment: $853.12                                                               *
*        Property Tax Per Payment: $473.96                                                         *
*        HomeOwner Insurance Per Payment: $379.17                                                  *
*    Total Monthly Payment: $1,846.50                                                              *
****************************************************************************************************
```
 

