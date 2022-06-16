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
            Dictionary<int, Topic> listOfTopics = new Dictionary<int, Topic>();

            do
            {
                //menu
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add entry");
                Console.WriteLine("2) Read previous entry");
                Console.WriteLine("3) Exit");
                var menuPick = Console.ReadLine();

                //Add entry to diary
                if (menuPick == "1")
                {
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

                    listOfTopics.Add(entry.Id, entry);

                    Console.WriteLine("\nEntry added to learning diary! \n");
                    Console.ReadLine();
                    continue;
                }
                //read previous entry from diary
                else if (menuPick == "2")
                {
                    Console.WriteLine("1) Search by ID\n2)Search by Title");
                    switch (Console.ReadLine())
                    {
                        case "1":

                            Console.WriteLine("Write entry ID to print it out");
                            int userIdInput = Convert.ToInt32(Console.ReadLine());


                            if (listOfTopics.ContainsKey(userIdInput))
                            {
                                Console.WriteLine(listOfTopics[userIdInput].CompileString());
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Nothing found with that ID");
                                Console.ReadLine();

                            }
                            continue;

                        case "2": 
                            Console.WriteLine("Search with title:");
                            string userTitleInput = Console.ReadLine();
                            int readerKey = listOfTopics.FirstOrDefault(x => x.Value.Title == userTitleInput).Key;

                            if (listOfTopics.ContainsKey(readerKey))
                            {
                                Console.WriteLine(listOfTopics[readerKey].CompileString());
                                Console.ReadLine();
                            }
                            
                            
                            /*var result = listOfTopics.Where(topic => topic.Value.Title.Contains(userTitleInput));


                            result = from topic in listOfTopics
                                     where topic.Value.Title.Contains(userTitleInput)
                                     select topic;

                            foreach (var topic in result)
                            {
                                Console.WriteLine(topic.ToString());
                            }*/


                            //var readEntry = listOfTopics.Where(topic => topic.Value.Title.Contains(userTitleInput));




                            //listOfTopics.Where(topic => topic.Value.Title.Contains(userTitleInput));

                            //IEnumerable<Topic> result = (IEnumerable<Topic>)listOfTopics.Where(topic => topic.Value.Title.Contains(userTitleInput));


                            Console.ReadLine();

                            continue;

                        default: continue;
                    }
                    
                }
                //exit app
                else if (menuPick == "3")
                {
                    break;
                }

            } while (true);
        }
    }
}
      

