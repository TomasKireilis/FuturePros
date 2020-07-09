using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace TomasKireilisProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Uncomment which one you want to try;

            Task1();
            // Task2();
        }

        public static void Task1()
        {
            Console.WriteLine("enter text");
            var input = Console.ReadLine();

            //For fast check
            input = "PII donn’t knoow pii value,  so I will go eat my ppiie…pi";

            input = string.Join(" ",
                input.Split(' ')
                    .Select(RemoveLetterRepetitions));
            input = ReplacePIWithValue(input);
            Console.WriteLine(input);
        }

        public static void Task2()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            intList = RemoveByFirst(intList);

            int lastIndex = 1;
            while (intList.Count >= intList[lastIndex])
            {
                intList = RemoveEveryNNumber(intList, lastIndex);
                lastIndex++;
            }

            intList.ForEach(x => Console.Write(x + " "));
        }

        private static List<int> RemoveByFirst(List<int> list)
        {
            if (list.Count > 0)
            {
                if (list[0] % 2 == 0)
                {
                    list = list.Where(x => x % 2 == 0).ToList();
                }
                else
                {
                    list = list.Where(x => x % 2 != 0).ToList();
                }
            }

            return list;
        }

        private static List<int> RemoveEveryNNumber(List<int> list, int byIndex)
        {
            var removeEvery = list[byIndex];
            for (int i = removeEvery - 1; i < list.Count;)
            {
                list.RemoveAt(i);
                i += removeEvery - 1;
            }

            return list;
        }

        private static string RemoveLetterRepetitions(string input)
        {
            StringBuilder str = new StringBuilder(input);
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i + 1] == str[i])
                {
                    str = str.Remove(i, 1);
                    i--;
                }
            }

            return str.ToString();
        }

        private static string ReplacePIWithValue(string input)
        {
            string pattern = @"\bPI\b";
            string replace = "3.14";
            return Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase);
        }
    }
}