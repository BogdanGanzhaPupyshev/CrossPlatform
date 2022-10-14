using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Laba1
{
    internal class Program
    {
        //For test change the path
        private static readonly string _inputFilePath = @"D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Laba1\Input.txt";
        private static readonly string _outputFilePath = @"D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Laba1\Output.txt";
        private static readonly string _whitespace = " ";

        public static string haveSameDigitsAndLength(int a, int b)
        {
            int[] digits = new int[10];
            for (int i = a; i > 0; i = i / 10)
            {
                ++digits[i % 10];
            }
            for (int i = b; i > 0; i = i / 10)
            {
                --digits[i % 10];
            }
            foreach (int digit in digits)
            {
                if (digit != 0)
                {
                    return "NO";
                }
            }
            return "YES";
        }

        static void Main(string[] args)
        {

            List<string> lines = File.ReadLines(_inputFilePath).ToList();
            if (lines.Count % 2 != 0)
            {
                throw new Exception("Incorrect count of strings in Input.txt file");
            }

            List<string> lineWithoutSpace = lines.Select(x => x.Replace(_whitespace, String.Empty)).ToList();
            lines.Clear();

            using (StreamWriter writer = new StreamWriter(_outputFilePath))
            {
                for (var i = 0; i < lineWithoutSpace.Count; i++)
                {
                    if (Int32.TryParse(lineWithoutSpace[i], out int num1) && Int32.TryParse(lineWithoutSpace[i + 1], out int num2))
                    {
                        string result = haveSameDigitsAndLength(num1, num2);
                        writer.WriteLine(result);
                    }
                    else
                    {
                        throw new Exception("Input Error file contains invalid characters");
                    }

                    i += 1;
                }
            }
        }

    }
}
