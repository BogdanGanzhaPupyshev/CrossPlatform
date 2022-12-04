using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ThreeTasksLibrary
{
    public class Laba1
    {
        private readonly string _whitespace = " ";
        public string LAB_PATH = "";

        private string haveSameDigitsAndLength(int a, int b)
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

        public string ExecuteFirstLab(string inputFilePath, string outputFilePath)
        {
            string input = String.Empty;
            string output = String.Empty;
            List<string> lines = new List<string>();
            string resultView = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(Environment.CurrentDirectory))
                {
                    input = Path.Combine(Environment.CurrentDirectory, "Input.txt");
                    output = Path.Combine(Environment.CurrentDirectory, "Output.txt");
                }
                if (!String.IsNullOrEmpty(LAB_PATH))
                {
                    input = Path.Combine(LAB_PATH, "Input.txt");
                    output = Path.Combine(LAB_PATH, "Output.txt");
                }
                if (!String.IsNullOrEmpty(inputFilePath))
                {
                    input = inputFilePath;
                }
                if (!String.IsNullOrEmpty(inputFilePath))
                {
                    output = outputFilePath;
                }
            }
            catch
            {
                throw new Exception("Incorrect input of file path");
            }

            try
            {
                lines = File.ReadLines(input).ToList();
            }
            catch
            {
                throw new Exception("Incorrect file path");
            }


            if (lines.Count % 2 != 0)
            {
                throw new Exception("Incorrect count of strings in Input.txt file");
            }
            else if (lines.Count == 0)
            {
                Console.WriteLine("Input file was empty");
            }
            else
            {

                List<string> lineWithoutSpace = lines.Select(x => x.Replace(_whitespace, String.Empty)).ToList();
                lines.Clear();


                using (StreamWriter writer = new StreamWriter(output))
                {
                    for (var i = 0; i < lineWithoutSpace.Count; i++)
                    {
                        if (Int32.TryParse(lineWithoutSpace[i], out int num1) && Int32.TryParse(lineWithoutSpace[i + 1], out int num2))
                        {
                            string result = haveSameDigitsAndLength(num1, num2);
                            resultView += $"{result} ";
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

            return resultView;
        }
    }
}
