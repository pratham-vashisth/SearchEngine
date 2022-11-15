using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using SearchEngine.Core.SearchHistorymanage;

namespace SearchEngine.Core.Search
{
    public class SearchManager:ISearchManager
    {

        // control class 
        //control all the operation to initiate the search in the drives:multithreading  
        public List<string> Search(List<string> drives, string fileName)        
        {
            try
            {
                // List<SearchResult> searchResults = new List<SearchResult>();
                List<string> searchResults = new List<string>();
                Thread[] filesearchersThreads = new Thread[drives.Count];
                FileSearcher[] fileSearchers = new FileSearcher[drives.Count];

                for (int i = 0; i < drives.Count; i++)
                {
                    FileSearcher searcher = new FileSearcher(drives[i], fileName);
                    //  Thread searchThread = new Thread(new ThreadStart(searcher.start));
                    Thread searchThread = new Thread(searcher.start);
                    searchThread.Start();
                    Console.WriteLine("Thread"+$"{i+1}"+"started");
                    fileSearchers[i] = searcher;
                    filesearchersThreads[i] = searchThread;
                }
                foreach (Thread t in filesearchersThreads)
                {
                    t.Join();
                }

                foreach (FileSearcher searcher in fileSearchers)
                {
                    foreach (string path in searcher.searchResult)
                    {
                        searchResults.Add(path);
                    }



                }


                return searchResults;
            }
            catch(Exception ex)
            { throw ex; }
        }

    }
}
