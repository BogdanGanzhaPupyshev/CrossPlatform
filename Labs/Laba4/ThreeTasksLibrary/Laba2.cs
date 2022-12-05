using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThreeTasksLibrary.Laba2Models;

namespace ThreeTasksLibrary
{

    public class Laba2
    {
        private static readonly string _whitespace = " ";
        public string LAB_PATH = "";

        private int[,] FindFirstPoints(int n, int m, List<Coordinates> coordinates)
        {
            int[,] battleField = new int[n, m];

            foreach (var cord in coordinates)
            {
                for (int i = 0; i < n; i++)
                {
                    if (cord.FirstPoint.X - 1 == i)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (cord.FirstPoint.Y - 1 == j)
                            {
                                battleField[i, j] = 1;
                            }
                        }
                    }

                }
            }

            return battleField;
        }

        private int[,] FindLastPoints(int n, int m, int[,] battleField, List<Coordinates> coordinates)
        {

            foreach (var cord in coordinates)
            {
                for (int i = 0; i < n; i++)
                {
                    if (cord.LastPoint.X - 1 == i)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (cord.LastPoint.Y - 1 == j)
                            {
                                battleField[i, j] = 1;
                            }
                        }
                    }

                }
            }

            return battleField;
        }

        private int[,] FindDeadPoints(int n, int m, int[,] battleFiled, List<Coordinates> coordinates)
        {
            #region FirstPoints
            foreach (Coordinates item in coordinates)
            {
                var fPointX = item.FirstPoint.X - 1;
                var fPointy = item.FirstPoint.Y - 1;

                if (battleFiled[fPointX, fPointy] == 1)
                {
                    if (fPointX - 1 >= 0 && fPointy - 1 >= 0 && fPointX + 1 <= n && fPointy + 1 <= m)
                    {
                        battleFiled[fPointX - 1, fPointy] = 1;
                        battleFiled[fPointX + 1, fPointy] = 1;
                        battleFiled[fPointX, fPointy + 1] = 1;
                        battleFiled[fPointX, fPointy - 1] = 1;
                        battleFiled[fPointX - 1, fPointy - 1] = 1;
                        battleFiled[fPointX - 1, fPointy + 1] = 1;
                        battleFiled[fPointX + 1, fPointy - 1] = 1;
                        battleFiled[fPointX + 1, fPointy + 1] = 1;
                    }
                    if (fPointX - 1 < 0)
                    {
                        if (fPointy - 1 < 0)
                        {
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX + 1, fPointy + 1] = 1;
                        }
                        else if (fPointy + 1 >= m)
                        {
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX + 1, fPointy - 1] = 1;
                        }
                        else
                        {
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX + 1, fPointy - 1] = 1;
                            battleFiled[fPointX + 1, fPointy + 1] = 1;
                        }
                    }
                    if (fPointX + 1 >= n)
                    {
                        if (fPointy + 1 >= m)
                        {
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX - 1, fPointy - 1] = 1;
                        }
                        else if (fPointy - 1 < 0)
                        {
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX - 1, fPointy + 1] = 1;
                        }
                        else
                        {
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX - 1, fPointy - 1] = 1;
                            battleFiled[fPointX - 1, fPointy + 1] = 1;
                        }
                    }
                    if (fPointy - 1 < 0)
                    {
                        if (fPointX + 1 >= m)
                        {
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX - 1, fPointy + 1] = 1;
                        }
                        else if (fPointX - 1 < 0)
                        {
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX + 1, fPointy + 1] = 1;

                        }
                        else
                        {
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy + 1] = 1;
                            battleFiled[fPointX - 1, fPointy + 1] = 1;
                            battleFiled[fPointX + 1, fPointy + 1] = 1;
                        }
                    }
                    if (fPointy + 1 >= m)
                    {
                        if (fPointX + 1 >= n)
                        {
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX - 1, fPointy - 1] = 1;
                        }
                        else if (fPointX - 1 < 0)
                        {
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX + 1, fPointy - 1] = 1;

                        }
                        else
                        {
                            battleFiled[fPointX - 1, fPointy] = 1;
                            battleFiled[fPointX + 1, fPointy] = 1;
                            battleFiled[fPointX, fPointy - 1] = 1;
                            battleFiled[fPointX - 1, fPointy - 1] = 1;
                            battleFiled[fPointX + 1, fPointy - 1] = 1;
                        }
                    }
                }
            }
            #endregion

            #region EndPoints
            foreach (Coordinates item in coordinates)
            {
                var lPointX = item.LastPoint.X - 1;
                var lPointy = item.LastPoint.Y - 1;

                if (battleFiled[lPointX, lPointy] == 1)
                {
                    if (lPointX - 1 >= 0 && lPointy - 1 >= 0 && lPointX + 1 <= n - 1 && lPointy + 1 <= m - 1)
                    {
                        battleFiled[lPointX - 1, lPointy] = 1;
                        battleFiled[lPointX + 1, lPointy] = 1;
                        battleFiled[lPointX, lPointy + 1] = 1;
                        battleFiled[lPointX, lPointy - 1] = 1;
                        battleFiled[lPointX - 1, lPointy - 1] = 1;
                        battleFiled[lPointX - 1, lPointy + 1] = 1;
                        battleFiled[lPointX + 1, lPointy - 1] = 1;
                        battleFiled[lPointX + 1, lPointy + 1] = 1;
                    }
                    if (lPointX - 1 < 0)
                    {
                        if (lPointy - 1 < 0)
                        {
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX + 1, lPointy + 1] = 1;
                        }
                        else if (lPointy + 1 >= m)
                        {
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX + 1, lPointy - 1] = 1;
                        }
                        else
                        {
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX + 1, lPointy - 1] = 1;
                            battleFiled[lPointX + 1, lPointy + 1] = 1;
                        }
                    }
                    if (lPointX + 1 >= n)
                    {
                        if (lPointy + 1 >= m)
                        {
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX - 1, lPointy - 1] = 1;
                        }
                        else if (lPointy - 1 < 0)
                        {
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX - 1, lPointy + 1] = 1;
                        }
                        else
                        {
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX - 1, lPointy - 1] = 1;
                            battleFiled[lPointX - 1, lPointy + 1] = 1;
                        }
                    }
                    if (lPointy - 1 < 0)
                    {
                        if (lPointX + 1 >= n)
                        {
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX - 1, lPointy + 1] = 1;
                        }
                        else if (lPointX - 1 < 0)
                        {
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX + 1, lPointy + 1] = 1;

                        }
                        else
                        {
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy + 1] = 1;
                            battleFiled[lPointX - 1, lPointy + 1] = 1;
                            battleFiled[lPointX + 1, lPointy + 1] = 1;
                        }
                    }
                    if (lPointy + 1 >= m)
                    {
                        if (lPointX + 1 >= n)
                        {
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX - 1, lPointy - 1] = 1;
                        }
                        else if (lPointX - 1 < 0)
                        {
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX + 1, lPointy - 1] = 1;

                        }
                        else
                        {
                            battleFiled[lPointX - 1, lPointy] = 1;
                            battleFiled[lPointX + 1, lPointy] = 1;
                            battleFiled[lPointX, lPointy - 1] = 1;
                            battleFiled[lPointX - 1, lPointy - 1] = 1;
                            battleFiled[lPointX + 1, lPointy - 1] = 1;
                        }
                    }
                }
            }
            #endregion

            return battleFiled;
        }

        private int[][] ToJaggedArray(int[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            int[][] jaggedArray = new int[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new int[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;

        }

        private int FindMaxShip(int n, int m, List<Coordinates> coordinates)
        {
            int[,] battleField = new int[n, m];

            battleField = FindFirstPoints(n, m, coordinates);
            battleField = FindLastPoints(n, m, battleField, coordinates);
            battleField = FindDeadPoints(n, m, battleField, coordinates);


            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.Write(string.Format("{0} ", battleField[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}

            int[][] resultarray = ToJaggedArray(battleField);

            GfG result = new GfG();
            return result.maximalAreaOfSubMatrixOfAll1(resultarray, n, m);

        }

        private List<Coordinates> ReadCoordinates(int k, List<string> lines)
        {

            List<Coordinates> coordinates = new List<Coordinates>();

            if (lines.Count == k)
            {
                foreach (var line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        var coordinatesStringArray = line.Split(_whitespace);
                        if (coordinatesStringArray.Length == 4)
                        {
                            FirstPoint firstPoint = new FirstPoint();
                            LastPoint lastPoint = new LastPoint();

                            if (Int32.TryParse(coordinatesStringArray[0], out int firstx) &&
                                Int32.TryParse(coordinatesStringArray[1], out int firsty))
                            {
                                firstPoint = new FirstPoint(firstx, firsty);
                            }
                            else { throw new Exception("INPUT.txt file incorrect coordinates input"); }

                            if (Int32.TryParse(coordinatesStringArray[2], out int lastx) &&
                                Int32.TryParse(coordinatesStringArray[3], out int lasty))
                            {
                                lastPoint = new LastPoint(lastx, lasty);
                            }
                            else { throw new Exception("INPUT.txt file incorrect coordinates input"); }

                            coordinates.Add(new Coordinates(firstPoint, lastPoint));
                        }
                        else { throw new Exception("INPUT.txt file incorrect coordinates input"); }
                    }
                }

                return coordinates;
            }

            return new List<Coordinates>();
        }

        public string ExecuteSecondLab(string inputFilePath, string outputFilePath)
        {

            #region MainLogic
            int n = 0;
            int m = 0;
            int k = 0;

            string resultView = String.Empty;

            string input = String.Empty;
            string output = String.Empty;
            List<string> lines = new List<string>();
            
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
                return "Incorrect input of file";
            }

            try
            {
                lines = File.ReadLines(input).ToList();
            }
            catch
            {
                throw new Exception("Incorrect file path");
            }

            if (lines != null && lines.Count > 0)
            {

                string data = lines.FirstOrDefault(x => !String.IsNullOrEmpty(x));

                if (!String.IsNullOrEmpty(data))
                {
                    var datas = data.Split(_whitespace);

                    if (datas.Length == 3)
                    {
                        if (Int32.TryParse(datas[0], out int nbuff)) { n = nbuff; }
                        else { throw new Exception("INPUT.txt file incorrect input in first line"); }

                        if (Int32.TryParse(datas[1], out int mbuff)) { m = mbuff; }
                        else { throw new Exception("INPUT.txt file incorrect input in first line"); }

                        if (Int32.TryParse(datas[2], out int kbuff)) { k = kbuff; }
                        else { throw new Exception("INPUT.txt file incorrect input in first line"); }
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

                List<Coordinates> coordinates = ReadCoordinates(k, lines.Skip(1).ToList());


                int shipMaxSize = FindMaxShip(n, m, coordinates);
                using (StreamWriter writer = new StreamWriter(output))
                {
                    writer.Write(shipMaxSize.ToString());
                    resultView = shipMaxSize.ToString();
                }
            }
            #endregion

            return resultView;
        }
    }
}
