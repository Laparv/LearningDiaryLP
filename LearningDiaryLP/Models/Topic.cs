using System;
using System.Collections.Generic;


#nullable disable

namespace LearningDiaryLP.Models
{
    public partial class Topic
    {
        public Topic()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimeToMaster { get; set; }
        public int? TimeSpent { get; set; }
        public string Source { get; set; }
        public DateTime? StartLearningDate { get; set; }
        public bool? InProgress { get; set; }
        public DateTime? CompletionDate { get; set; }


        public string CompileString()
        {
            string compiledEntry = "Entry ID: " + Id + "\n" + Title.ToUpper() + "\n\n" +
                Description + "\n" + "\nEstimated days to master the topic: " + TimeToMaster + "\nDays spent: " +
                TimeSpent + "\nSource: " + Source + "\nStart date: " + StartLearningDate + "\nIn progress: " +
                InProgress + "\nCompletion date: " + CompletionDate;
            return compiledEntry;
        }
        
        public bool IsInProgress()
        {
            if (TimeToMaster - TimeSpent <= 0)
            {
                InProgress = false;
            }
            else
            {
                InProgress = true;
            }
            return (bool)InProgress;
        }

        
    }
}
