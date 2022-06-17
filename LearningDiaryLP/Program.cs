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
                Console.WriteLine("3) Edit entry");
                Console.WriteLine("4) Delete entry");
                Console.WriteLine("5) Exit");
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
                //edit an entry
                else if (menuPick == "3")
                {
                    Console.WriteLine("Enter an ID of entry to edit: ");
                    int userIdInput = Convert.ToInt32(Console.ReadLine());

                    var topicToEdit = listOfTopics.Where(h => h.Key == userIdInput);

                    Console.WriteLine("1) Edit title");
                    Console.WriteLine("2) Edit description");
                    Console.WriteLine("3) Edit estimated time");
                    Console.WriteLine("4) Edit time spent");
                    Console.WriteLine("5) Edit source");
                    Console.WriteLine("6) Edit starting date");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditTitle();
                            }
                            continue;

                        case "2":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditDescription();
                            }
                            continue;
                        case "3":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditEstimatedTime();
                                topic.Value.IsInProgress();
                                topic.Value.GetCompletionDate();
                            }
                            continue;
                        case "4":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditSpentTime();
                                topic.Value.IsInProgress();
                                topic.Value.GetCompletionDate();
                            }
                            continue;
                        case "5":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditSource();
                            }
                            continue;
                        case "6":
                            foreach (var topic in topicToEdit)
                            {
                                topic.Value.EditStartDate();
                                topic.Value.IsInProgress();
                                topic.Value.GetCompletionDate();
                            }
                            continue;

                        default:
                            break;
                    }

                }
                //entry deletion
                else if (menuPick == "4")
                {
                    Console.WriteLine("Enter an ID of entry to delete: ");
                    int userIdInput = Convert.ToInt32(Console.ReadLine());

                    var topicToDelete = listOfTopics.Remove(userIdInput);
                    Console.WriteLine($"Entry {userIdInput} removed.");
                }
                //exit app
                else if (menuPick == "5")
                {
                    break;
                }

            } while (true);
        }
    }
}
      

