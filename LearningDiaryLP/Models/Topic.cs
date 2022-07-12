using System;
using System.Collections.Generic;
using ClassLibraryLearningDiary;


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


        public string CompileString() //compiles database table column info into string to present to user (utilizes check if late method)
        {
            MethodLibrary check = new MethodLibrary(); //calls dll 

            string compiledEntry = $"Entry ID: {Id} \n{Title.ToUpper()} \n\n{Description}" +
                $"\n\nEstimated days to master the topic: {TimeToMaster}\nDays spent: {TimeSpent} " +
                $"\nSource: {Source} \nStart date: {StartLearningDate.GetValueOrDefault().ToShortDateString()}\nIn progress: {InProgress}" +
                $"\nCompletion date: {CompletionDate.GetValueOrDefault().ToShortDateString()}" +
                $"\nIs on shcedule: {check.CheckIfLate(Convert.ToDateTime(StartLearningDate), Convert.ToDouble(TimeToMaster))}";

            return compiledEntry;
        }

        public bool EditIsInProgress() //edits In progress information
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

        public DateTime EditCompletionDate() //edits completion date to database
        {
            if (TimeToMaster - TimeSpent <= 0)
            {
                CompletionDate = Convert.ToDateTime(StartLearningDate).AddDays(Convert.ToDouble(TimeSpent));
            }
            else if (TimeToMaster - TimeSpent > 0)
            {
                CompletionDate = Convert.ToDateTime(StartLearningDate).AddDays(Convert.ToDouble(TimeToMaster));
            }

            return Convert.ToDateTime(CompletionDate);

        }
    }
}
