using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;

namespace LearningDiaryLP
{
    public class Topic
    {
        //constructor
        public Topic()
        {
           
        }

       
        //compiles answers to string
       public string CompileString()
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

        //Get running id number NOT WORKING - user input for now
        public int RunningId()
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
            Console.Write("When is the starting date?: ");
            StartLearningDate = Convert.ToDateTime(Console.ReadLine());
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

        public string EditTitle()
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

        }
    }
}
