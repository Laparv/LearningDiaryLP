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
            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = MainMenu();
            }

        }
        private static bool MainMenu()
        {
            string path = @"C:\Users\Lasse\source\repos\LearningDiaryLP\LearningDiaryTextFile.txt";
            Dictionary<int, Topic> listOfTopics = new Dictionary<int, Topic>();

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add entry");
            Console.WriteLine("2) Read previous entry");
            Console.WriteLine("3) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Topic entry = new Topic();
                    entry.RunningId();
                    entry.GetTitle();
                    entry.GetDescription();
                    entry.GetEstimatedTime();
                    entry.GetSpentTime();
                    entry.GetSource();
                    entry.GetStartDate();
                    entry.IsInProgress();
                    entry.GetCompletionDate();

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(entry.CompileString());
                        sw.WriteLine("------------------------------------------");
                    }

                    Console.WriteLine("\nEntry added to learning diary! \n");
                    return true;

                case "2":
                    //read back the entries to user
                    /*string previousEntries = System.IO.File.ReadAllText(@"C:\Users\Lasse\source\repos\LearningDiaryLP\LearningDiaryTextFile.txt");
                    Console.WriteLine(previousEntries);*/
                    Console.WriteLine("Write entry ID to print it out");
                    int userIdInput = Convert.ToInt32(Console.ReadLine());

                    if (listOfTopics.ContainsKey(userIdInput))
                    {
                        Console.WriteLine(listOfTopics[userIdInput].CompileString());
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No entry with that ID found.");
                    }
                    return true;

                case "3":
                    return false;
                default:
                    return true;
            }
        }

    }

}
