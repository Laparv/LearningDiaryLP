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

            //constructor for new entry and dictionary
            Topic entry = new Topic();
            Dictionary<int, Topic> listOfTopics = new Dictionary<int, Topic>();

            entry.RunningId();
            entry.GetTitle();
            entry.GetDescription();
            entry.GetEstimatedTime();
            entry.GetSpentTime();
            entry.GetSource();
            entry.GetStartDate();
            entry.IsInProgress();
            entry.GetCompletionDate();


            //Add entry to list 
            listOfTopics.Add(entry.Id, entry);

            //print string to textfile
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(entry.CompileString());
                sw.WriteLine("------------------------------------------");
            }

            Console.WriteLine("\nEntry added to learning diary! \n");

            /*//read back the entries to user
            string previousEntries = System.IO.File.ReadAllText(@"C:\Users\Lasse\source\repos\LearningDiaryLP\LearningDiaryTextFile.txt");
            Console.WriteLine(previousEntries);*/


            Console.WriteLine("Write entry ID to print it out");


          int userIdInput = Convert.ToInt32(Console.ReadLine());

            if (listOfTopics.ContainsKey(userIdInput))
            {
                Console.WriteLine(listOfTopics[userIdInput].CompileString());
            }
            else
            {
                Console.WriteLine("No entry with that ID found.");
            }


            Console.ReadLine();

        }

    }

}
