using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loan_calculator.Validation
{
    public class ValidationMethods
    {
        /// <summary>
        /// Validates the input is not null or whitespace
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetValidString(string prompt)
        {
            string input = null;
            do
            {
                Console.WriteLine(prompt);
                input = $"{Console.ReadLine()}";

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Validates the input is not null or whitespace AND that it has a length less than or equal to maxLength
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GetValidString(string prompt, int minLength, int maxLength)
        {
            string input = GetValidString(prompt);

            while (input.Length < minLength || input.Length > maxLength)
            {
                input = GetValidString(prompt);
            }


            return input;
        }

        public static bool GetValidBool(string prompt)
        {

            string response = GetValidString(prompt);

            return response.ToLower().StartsWith('y');

        }
        public static int GetValidInt(string prompt
                                      , int minValue = Int32.MinValue
                                      , int maxValue = Int32.MaxValue)
        {

            string response = string.Empty;
            int result = Int32.MinValue;

            do
            {
                response = GetValidString(prompt);
                while (!int.TryParse(response, out result))
                {
                    response = GetValidString(prompt);
                }

            } while (result < minValue || result > maxValue);

            //Console.WriteLine($"Result: {result}");
            return result;
        }

        public static double GetValidDouble(string prompt, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            string response = string.Empty;
            double result = double.MinValue;

            do
            {
                response = GetValidString(prompt);
                while (!double.TryParse(response, out result))
                {
                    response = GetValidString(prompt);
                }
            } while (result < minValue || result > maxValue);
            //Console.WriteLine($"Result: {result}");
            return result;
        }
    }
}
