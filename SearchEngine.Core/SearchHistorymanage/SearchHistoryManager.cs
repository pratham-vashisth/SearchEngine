using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.SearchHistorymanage
{
    public class SearchHistoryManager
    {  
        string basepath = @"C:\Users\prthm\Desktop\gitPull\Search Engine\cmd_ui\SearchEngine.Core\HistoryLogs\";

        SearchHistoryFile searchHistory = new SearchHistoryFile();

        //function to search the history in files
        public void LogSearchResult(List<string> searchResult, string filename)
        {

            try
            {
                searchHistory.AddHistory(searchResult, filename);
            }
            catch (Exception ex)
            { throw ex; }

        }

        //function to search the history in the files
        public List<string> ShowLogSearchresult(string Filename)
        {
            try
            {
                List<string> logSearchResult = new List<string>();




                int x = 0;

                x = Directory.GetFiles(basepath, $"{Filename}" + ".txt").Length;

                if (x != 0)
                {
                    foreach (string storePath in searchHistory.ShowHistory(Filename))
                    {

                        //file still in drive and only taking those who contain the path of file we want
                        if (ValidateFileStillInDrive(storePath) && storePath.Contains(Filename))
                        {
                            logSearchResult.Add(storePath);
                        }
                    }
                }


                return logSearchResult;
            }
            catch (Exception ex)
            { throw ex; }
        }

        //function for validating path stored file is still in its location 
        public bool ValidateFileStillInDrive(string filepath)
        {
            try
            {

                if (File.Exists(filepath))
                {

                    return true;
                }


                return false;
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
