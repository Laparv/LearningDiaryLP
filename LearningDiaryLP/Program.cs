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

            Topic a = new Topic();

            string compiledString = a.CompileString();

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(compiledString);
            }
        
           
            
        }
    }

}
