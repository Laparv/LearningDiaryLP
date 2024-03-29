﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;
using ClassLibraryLearningDiary;
using System.Diagnostics;

namespace LearningDiaryLP
{
    public class StaticMethods
    {
        public static async Task ListAllEntries()
        {
            Console.Clear();
            MethodLibrary check = new MethodLibrary();
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                var listAll = connectionToDatabase.Topics.Select(topic => topic);
                foreach (var topic in listAll)
                {
                    string progString = (topic.InProgress == true) ? "In progress" : "Done";
                    string schedule = ((check.CheckIfLate(Convert.ToDateTime(topic.StartLearningDate), Convert.ToDouble(topic.TimeToMaster)) == false)) ? "late" : "on schedule";
                    Console.WriteLine($"ID: {topic.Id} {topic.Title} | Status: {progString} and {schedule}.");
                }
            }
            Console.ReadLine();
        }
        public static async Task AddEntry() //adding entry, uses Topic class methods and then adds them to database
        {
            Console.Clear();

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
            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                connectionToDatabase.Topics.Add(dbTopic);
                connectionToDatabase.SaveChanges();
            }
            Console.WriteLine("\nEntry added to learning diary! \n");
            Console.ReadLine();
        }
        public static async Task ReadEntry() // reads entry back to user and informs if it is on schedule
        {
            Console.Clear();
            Console.WriteLine("1) Search by ID\n2)Search by Title");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Write entry ID to print it out");
                    int userIdInput = Convert.ToInt32(Console.ReadLine());
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var idSearchString = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);
                        foreach (var item in idSearchString)
                        {
                            Console.Clear();
                            Console.WriteLine(item.CompileString());
                        }
                    }
                    Console.ReadLine();
                    break;

                case '2':
                    Console.Clear();
                    Console.WriteLine("Search with title:");
                    string userTitleInput = Console.ReadLine();
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var titleSearchString = connectionToDatabase.Topics.Where(topic => topic.Title.Contains(userTitleInput));

                        if (titleSearchString.Count() == 1)
                        {
                            Console.WriteLine(titleSearchString.FirstOrDefault().CompileString());
                        }
                        else
                        {
                            Console.WriteLine("We found the following topics with your search input.");
                            foreach (var topic in titleSearchString)
                            {
                                Console.WriteLine($"ID: {topic.Id}. {topic.Title}");
                            }

                            Console.WriteLine("Choose which one to print with ID number: ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            foreach (var topic in titleSearchString)
                            {
                                if (topic.Id == choice)
                                {
                                    Console.WriteLine(topic.CompileString());

                                }
                            }
                        }

                    }
                    Console.ReadLine();
                    break;

                default: break;
            }

        }

        public static async Task EditTopic() //edit different info of topics and save them to database
        {
            
            Console.Clear();
            Console.WriteLine("Enter an ID of entry to edit: ");
            int userIdInput = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("1) Edit title");
            Console.WriteLine("2) Edit description");
            Console.WriteLine("3) Edit estimated time");
            Console.WriteLine("4) Edit time spent");
            Console.WriteLine("5) Edit source");
            Console.WriteLine("6) Edit starting date");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change title to: ");
                            topic.Title = Console.ReadLine();
                        }
                        connectionToDatabase.SaveChanges();

                    }
                    break;

                case '2':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {

                            Console.Clear();
                            Console.WriteLine("Change description to: ");
                            topic.Description = Console.ReadLine();
                        }
                        connectionToDatabase.SaveChanges();
                    }
                    break;

                case '3':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("The new estimated time is: ");
                            topic.TimeToMaster = Convert.ToInt32(Console.ReadLine());
                            topic.EditIsInProgress();
                            topic.EditCompletionDate();
                        }
                        connectionToDatabase.SaveChanges();
                    }
                    break;

                case '4':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Spent time: ");
                            topic.TimeSpent = Convert.ToInt32(Console.ReadLine());
                            topic.EditIsInProgress();
                        }
                        connectionToDatabase.SaveChanges();
                    }
                    break;

                case '5':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change source: ");
                            topic.Source = Console.ReadLine();
                        }
                        connectionToDatabase.SaveChanges();
                    }
                    break;

                case '6':
                    using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
                    {
                        var topicToEdit = connectionToDatabase.Topics.Where(h => h.Id == userIdInput);
                        foreach (var topic in topicToEdit)
                        {
                            Console.Clear();
                            Console.WriteLine("Change start date: ");
                            topic.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
                            topic.EditIsInProgress();
                            topic.EditCompletionDate();
                        }
                        await connectionToDatabase.SaveChangesAsync();
                    }
                    break;

                default:
                    break;
            }
        }
        public static async Task DeleteTopic() //delete topic based off of id
        {
            Console.Clear();
            Console.WriteLine("Enter an ID of entry to delete: ");
            int userIdInput = Convert.ToInt32(Console.ReadLine());

            using (LearningDiaryLPContext connectionToDatabase = new LearningDiaryLPContext())
            {
                var topicToDelete = connectionToDatabase.Topics.Where(topic => topic.Id == userIdInput);

                foreach (var topic in topicToDelete)
                {
                    connectionToDatabase.Topics.Remove(topic);
                }
                connectionToDatabase.SaveChanges();
            }

            Console.WriteLine($"Entry {userIdInput} removed.");
            Console.ReadLine();
        }
    }
}
