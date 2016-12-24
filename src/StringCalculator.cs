using System;

namespace TDD.Takas
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            var total = 0;

            var parser = new InputParser();
            parser.Input = input;

            string negatives = string.Empty;

            if (string.IsNullOrEmpty(input))
                return 0;

            foreach (var number in parser.Numbers)
            {
                if (number >= 0)
                    total += number;
                else
                {
                    negatives += number + " ";
                }
            }

            if (!string.IsNullOrEmpty(negatives))
                throw new Exception("negatives not allowed: " + negatives.Trim());

            return total;
        }
    }
}