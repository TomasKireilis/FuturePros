using System;
using System.Linq;

namespace TomasKireilisProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Uncomment which you want to try;
            // Task1();
            Task2();
        }

        public static void Task1()
        {
            var input = Console.ReadLine();
            //For fast check
            //  input = "I donn’t knoow pii value,  so I will go eat my ppiie…";
            input = string.Join(" ",
                input.Split(' ')
                    .Select(RemoveLetterRepetitions));
            input = ReplacePIWithValue(input);
            Console.WriteLine(input);
        }

        public static void Task2()
        {
        }

        private static string RemoveLetterRepetitions(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] == input[i])
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }

            return input;
        }

        private static string ReplacePIWithValue(string input)
        {
            for (int i = 0; i < input.Length - 4; i++)
            {
                if (input.Substring(i, 4).ToLower() == " pi ")
                {
                    input = input.Remove(i, 4);
                    input = input.Insert(i, " 3.14 ");
                }
            }

            return input;
        }
    }
}