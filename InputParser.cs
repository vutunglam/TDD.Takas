using System;

namespace TDD.Takas
{
    public class InputParser
    {
        private string input;
        private string[] delimeters;
        private int[] numbers;


        public string Input
        {
            get 
            { 
                return input; 
            }
            set
            {
                input = value;
                Parse();
            }
        }

        public string[] Delimiters 
        { 
            get
            {
                return delimeters;
            }
            private set
            {
                delimeters = value;
            } 
        }

        public int[] Numbers 
        { 
            get
            {
                return numbers;
            }
            private set
            {
                numbers = value;
            } 
        }

        public InputParser()
        {
            input = string.Empty;
            delimeters = new string[] {",", "\n"};
            numbers = new int[] {0};
        }

        private void Parse()
        {
            if (string.IsNullOrEmpty(input))
            {
                delimeters = new string[] {",", "\n"};
                numbers = new int[] {0};

                return;
            }
            
            string[] parsedNumbers;

            if (HasCustomDelimiter(input))
            {
                var parsedResult = input.Split('\n');
                delimeters = new string[] {parsedResult[0]};

                parsedNumbers = parsedResult[1].Split(parsedResult[0].ToCharArray());
            } 
            else
            {
                parsedNumbers = input.Split(',', '\n');
            }

            numbers = new int[parsedNumbers.Length];
                
            for(int i=0; i<parsedNumbers.Length; i++)
            {
                numbers[i] = int.Parse(parsedNumbers[i]);
            }
        }

        public static bool HasCustomDelimiter(string input)
        {
            var config = input.Split('\n')[0];
            var num = 0;

            if (config.Length > 1)
                return false;
            else
                return !Int32.TryParse(config, out num);
        }
    }
}