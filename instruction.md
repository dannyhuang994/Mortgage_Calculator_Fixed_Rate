Exercise 2: Reviewing the problem statement, designing and planning a solution
Overview
In this challenge exercise, you will review the problem statement and plan your implementation. It is arguably more important to spend time planning a solution than to just jump in and start writing the solution - even if the solution seems trivial. Good planning will set you up to write good code that is well-organized and easy to read, without a lot of complexity.

Time estimate
60 minutes
Task 1: Review the problem statement
To begin, review the following problem statement:

Requirements/Instructions for calculating a home loan
For this challenge, you will utilize the skills you’ve learned to this point to take input from a loan officer to calculate the loan payments for a potential buyer, and ultimately recommend approving or denying the loan while providing an estimated monthly payment amount.

As part of the exercise, you will need to get input from the loan officer regarding the pertinent information around the loan. Once the calculations are in, you then will then provide a recommendation to approve or deny the loan.

Time permitting, you may potentially run other scenarios on your completed project to offer the buyer options when a loan is not approved (for example: Increase down payment or buy a more affordable home)

Functional Requirements
The following requirements must be met to complete the challenge.

Can calculate loan payments for fixed-rate loans.

Can calculate loans for terms of 15 or 30 years.

Can determine the total loan value as the result of the home’s purchase price, the amount of down payment, and an origination fee of one percent added to the initial loan amount. Additionally, a fee of $2500 for approximate taxes and closing costs on the sale should be included in the total loan amount.

Can display the equity percentage and value of the home owned by the buyer at inception based on purchase price, market value of home and down payment values.

Loan insurance will be required on any loan where the total equity at inception is less than 10% of the current market value of the home (for example, buyer is opening a $450,000 loan but only paying $32,000 in a down payment, and the total market value of the home is $429,500, then the buyer needs to cover the 20,500 deficit between loan amount and home value, plus cover at least 10% of the total loan (45,000), so at least $65,500 down (10% + deficit in home value vs.Â loan value) would be required to avoid paying Loan Insurance).

The calculation for loan insurance is 1 percent of the initial loan value per year, split into equal payments per year.
Additional amounts are gathered for yearly HOA fees, this should be calculated for a monthly total based on the yearly fee divided per payment period, and then added to the base payment.

Additional amounts are gathered for Escrow (insurance and taxes). Assume property tax is 1.25 percent yearly split into monthly payments and homeowners insurance is 0.75 percent yearly split into monthly payments, both based off of the current market value of the home at the time of loan inception. As with HOA fees, compute a payment per term period (most likely - monthly) and then add that payment to the total monthly payment value

Can determine if the payment is >= 25% of the buyer’s monthly income and use that value to recommend approving or denying the loan. Deny when >=25%, otherwise approve.

When the recommendation is to deny, display messages to suggest Placing more money down and Look at buying a more affordable home.

Monthly payments should have the following attributes

Base Amount for the loan (principle and interest)
Escrow amount:
Homeowner’s Insurance
Property Tax (1.1% of total home value by year, collected monthly)
HOA Fees (if any, by year, collected monthly)
Loan Insurance (if applicable), at 1% of the initial loan value per year
Hint: You will need to correctly determine the loan amount as described above, based on inputs, so you must start by collecting the correct information. The instructor will expect your program to take the information and calculate the loan amount, not just take the loan amount directly.

Gather the appropriate information
The first step to be able to calculate a home loan will be to gather the correct information from the loan officer who is working with the potential home buyer.

In order to correctly calculate a loan, a number of factors need to be considered. For example, how much will the initial loan amount be? How much will the buyer give as a down payment? What is the interest rate (additionally, will it vary based on the amount/percentage of equity and down payment amount?) What other questions can you think of (try to do this for a few minutes before continuing further).

The formula to calculate the loan
The following formula will be useful in calculating the loan payments:

Payment = P * (r / n) * [(1 + r / n)^n(t)] / [(1 + r / n)^n(t) - 1]
Review How to Calculate Your Mortgage Payment for more information.

The variables in the formula are:

P: Principle (loan amount)
r: Annual Interest Rate
n: Number of payments per year
t: Term (number of years for the loan)

Hint: Remember to break down the problems into small, solvable solutions that you can encapsulate in helper methods. For example, use a method to determine the starting value of the loan based on the parameters and details for calculating the loan value at inception.

Task 2: Design a solution
In this task, you will write out a solution on paper (or in notepad). To complete this task, you must think through the entire problem and determine valuable information that you must have to complete the program.

Determine your inputs

On paper or in notepad, write down all of the input you will need to gather from the loan officer running the program. For example, you might have something similar to the following as one of your inputs:

The purchase amount of the home
Note that you don’t have to be perfect at this step. However, you should do your best to think through everything and build this list, which you can use later to check off as you build the specific functionality into your solution.

Create some sample test data

The website listed above shows the calculations that are required to determine a loan payment amount. For this step, you should come up with 4-5 more calcuatlions that you’ve done by hand that you can easily run in the program.

Hint: as the program will NOT be taking the loan amount directly, consider the values you need to enter to get to the expected loan amount, or be prepared to adjust your test calculations later if you were expecting 100,000 and the actual computed loan amount turns out to be 85,000.

Task 3: Planning the implementation
To complete the circle, plan the steps you will take to develop the solution.

Development is personal.

Make this process your own, but consider organizing the steps as to your approach. Remember to break the larger problems down into smaller problems. As this activity is not guided, if you don’t some time here to think this through and plan it, you will have a very difficult time completing the challenge.

For example, consider the following steps to your approach:

Get input from the user

Purchase price
Interest rate
…
Calculate the total loan amount

…

Display approve or deny based on recommendation.

If you can organize your approach, you will have a much better chance to complete the challenge.

Summary


Exercise 3: Developing the Mortgage Calculator Solution
Overview
In this challenge exercise, you will take the information you have compiled from the previous step to begin creating a mortgage calculator that solves the problems as laid out in the problem statement.

Time estimate
90 minutes
Task 1: Create the project
To get started, create a new console project.

Task 2: Implement the Logic and Solve the Problem
Once you have your project, begin implementing the solution as planned in the previous exercise.

Task 3: Reminders about the solution
The formula to calculate the loan
The following formula will be useful in calculating the loan payments:

Payment = P * (r / n) * [(1 + r / n)^n(t)] / [(1 + r / n)^n(t) - 1]
Review How to Calculate Your Mortgage Payment for more information.

The variables in the formula are:

P: Principle (loan amount)
r: Annual Interest Rate
n: Number of payments per year
t: Term (number of years for the loan)

Hint: Remember to break down the problems into small, solvable solutions that you can encapsulate in helper methods. For example, use a method to determine the starting value of the loan based on the parameters and details for calculating the loan value at inception.

Validate your solution
When you are ready, you will need to ask the instructor to validate your solution. Before you ask for validation, ensure that your numbers make sense by going to an online mortgage calculator and comparing the monthly payment amount shown to your output (note that your number may vary slightly due to additional fee calculations).

BankRate
RocketMortgage

Note that it’s ok if the numbers are not exact, based on the fictitious numbers for insurance, property tax, and other adjustments in this exercise. That being said, the initial monthly payment would be expected to be extremely similar, if not identical.

Task 4: Ask your instructor to validate your challenge
In order to complete the challenge and receive a badge, your instructor must approve your final solution. Be prepared to answer questions regarding your code and any choices you have made along your path to the solution.

Completion
You have completed this challenge when the instructor validates your solution.

Summary
In this third exercise, you implemented the code necessary to complete the overall solution as defined and described in the previous steps.

References
The following references may be useful to help you complete this challenge:

How to calculate a mortgage payment
BankRate
RocketMortgage
Working with types
Working with selection statements
Working with variables
Using Operators
Branches and Loops
Using Math