using SearchEngine.Core.Drives;
using SearchEngine.Core.Search;
using SearchEngine.Core.SearchHistorymanage;
using System;

namespace SearchEngineConsole
{
    class Program
    {
        static SearchHistoryManager historyManager = new SearchHistoryManager();
        static void Main(string[] strings)
        {
            string check;
            bool runagain = true;
            string FileName = null;
            List<string> DriveSelected = null;
            List<string> drives = null;
            string chooseDrives = null;

            while (runagain)
            {
                try
                {
                    //greet the user
                    DisplayWelcomeUser();

                    // ask user to choose type of drives
                    chooseDrives = DisplayDrivechoice();

                    //search and display drives
                    drives = FindDrives(chooseDrives);
                    DisplayDrives(drives);

                    //ask user to select the drives he want to search file in
                    DriveSelected = SelectDriveToSearch();


                    //ask user to put file name 
                    FileName = AcceptFileName();

                    

                    //first search in file before searching in drive 
                   

                    bool valid = DisplaySearchResults(historyManager.ShowLogSearchresult(FileName));

                    string pass = "yes";
                    //asking user if he want to search further
                    if (valid)
                    {
                        Console.WriteLine(" This result came from search history: Are you satisfied with the result :\n\n\t If not: press  No to search in actual drives\n\n\tElse press enter");
                        pass = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No result found in search History: \t Press enter to search in actual drives ");
                        Console.ReadLine();
                        pass = "no";
                    }


                    if (ValidateFileName(FileName) && pass.Equals("no"))
                    {
                        //search files in drive
                        SearchForFile(DriveSelected,FileName);
                    }



                }
                catch (InvalidDriveChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Restart Your Search");
                }


                Console.WriteLine("Want to search again??\n\t Press y to search again.\n\t Press any key to exit :-)");
                 check = Console.ReadLine().ToUpper();
                if(!check.Equals("Y"))
                {
                    runagain = false;
                    Console.Clear();
                
                    Console.WriteLine("ThankYou");
                }
                Console.Clear();

            }
            
        }

        //function to display the welcome greeting 
        static void DisplayWelcomeUser()
        {
            Console.WriteLine("Hello: Welcome to Search engine : You can search for here");
        }

        //function asking user to choose type of drive Active Or ALL
        static string DisplayDrivechoice()
        {
            try
            {
                Console.WriteLine("which drives you want to see\t\n 1: All Drives :-Type ALL\t\n 2: Active Drives :-Type Active \t\n");

                string type = Console.ReadLine().ToUpper();

                return type;
            }
            catch(Exception ex)
            { throw ex; }
        }

        //function for finding drives in the system.
        static List<string> FindDrives(string choice)
        {
            List<string> drives = null;
            try
            {
                IDriveFinder finder = DriveFinderFactory.Create(choice);
                drives = finder.FindDrives();

                return drives;
            }
            catch(InvalidDriveChoiceException ex)
            {
                throw ex;
            }
        }

        //function to display the drive which user requested
        static void DisplayDrives(List<string> drives)
        {
            try
            {
                foreach (string drive in drives)
                    Console.WriteLine(drive);
            }
            catch(Exception ex)
            { throw ex; }
        }

        //function let user to choose multiple drive to initiate the search
        static List<string> SelectDriveToSearch()
        {
            try
            {
                List<string> drives = new List<string>();
                bool x = true;
                Console.WriteLine("Enter the drive name");
                drives.Add(Console.ReadLine());
                while (x)
                {

                    Console.WriteLine("press enter to chooose another drive\n\t\t OR \npress No to complete");
                    string a = Console.ReadLine();

                    if (a.Equals("no"))
                    { x = false; }
                    else
                    { drives.Add(a); }
                }
                return drives;
            }
            catch(InvalidDriveChoiceException ex) 
            { 
                throw ex; 
            }
           
         
        }
        
        //funnction ask user to input the file name he wants to search
        static string AcceptFileName()
        {
            try 
            {  
                Console.WriteLine("Enter the file name you want to search : ");
                string FileName = Console.ReadLine();
                return FileName;
            }
            catch(Exception ex)
            { throw ex; }
           
        }

        //function for validating the file name 
        static bool ValidateFileName(string filename)
        {
            return true;
        }

        //function for display the search result
        static bool DisplaySearchResults(List<string> searchresult)
        {
            try
            {

                foreach (string result in searchresult)
                {
                    Console.WriteLine(result);
                }
                if (searchresult.Count == 0)
                    return false;

                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }

        static void SearchForFile(List<string> driveSelected,string fileName)
        {
            ISearchManager searchManager = new SearchManager();

            List<string> searchResult = searchManager.Search(driveSelected, fileName);

           bool valid = DisplaySearchResults(searchResult);

            if (!valid)
            {
                Console.WriteLine("No Result found in drives"); 
            }

            //log the result in file
            historyManager.LogSearchResult(searchResult, fileName);

            Console.WriteLine("search result saved in  history");


        }

    }
}
