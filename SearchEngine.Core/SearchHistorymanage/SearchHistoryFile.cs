using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.SearchHistorymanage
{
    public class SearchHistoryFile 
    {

        string basepath = @"C:\Users\prthm\Desktop\gitPull\Search Engine\cmd_ui\SearchEngine.Core\HistoryLogs\";
       

        //funcyion takes name and search result : and add them to the history 
        public string AddHistory(List<string> history, string filename)
        {
            try
            {
                // This will create a file named sample.txt
                // at the specified location 
                StreamWriter sw = new StreamWriter(basepath + filename + ".txt");

                // To write on the console screen
                foreach (string h in history)
                {

                    sw.WriteLine(h);

                    // To write in output stream
                    sw.Flush();
                }



                // To close the stream
                sw.Close();


                return "done";
            }
            catch(Exception ex)
            { throw ex; }
        }

        //function to show all the paths in the file
        public List<string> ShowHistory(string filename)
        {
            try
            {
                List<string> dataFromFile = new List<string>();
                // StreamReader sr = new StreamReader("SearchHistory.txt");


                string[] lines = System.IO.File.ReadAllLines(basepath + filename + ".txt");

                // Display the file contents by using a foreach loop.

                foreach (string line in lines)
                {

                    dataFromFile.Add(line);
                }

                return dataFromFile;
            }
            catch(Exception ex) 
            { throw ex; }
        }


       

       
    }
}
