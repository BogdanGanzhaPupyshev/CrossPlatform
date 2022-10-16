using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Laba2
{
    internal class Program
    {
        private static readonly string _inputFilePath = @"D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Laba2\Input.txt";
        private static readonly string _outputFilePath = @"D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Laba3\Output.txt";
        private static readonly string _whitespace = " ";

        public static void FindMaxShip(int n, int m, int k)
        {
            int[,] battleField = new int[n, m];
            //find first and last point 
            //after that fill fields near input coortinates
            //after that try to count bigest ship

            for(int i = 0; i < n; n++)
            {
                for (int j = 0; j < m; j++)
                {

                }
            }
        }

        static void Main(string[] args)
        {
            
            List<string> lines = File.ReadLines(_inputFilePath).ToList();

            if (lines != null && lines.Count > 0)
            {
                string data = lines.FirstOrDefault(x => !String.IsNullOrEmpty(x));

                if (!String.IsNullOrEmpty(data) && data.All(char.IsDigit))
                {
                    var datas = data.Split(_whitespace);

                    if(datas.Length == 3)
                    {
                        int n = data[0];
                        int m = data[1];
                        int k = data[2];
                    }
                    else
                    {
                        throw new Exception("INPUT.txt file incorrect input in first line");
                    }
                }
                else
                {
                    throw new Exception("INPUT.txt file сontains invalid characters");
                }
            }
        }
    }
}
