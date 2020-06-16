using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveSelector();
            Console.ReadKey();
        }

        private static void DriveSelector()
        {
            Console.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i + 1} . {drives[i].Name}");
            }

            Console.WriteLine("Please choose a number:");

  
            int userInputForDrive = int.Parse(Console.ReadLine());

            if (userInputForDrive <= drives.Length)
            {
                string folderPath = drives[userInputForDrive - 1].Name;
                DirectorySelector(folderPath);
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }

        }

        private static void DirectorySelector(string folderPath)
        {
            //first show all folders in directory
            DirectoryInfo di = new DirectoryInfo(folderPath);
            DirectoryInfo[] directories = di.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"{i + 1} . {directories[i].Name}");
            }

            Console.WriteLine("Please choose a folder:");

            int userInputForFolder = int.Parse(Console.ReadLine());

            if(userInputForFolder <= directories.Length)
            {
                    DirectoryInfo directory = new DirectoryInfo(@"C:\Users\User\Downloads");
                    List<FileInfo> lastMonthDownloadedPhotos = directory.GetFiles("*.jpg").Where(s => s.CreationTime > DateTime.Now.AddMonths(-1)).ToList();

                    if (lastMonthDownloadedPhotos.Count > 0)
                    {
                        foreach (var photo in lastMonthDownloadedPhotos)
                        {
                            string destFile = Path.Combine(directories[userInputForFolder - 1].FullName, photo.Name);
                            File.Copy(photo.FullName, destFile, true);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($" All Photos have been moved to {directories[userInputForFolder - 1].FullName} ");
                    }
               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number");
            }

        }
    }
}
