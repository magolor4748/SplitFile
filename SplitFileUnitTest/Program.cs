using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static SplitFile.Program;

namespace SplitFileUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Xunit.Assert.Equal(3628800, Factorial(10));
            Xunit.Assert.Equal(3628800, FactorialLoop(10));
            Directory.SetCurrentDirectory("C:\\Users\\Magolor\\source\\repos\\SplitFile\\Test");
            string[] toDelete = Directory.GetFiles(Directory.GetCurrentDirectory(), "input[0-9]+");
            foreach (string splitted in toDelete)
            {
                File.Delete(splitted);
            }
            Split(Directory.GetCurrentDirectory());
            string f = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "input003.txt")).ReadToEnd();
            Xunit.Assert.Equal(",", f);
            Xunit.Assert.Equal(1, f.Length);
            foreach (string splitted in toDelete)
            {
                File.Delete(splitted);
            }
            f = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "input003.txt")).ReadToEnd();
            SplitLoop(Directory.GetCurrentDirectory());
            Xunit.Assert.Equal(",", f);
            Xunit.Assert.Equal(1, f.Length);
        }
    }
}
