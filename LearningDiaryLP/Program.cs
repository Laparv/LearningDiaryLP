using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;
using ClassLibraryLearningDiary;
//tämä on MAIN branch
namespace LearningDiaryLP
{
    class Program
    {

        static void Main(string[] args)
        {

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
                //Console.WriteLine("6) Check if date of entry is in the future: ");
                // Console.WriteLine("7) Check if date late: ");
                var menuPick = Console.ReadLine();

                //Add entry to diary
                if (menuPick == "1")
                {
                    AddEntry();
                    Console.WriteLine("\nEntry added to learning diary! \n");
                    Console.ReadLine();
                    continue;
                }
                //read previous entry from diary. Search with id or title
                else if (menuPick == "2")
                {
                    ReadEntry();
                }
                //edit an entry
                else if (menuPick == "3")
                {
                    EditTopic();
                }
                //entry deletion
                else if (menuPick == "4")
                {
                    DeleteTopic();
                }
                
                //exit app
                else if (menuPick == "5")
                {
                    break;
                }

            } while (true);

        }
        public static void AddEntry() //adding entry, uses Topic class methods and then adds them to database
        {
            Console.Clear();
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {


                Topic entry = new Topic();
                //entry.RunningId(); not needed, sql does it
                entry.GetTitle();
                entry.GetDescription();
                entry.GetEstimatedTime();
                entry.GetSpentTime();
                entry.GetSource();
                entry.GetStartDate();
                entry.IsInProgress();
                entry.GetCompletionDate();

                var tableOfTopics = connectionToDatabase.Topics.Select(top => top);

                Models.Topic dbTopic = new Models.Topic()
                {
                    //Id = entry.Id, not needed, sql does it
                    Title = entry.Title,
                    Description = entry.Description,
                    TimeToMaster = Convert.ToInt32(entry.EstimatedTimeToMaster),
                    TimeSpent = Convert.ToInt32(entry.TimeSpent),
                    Source = entry.Source,
                    StartLearningDate = entry.StartLearningDate,
                    InProgress = entry.InProgress,
                    CompletionDate = entry.CompletionDate
                };
                connectionToDatabase.Topics.Add(dbTopic);
                connectionToDatabase.SaveChanges();
            }
        }
        public static void ReadEntry() // reads entry back to user and informs if it is on schedule
        {
            Console.Clear();
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                Console.WriteLine("1) Search by ID\n2)Search by Title");
                switch (Console.ReadLine())
                {
                    case "1":
                                Console.Clear();
                                Console.WriteLine("Write entry ID to print it out");
                                int userIdInput = Convert.ToInt32(Console.ReadLine());
                                var idSearchString = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);

                                foreach (var item in idSearchString)
                                {
                                    Console.Clear();
                                    Console.WriteLine(item.CompileString());
                                }
                                Console.ReadLine();
                                break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Search with title:");
                        string userTitleInput = Console.ReadLine();
                        var titleSearchString = connectionToDatabase.Topics.Where(topic => topic.Title.Contains(userTitleInput)).FirstOrDefault();

                        Console.Clear();
                        Console.WriteLine(titleSearchString.CompileString());
                        Console.ReadLine();
                        break;

                    default: break;
                }

            }
        }

        public static void EditTopic() //edit different info of topics and save them to database
        {
            Console.Clear();
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                Console.WriteLine("Enter an ID of entry to edit: ");
                int userIdInput = Convert.ToInt32(Console.ReadLine());
                var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                Console.Clear();
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
                            Console.Clear();
                            Console.WriteLine("Change title to: ");
                            topic.Title = Console.ReadLine();

                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    case "2":
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change description to: ");
                            topic.Description = Console.ReadLine();
                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    case "3":
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("The new estimated time is: ");
                            topic.TimeToMaster = Convert.ToInt32(Console.ReadLine());
                            topic.EditIsInProgress();
                            topic.EditCompletionDate();
                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    case "4":
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Spent time: ");
                            topic.TimeSpent = Convert.ToInt32(Console.ReadLine());
                            topic.EditIsInProgress();
                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    case "5":
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change source: ");
                            topic.Source = Console.ReadLine();
                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    case "6":
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change start date: ");
                            topic.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
                            topic.EditIsInProgress();
                            topic.EditCompletionDate();
                        }
                        connectionToDatabase.SaveChanges();
                        break;

                    default:
                        break;
                }
            }
        }
        public static void DeleteTopic() //delete topic based off of id
        {
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                Console.Clear();
                Console.WriteLine("Enter an ID of entry to delete: ");
                int userIdInput = Convert.ToInt32(Console.ReadLine());

                var topicToDelete = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);

                foreach (var item in topicToDelete)
                {
                    connectionToDatabase.Topics.Remove(item);
                }
                connectionToDatabase.SaveChanges();

                Console.WriteLine($"Entry {userIdInput} removed.");
                Console.ReadLine();
            }
        }
    }
}



