using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ThreeTasksLibrary.Laba3Models;

namespace ThreeTasksLibrary
{
    public class Laba3
    {
        public string LAB_PATH = "";

        private int dist2(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;

            return dx * dx + dy * dy;
        }

        public string ExecuteThirdLab(string inputFilePath, string outputFilePath)
        {
            string input = String.Empty;
            string output = String.Empty;
            string resultView = String.Empty;
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

            if (lines.Count > 0)
            {

                string data = lines.FirstOrDefault(x => !String.IsNullOrEmpty(x));

                int n = 0;

                if (Int32.TryParse(data, out int nbuff)) { n = nbuff; }
                else { throw new Exception("INPUT.txt file incorrect input in first line"); }

                List<Point> points = new List<Point>();

                foreach (var line in lines.Skip(1))
                {
                    var point = line.Split(' ');

                    int x;
                    int y;

                    if (Int32.TryParse(point[0], out int xbuff)) { x = xbuff; }
                    else { throw new Exception("INPUT.txt file incorrect input in coodtinates"); }

                    if (Int32.TryParse(point[1], out int ybuff)) { y = ybuff; }
                    else { throw new Exception("INPUT.txt file incorrect input in coodtinates"); }


                    points.Add(new Point(x, y));
                }

                int left = 0;
                int right = 20000 * 20000 * 2 + 1;
                List<int> ansColor = new List<int>();
                while (left + 1 < right)
                {
                    int mid = (left + right) / 2;
                    const int UNDEF = 0;
                    List<int> color = new List<int>(new int[n]);
                    List<int> stack = new List<int>();
                    bool good = true;
                    for (int i = 0; i < n && good; i++)
                    {
                        if (color[i] == UNDEF)
                        {
                            stack.Add(i);
                            color[i] = 1;
                            while (stack.Count != 0 && good)
                            {
                                int cur = stack.Last();
                                stack.RemoveAt(stack.Count - 1);
                                for (int next = 0; next < n; next++)
                                {
                                    if (next != cur && dist2(points[cur], points[next]) < mid)
                                    {
                                        if (color[next] == 0)
                                        {
                                            color[next] = 3 - color[cur];
                                            stack.Add(next);

                                        }
                                        else if (color[next] == color[cur])
                                        {
                                            good = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (good)
                    {
                        left = mid;
                        ansColor = color;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                using (StreamWriter writer = new StreamWriter(output))
                {
                    writer.Write($"{Math.Sqrt(left) / 2}");
                    resultView += $"{Math.Sqrt(left) / 2}     ";
                    writer.WriteLine();
                    Debug.Assert(left > 0);
                    Debug.Assert(ansColor.Count != 0);

                    for (int i = 0; i < n; i++)
                    {
                        writer.Write($"{ansColor[i]} ");
                        resultView += $"{ansColor[i]} ";
                    }
                }
            }
            else
            {
                Console.WriteLine("Input file was empty");
            }
            return resultView;
        }
    }
}
