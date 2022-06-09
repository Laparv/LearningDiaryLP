using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LearningDiaryLP
{
    class Topic
    {

        //constructor with methods
        public Topic()
        {
            RunningId();
            GetTitle();
            GetDescription();
            GetEstimatedTime();
            GetSpentTime();
            GetSource();
            GetLearningDate();
            IsInProgress();
            GetCompletionDate();
        }
        //compiles answers to string
       public string CompileString()
        {
            string compiledEntry = Id + Title + Description + EstimatedTimeToMaster + 
                TimeSpent + Source + StartLearningDate + InProgress + CompletionDate;
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

        //Get running id number NOT WORKING
        public int RunningId()
        {
            Id = 0;
            Id++;
            return Id;
        }
        //Methods for getting userinput


        public string GetTitle()
        {
            Console.WriteLine("Write the title of your topic: ");
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
            Console.WriteLine("How many hours does the topic take?: ");
            EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());
            return EstimatedTimeToMaster;
        }

        public double GetSpentTime()
        {
            Console.WriteLine("How many hours have you spent: ");
            TimeSpent = Convert.ToDouble(Console.ReadLine());
            return TimeSpent;

        }

        public string GetSource()
        {
            Console.WriteLine("Give source: ");
            Source = Console.ReadLine();
            return Source;
        }

        public DateTime GetLearningDate()
        {
            Console.WriteLine("When is the starting date?: ");
            StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            return StartLearningDate;

        }

        public bool IsInProgress()
        {
            Console.WriteLine("Is studying of the topic in progress?: ");

            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {
                InProgress = true;
            }
            else if (answer.ToLower() == "no")
            {
                InProgress = false;
            }

            return InProgress;
        }

        public DateTime GetCompletionDate()
        {
            Console.WriteLine("When is the completion date?");
            CompletionDate = Convert.ToDateTime(Console.ReadLine());
            return CompletionDate;

        }
        //yhdistä aika-arviot laskureilla ja minimoi user input?
    }
}
