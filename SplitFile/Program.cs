using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFile
{
    public class Program
    {
        static void Main(string[] args)
        {
            String[] opts = { "Factorial", "Split" };
            String[] yesno = { "Yes", "No" };

            String choice = Validate(opts);

            Console.WriteLine("Recursively?");
            String recursive = Validate(yesno);

            if (choice.ToLower().Equals("factorial"))
            {
                if(recursive.ToLower().Equals("yes"))
                {
                    Console.WriteLine("What number?");
                    Console.WriteLine(Factorial(ValidateInt()));
                }
                else
                {
                    Console.WriteLine("What number?");
                    Console.WriteLine(FactorialLoop(ValidateInt()));
                }
            }
            else
            {
                if (recursive.ToLower().Equals("yes"))
                {
                    Console.WriteLine("Defaults?");
                    bool def = Validate(yesno).ToLower().Equals("yes");
                    if (def)
                    {
                        SplitLoop("C:\\Users\\Magolor\\Documents\\Input");
                    }
                    else
                    {
                        Console.WriteLine("Input a file path.");
                        String path = Console.ReadLine();
                        Console.WriteLine("Input a file path.");
                        String file = Console.ReadLine();
                        Console.WriteLine("Choose a limit.");
                        Split(path, file, ValidateInt());
                    }
                }
                else
                {
                    Console.WriteLine("Defaults?");
                    bool def = Validate(yesno).ToLower().Equals("yes");
                    if (def)
                    {
                        SplitLoop("C:\\Users\\Magolor\\Documents\\Input");
                    }
                    else
                    {
                        Console.WriteLine("Input a file path.");
                        String path = Console.ReadLine();
                        Console.WriteLine("Input a file path.");
                        String file = Console.ReadLine();
                        Console.WriteLine("Choose a limit.");
                        SplitLoop(path, file, ValidateInt());
                    }
                }
            }
        }

        public static String Validate(String[] options)
        {
            Console.Write("Please input one of the following: ");
            Console.WriteLine(String.Join(", ", options));
            while (true)
            {
                String input = Console.ReadLine();

                foreach (String option in options)
                {
                    if (input.ToLower().Equals(option.ToLower()))
                    {
                        return input;
                    }
                }
                Console.WriteLine("Please try again.");
            }
        }

        public static int ValidateInt()
        {
            Console.WriteLine("Please input an integer.");
            while (true)
            {
                String input = Console.ReadLine();

                try
                {
                    return int.Parse(input);
                }
                catch
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }

        public static int Factorial(int num)
        {
            if (num <= 1)
            {
                return 1;
            }
            return num * Factorial(num - 1);
        }

        public static int FactorialLoop(int num)
        {
            int result = 1;
            for(int i = num; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        public static void Split(String path, string fileName="input", int limit=2000, int count=0)
        {
            byte[] input = File.ReadAllBytes(path + "\\" + fileName + ".txt");
            int length = input.Length;

            if (length - limit * count < limit)
            {
                File.WriteAllBytes(String.Format(path + "\\" + fileName + "{0,3:000}.txt", count + 1), input.Skip(limit * count).ToArray());
            }
            else
            {
                File.WriteAllBytes(String.Format(path + "\\" + fileName + "{0,3:000}.txt", count + 1), input.Skip(limit * count).Take(limit).ToArray());
                Split(path, fileName, limit, count+1);
            }
            return;
        }

        public static void SplitLoop(String path, String fileName="input", int limit=2000)
        {
            byte[] input = File.ReadAllBytes(path + "\\" + fileName + ".txt");
            int length = input.Length;

            int loops = (int)Math.Ceiling(length / (double)limit);
            for (int i = 0; i < loops; i++)
            {
                if (i < loops - 1)
                {
                    File.WriteAllBytes(String.Format(path + "\\" + fileName + "{0,3:000}.txt", i + 1), input.Skip(limit * i).Take(limit).ToArray());
                }
                else
                {
                    File.WriteAllBytes(String.Format(path + "\\" + fileName + "{0,3:000}.txt", i + 1), input.Skip(limit * i).ToArray());
                }
            }
        }
    }
}
