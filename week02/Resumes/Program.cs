using System;
using System.Collections.Generic;

namespace ResumeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 4: Test Job class
            Job job1 = new Job();
            job1._jobTitle = "Software Developer";
            job1._company = "Google";
            job1._startYear = 2019;
            job1._endYear = 2022;

            Job job2 = new Job();
            job2._jobTitle = "Senior Developer";
            job2._company = "Apple";
            job2._startYear = 2022;
            job2._endYear = 2025;

            // Step 7: Test Resume class
            Resume myResume = new Resume();
            myResume._name = "Simeon Obianwa";
            
            // Adding jobs to the resume list
            myResume._jobs.Add(job1);
            myResume._jobs.Add(job2);

            // Step 8: Display the full resume, remove individual job displays and call the resume display method
            myResume.Display();
            
            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}