using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;
//tämä on DEV branch
namespace LearningDiaryLP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
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
                    var menuPick = Console.ReadLine();

                    //Add entry to diary
                    if (menuPick == "1")
                    {

                        Topic entry = new Topic();
                        //entry.RunningId();
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
                                //Id = entry.Id,
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

                                
                                
                                    var idSearchString = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);

                                    foreach (var item in idSearchString)
                                    {
                                        Console.WriteLine(item.CompileString());
                                    }
                                Console.ReadLine();

                                     continue;

                                 case "2":
                                     Console.WriteLine("Search with title:");
                                     string userTitleInput = Console.ReadLine();

                                var titleSearchString = connectionToDatabase.Topics.Where(topic => topic.Title.Contains(userTitleInput)).Single();
                                
                                Console.WriteLine(titleSearchString.CompileString());
                                
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

                            var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);


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
                                        Console.WriteLine("Change title to: ");
                                        topic.Title = Console.ReadLine();

                                    }
                                    connectionToDatabase.SaveChanges();
                                    continue;

                                case "2":
                                    foreach (var topic in topicToEdit)
                                    {
                                        Console.WriteLine("Change description to: ");
                                        topic.Description = Console.ReadLine();
                                    }
                                    connectionToDatabase.SaveChanges();
                                    continue;
                                case "3":
                                    foreach (var topic in topicToEdit)
                                    {
                                        Console.WriteLine("The new estimated time is: ");
                                        topic.TimeToMaster = Convert.ToInt32(Console.ReadLine());
                                        //connectionToDatabase.Update(topic.CompletionDate);

                                    }
                                    connectionToDatabase.SaveChanges();
                                    continue;
                                case "4":
                                    foreach (var topic in topicToEdit)
                                    {
                                        Console.WriteLine("Spent time: ");
                                        //topic.Value.IsInProgress();
                                        //topic.Value.GetCompletionDate();
                                    }
                                    connectionToDatabase.SaveChanges();
                                    continue;
                                case "5":
                                    foreach (var topic in topicToEdit)
                                    {
                                        Console.WriteLine("Change source: ");
                                        topic.Source = Console.ReadLine();
                                    }
                                    connectionToDatabase.SaveChanges();
                                    continue;
                                case "6":
                                    foreach (var topic in topicToEdit)
                                    {
                                        Console.WriteLine("Change start date: ");
                                        topic.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
                                        //topic.Value.IsInProgress();
                                        // topic.Value.GetCompletionDate();
                                    }
                                    connectionToDatabase.SaveChanges();
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

                        var topicToDelete = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);

                        foreach (var item in topicToDelete)
                        {
                            connectionToDatabase.Topics.Remove(item);
                        }
                        connectionToDatabase.SaveChanges();

                        //var topicToDelete = listOfTopics.Remove(userIdInput);
                        Console.WriteLine($"Entry {userIdInput} removed.");
                        Console.ReadLine();
                    }
                    //exit app
                    else if (menuPick == "5")
                    {
                        break;
                    }

                } while (true);


            }
        }
    } }
      

