using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LearningDiaryLP
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\Lasse\source\repos\LearningDiaryLP\LearningDiaryTextFile.txt";

            Console.WriteLine("Learning diary. Leave entry below");

            //constructor for new entry
            Topic entry = new Topic();

            //compile inputs to string
            string compiledString = entry.CompileString();

            //print string to textfile
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(compiledString);
                sw.WriteLine("------------------------------------------");
            }

            Console.WriteLine("\nEntry added to learning diary! Check your entries below\n");

            //read back the entries to user
            string previousEntries = System.IO.File.ReadAllText(@"C:\Users\Lasse\source\repos\LearningDiaryLP\LearningDiaryTextFile.txt");
            Console.WriteLine(previousEntries);

            Console.ReadLine();

        }
    }

}
