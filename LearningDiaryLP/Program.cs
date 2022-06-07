using System;

namespace LearningDiaryLP
{
    class Program
    {
        static void Main(string[] args)
        {
            Topic one = new Topic();
            one.GetTitle();

            Console.WriteLine("Git testaus");

        }
    }

    class Topic
    {
       
        //Method for id
        public int RunningId()
        {
            Id++;
            return Id;
        }
        
        //Topic fiel and properties
        public int id;
        public int Id { get; set; }

        public string title;
        public string Title { get; set; }

        public string GetTitle()
        {
            Console.WriteLine("Write the title of your topic: ");
            Title = Console.ReadLine();
            return  Title;
        }

        public string description;
        public string Description { get; set; }

        public string GetDescription()
        {
            Console.WriteLine("Description");
            Description = Console.ReadLine();
            return Description;

        }

        public double estimatedTimeToMaster;
        public double EstimatedTimeToMaster { get; set; }

        public double GetEstimatedTime()
        {
            Console.WriteLine("How long does it take?: ");
            EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());
            return EstimatedTimeToMaster;
        }

        public double timeSpent;
        public double TimeSpent { get; set; }

        public double GetSpentTime()
        {
            Console.WriteLine("How long have you spent time?: ");
            TimeSpent = Convert.ToDouble(Console.ReadLine());
            return TimeSpent;

        }

        public string source;
        public string Source { get; set; }

        public string GetSource()
        {
            Console.WriteLine("Give possible source");
            Source = Console.ReadLine();
            return Source;
        }

        public DateTime startLearningDate;
        public DateTime StartLearningDate { get; set; }

        public DateTime GetLearningDate()
        {
            Console.WriteLine("What is the starting date?");
            StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            return StartLearningDate;

        }

        public bool inProgress;
        public bool InProgress { get; set; }
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

        public DateTime completionDate;
        public DateTime CompletionDate { get; set; }

        public DateTime GetCompletionDate()
        {
            Console.WriteLine("What is the Completion date?");
            CompletionDate = Convert.ToDateTime(Console.ReadLine());
            return CompletionDate;

        }

        //yhdistä aika-arviot laskureilla ja minimoi user input

    }
}
