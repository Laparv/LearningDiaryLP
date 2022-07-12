using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningDiaryLP.Models;
using ClassLibraryLearningDiary;
using System.Diagnostics;
//tämä on MAIN branch
namespace LearningDiaryLP
{
    class Program
    {

        static async Task Main(string[] args)
        {
            do
            {
                //menu
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) List out your entries");
                Console.WriteLine("2) Add entry");
                Console.WriteLine("3) Read previous entry");
                Console.WriteLine("4) Edit entry");
                Console.WriteLine("5) Delete entry");
                Console.WriteLine("6) Exit");
                var menuPick = Console.ReadKey().KeyChar;

                if (menuPick == '1')
                {
                    await StaticMethods.ListAllEntries();
                }
                //Add entry to diary
                else if (menuPick == '2')
                {
                    await StaticMethods.AddEntry();
                }
                //read previous entry from diary. Search with id or title
                else if (menuPick == '3')
                {
                    await StaticMethods.ReadEntry();
                }
                //edit an entry
                else if (menuPick == '4')
                {
                   await StaticMethods.EditTopic();
                }
                //entry deletion
                else if (menuPick == '5')
                {
                   await StaticMethods.DeleteTopic();
                }
                //exit app
                else if (menuPick == '6')
                {
                    break;
                }
            } while (true);
        }
    }
}