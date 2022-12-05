using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;
using ThreeTasksLibrary;

namespace Lab4
{
    internal class Program
    {
        //dotnet Lab4.dll labs lab1 --input "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\FirstLabaIOFiles\Input.txt" --output "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\FirstLabaIOFiles\Output.txt"
        //dotnet Lab4.dll labs lab2 --input "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\SecondLabaIOFiles\Input.txt" --output "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\SecondLabaIOFiles\Output.txt"
        //dotnet Lab4.dll labs lab3 --input "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\ThirdLabaIOFIles\Input.txt" --output "D:\Универ\Практические 4 курс\Кросплатформенная разработка\Programs\Lab4\ThirdLabaIOFIles\Output.txt"

        private static readonly string _labPathFileName = "LAB_PATH.txt";
        private static readonly string _inputFileName = "Input.txt";
        private static readonly string _outputFileName = "Output.txt";

        private static string FileExistToString(bool exist)
        {
            return exist ? "Exist" : "Not found";  
        }

        static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Lab4",
                Description = "Console application",
            };

            app.HelpOption(inherited: true);

            app.Command("version", vr =>
            {
                vr.OnExecute(() =>
                {
                    Console.WriteLine("Author - Ganzha-Pupyshev Bogdan IPZ-44");
                    Console.WriteLine("Version 1.0.0");
                });
            });


            app.Command("labs", configCmd =>
            {
                configCmd.OnExecute(() =>
                {
                    Console.WriteLine("Specify a lab to execute");  
                    return 1;
                });

                Laba1 lab1 = new Laba1();
                Laba2 lab2 = new Laba2();
                Laba3 lab3 = new Laba3();

                var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));

                configCmd.Command("lab_path", ladpath =>
                {
                    ladpath.Description = "Set LAB_PATH";

                    var lab_path = ladpath.Argument("key", "Location of IO files directory").IsRequired();

                    ladpath.OnExecute(() =>
                    {

                        Console.WriteLine(path);

                        bool isNullorEmpty = String.IsNullOrEmpty(lab_path.Value);
                        bool isDirectoryExist = Directory.Exists(lab_path.Value);

                        if (!isNullorEmpty && isDirectoryExist)
                        {                  
                            string labPathLocation = Path.Combine(path, _labPathFileName);
                            Console.WriteLine(labPathLocation);
                            File.WriteAllText(labPathLocation, String.Empty);
                            using(StreamWriter writer = new StreamWriter(labPathLocation))
                            {                     
                                 writer.Write(lab_path.Value);                               
                            }
                        }

                    });

                });

                configCmd.Command("lab1", lab1Cmd =>
                {
                    lab1Cmd.Description = "Execute LABA1";

                    var input = lab1Cmd.Option("--input", "input file", CommandOptionType.SingleValue);
                    var output = lab1Cmd.Option("--output", "output file", CommandOptionType.SingleValue);

                    lab1Cmd.OnExecute(() =>
                    {
                        bool inExist = File.Exists(input.Value());
                        bool outExist = File.Exists(output.Value());
                        bool pathFileExist = File.Exists(Path.Combine(path, _labPathFileName));
                        Console.WriteLine("lab1 Works!!!");
                        Console.WriteLine(Path.Combine(path, _labPathFileName));

                        Console.WriteLine("===========================================================");
                        Console.WriteLine($"Input file {input.Value()} {FileExistToString(inExist)}!");
                        Console.WriteLine($"Input file {output.Value()} {FileExistToString(outExist)}!");

                        if (inExist || outExist)
                        {
                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Input file content:");
                            string inputFileData = File.ReadAllText(input.Value());
                            Console.WriteLine(!String.IsNullOrEmpty(inputFileData) ? inputFileData : "Input file was empty");                         
                            lab1.ExecuteFirstLab(input.Value(), output.Value());

                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Output file content:");
                            string outputFileData = String.Empty;
                            outputFileData = File.ReadAllText(output.Value());
                            Console.WriteLine(!String.IsNullOrEmpty(outputFileData) ? outputFileData : "Output file was empty");
                        }
                        else if(pathFileExist && !String.IsNullOrEmpty(File.ReadAllText(Path.Combine(path, _labPathFileName))))
                        {
                            Console.WriteLine("LAB_PATH Exist!!!");
                            string pathToDirectory = File.ReadAllText(Path.Combine(path, _labPathFileName));

                            Console.WriteLine($"Input file path:{Path.Combine(pathToDirectory, _inputFileName)}");
                            Console.WriteLine($"Output file path: {Path.Combine(pathToDirectory, _outputFileName)}");

                            bool labPathInExist = File.Exists(Path.Combine(pathToDirectory, _inputFileName));
                            Console.WriteLine(labPathInExist);
                            bool labPathOupExist = File.Exists(Path.Combine(pathToDirectory, _outputFileName));

                            if(labPathInExist)
                            {
                                Console.WriteLine("===========================================================");
                                Console.WriteLine("Input file content:");
                                string inputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _inputFileName));
                                Console.WriteLine(inputFileData);
                                lab1.LAB_PATH = pathToDirectory;
                                lab1.ExecuteFirstLab(String.Empty, String.Empty);

                                if (labPathOupExist)
                                {
                                    Console.WriteLine("===========================================================");
                                    Console.WriteLine("Output file content:");
                                    string outputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _outputFileName));
                                    Console.WriteLine(outputFileData);
                                }
                                else
                                {
                                    Console.WriteLine("Output file not found");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input file not found");
                            }  
                        }
                        else
                        {
                            Console.WriteLine("IO files was not found");
                        }

                    });
                });

                configCmd.Command("lab2", lab2Cmd =>
                {
                    lab2Cmd.Description = "Execute LABA2";

                    var input = lab2Cmd.Option("--input", "input file", CommandOptionType.SingleValue);
                    var output = lab2Cmd.Option("--output", "output file", CommandOptionType.SingleValue);

                    lab2Cmd.OnExecute(() =>
                    {
                        bool inExist = File.Exists(input.Value());
                        bool outExist = File.Exists(output.Value());
                        bool pathFileExist = File.Exists(Path.Combine(path, _labPathFileName));

                        Console.WriteLine("lab2 Works!!!");

                        Console.WriteLine("===========================================================");
                        Console.WriteLine($"Input file {input.Value()} {FileExistToString(inExist)}!");
                        Console.WriteLine($"Input file {output.Value()} {FileExistToString(outExist)}!");

                        if (inExist || outExist)
                        {
                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Input file content:");
                            string inputFileData = File.ReadAllText(input.Value());
                            lab2.ExecuteSecondLab(input.Value(), output.Value());

                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Output file content:");
                            string outputFileData = String.Empty;
                            outputFileData = File.ReadAllText(output.Value());
                            Console.WriteLine(!String.IsNullOrEmpty(outputFileData) ? outputFileData : "Output file was empty");
                        }
                        else if (pathFileExist && !String.IsNullOrEmpty(File.ReadAllText(Path.Combine(path, _labPathFileName))))
                        {
                            Console.WriteLine("LAB_PATH Exist!!!");
                            string pathToDirectory = File.ReadAllText(Path.Combine(path, _labPathFileName));

                            Console.WriteLine($"Input file path:{Path.Combine(pathToDirectory, _inputFileName)}");
                            Console.WriteLine($"Output file path: {Path.Combine(pathToDirectory, _outputFileName)}");

                            bool labPathInExist = File.Exists(Path.Combine(pathToDirectory, _inputFileName));
                            bool labPathOupExist = File.Exists(Path.Combine(pathToDirectory, _outputFileName));
                            if (labPathInExist)
                            {
                                Console.WriteLine("===========================================================");
                                Console.WriteLine("Input file content:");
                                string inputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _inputFileName));
                                Console.WriteLine(inputFileData);
                                lab2.LAB_PATH = pathToDirectory;
                                lab2.ExecuteSecondLab(String.Empty, String.Empty);

                                if (labPathOupExist)
                                {
                                    Console.WriteLine("===========================================================");
                                    Console.WriteLine("Output file content:");
                                    string outputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _outputFileName));
                                    Console.WriteLine(outputFileData);
                                }
                                else
                                {
                                    Console.WriteLine("Output file not found");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input file not found");
                            }

                        }
                    });

                });

                configCmd.Command("lab3", lab3Cmd =>
                {
                    lab3Cmd.Description = "Execute LABA3";

                    var input = lab3Cmd.Option("--input", "input file", CommandOptionType.SingleValue);
                    var output = lab3Cmd.Option("--output", "output file", CommandOptionType.SingleValue);

                    lab3Cmd.OnExecute(() =>
                    {
                        bool inExist = File.Exists(input.Value());
                        bool outExist = File.Exists(output.Value());
                        bool pathFileExist = File.Exists(Path.Combine(path, _labPathFileName));

                        Console.WriteLine("lab3 Works!!!");

                        if (inExist || outExist)
                        {
                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Input file content:");
                            string inputFileData = File.ReadAllText(input.Value());
                            Laba3 lab3 = new Laba3();
                            string result = lab3.ExecuteThirdLab(input.Value(), output.Value());

                            Console.WriteLine("===========================================================");
                            Console.WriteLine("Output file content:");
                            string outputFileData = String.Empty;
                            outputFileData = File.ReadAllText(output.Value());
                            Console.WriteLine(!String.IsNullOrEmpty(outputFileData) ? outputFileData : "Output file was empty");
                        }
                        else if (pathFileExist && !String.IsNullOrEmpty(File.ReadAllText(Path.Combine(path, _labPathFileName))))
                        {
                            Console.WriteLine("LAB_PATH Exist!!!");
                            string pathToDirectory = File.ReadAllText(Path.Combine(path, _labPathFileName));

                            Console.WriteLine($"Input file path:{Path.Combine(pathToDirectory, _inputFileName)}");
                            Console.WriteLine($"Output file path: {Path.Combine(pathToDirectory, _outputFileName)}");

                            bool labPathInExist = File.Exists(Path.Combine(pathToDirectory, _inputFileName));
                            bool labPathOupExist = File.Exists(Path.Combine(pathToDirectory, _outputFileName));
                            if (labPathInExist)
                            {
                                Console.WriteLine("===========================================================");
                                Console.WriteLine("Input file content:");
                                string inputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _inputFileName));
                                Console.WriteLine(inputFileData);
                                lab3.LAB_PATH = pathToDirectory;
                                lab3.ExecuteThirdLab(String.Empty, String.Empty);

                                if (labPathOupExist)
                                {
                                    Console.WriteLine("===========================================================");
                                    Console.WriteLine("Output file content:");
                                    string outputFileData = File.ReadAllText(Path.Combine(pathToDirectory, _outputFileName));
                                    Console.WriteLine(outputFileData);
                                }
                                else
                                {
                                    Console.WriteLine("Output file not found");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input file not found");
                            }
                        }
                    });

                });
            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Specify command to execute");
                return 1;
            });

            return app.Execute(args);

        }
    }
}
