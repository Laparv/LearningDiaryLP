﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;
using ClassLibraryLearningDiary;

namespace LearningDiaryLP
{
    public class Topic
    {
        public Topic() //constructor
        {
           
        }

       public string CompileString() //NOT IN USE - same method found in Models.Topic
        {
            string compiledEntry = "Entry ID: " + Id + "\n" + Title.ToUpper() +"\n\n" +
                Description + "\n" + "\nEstimated days to master the topic: " + EstimatedTimeToMaster + "\nDays spent: " +
                TimeSpent + "\nSource: " + Source + "\nStart date: " +StartLearningDate.ToString("dd:MM:yyyy") + "\nIn progress: "+ 
                InProgress + "\nCompletion date: "+ CompletionDate.ToString("dd:MM:yyyy");
           return compiledEntry;
        }

        //Properties and fields
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTimeToMaster { get; set; }
        public double TimeSpent { get; set; }
        public string Source { get; set; }
        public DateTime StartLearningDate { get; set; }
        public bool InProgress { get; set; }
        public DateTime CompletionDate { get; set; }

        public int RunningId() // NOT IN USE - get id input from user
        {
            Console.WriteLine("Give Id: ");
            Id = Convert.ToInt32(Console.ReadLine());
            return Id;
        }
        
        //Methods for getting userinput
        public string GetTitle()
        {
            Console.Write("Write the title of your topic: ");
            Title = Console.ReadLine();
            return Title;
        }

        public string GetDescription()
        {
            Console.WriteLine("Description: ");
            Description = Console.ReadLine();
            return Description;

        }

        public double GetEstimatedTime()
        {
            Console.Write("Estimated days to master the topic: ");
            EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());
            return EstimatedTimeToMaster;
        }

        public double GetSpentTime()
        {
            Console.Write("Days spent on topic: ");
            TimeSpent = Convert.ToDouble(Console.ReadLine());
            return TimeSpent;

        }

        public string GetSource()
        {
            Console.Write("Give source: ");
            Source = Console.ReadLine();
            return Source;
        }

        public DateTime GetStartDate()
        {
            try
            {
                Console.Write("When is the starting date?: ");
                StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input please try again");
                StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            }
            return StartLearningDate;
        }

        //get progress info and completion date from previous entries
        public bool IsInProgress()
        {
            if (EstimatedTimeToMaster - TimeSpent <= 0)
            {
                InProgress = false;
            }
            else
            {
                InProgress = true;
            }

            return InProgress;
        }
        
        public DateTime GetCompletionDate()
        {
            if (EstimatedTimeToMaster - TimeSpent <= 0)
            {
                CompletionDate = StartLearningDate.AddDays(TimeSpent);
            }
            else if (EstimatedTimeToMaster - TimeSpent > 0)
            {
                CompletionDate = StartLearningDate.AddDays(EstimatedTimeToMaster);
            }

            return CompletionDate;

        }
      //unused methods for editing entries while console running
      /*  public string EditTitle()
        {
            Console.Write("Change title to: ");
            Title = Console.ReadLine();
            return Title;
        }
        public string EditDescription()
        {
            Console.WriteLine("Change description to: ");
            Description = Console.ReadLine();
            return Description;

        }

        public double EditEstimatedTime()
        {
            Console.Write("Estimated days to master the topic: ");
            EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());
            return EstimatedTimeToMaster;
        }

        public double EditSpentTime()
        {
            Console.Write("Days spent on topic: ");
            TimeSpent = Convert.ToDouble(Console.ReadLine());
            return TimeSpent;

        }

        public string EditSource()
        {
            Console.Write("Give source: ");
            Source = Console.ReadLine();
            return Source;
        }

        public DateTime EditStartDate()
        {
            Console.Write("When is the starting date?: ");
            StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            return StartLearningDate;

        }*/
    }
}
