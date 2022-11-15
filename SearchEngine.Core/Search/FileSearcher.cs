using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SearchEngine.Core.Search
{ 

    public class FileSearcher
    { 
        public List<string> searchResult = new List<string>();
       // public SearchResult searchResult;
       // public SearchResult searchResult { get; set; } 
        protected string Drive { get;private set; }
        protected string FileName { get;private  set; }

        //class constructor 
        public FileSearcher(string drive, string fileName)
        {
            try
            {
                this.Drive = drive;
                this.FileName = fileName;
                //searchResult = new SearchResult();
            }
            catch(Exception ex)
            { throw ex; }
        }

        //function to search the files in the drives
        public List<string> SearchForFiles(string drive, string fileName)
        {
            try
            {
                Get_Directory(drive, fileName);

                return searchResult;
            }
            catch(Exception ex) 
            { throw ex; }
        }
       
        //thread to start
        public void start() 
        {
            try
            {
                SearchForFiles(this.Drive, this.FileName);
            }
            catch(Exception ex )
            {throw ex;}
        }


        //function to get all the directory on the specified path
        public void Get_Directory(string dname, string fname)
        {
             
            try
            {
                // Make a reference to a directory.


                    DirectoryInfo di = new DirectoryInfo(dname);
  
                    // Get a reference to each directory in that directory.
                    //int count = di.GetDirectories().Length;
                    DirectoryInfo[] diArr = di.GetDirectories();


                    // Display the names of the directories.
                    foreach (DirectoryInfo dri in diArr)
                    {

                        if (dri.Attributes.HasFlag(FileAttributes.System) == false)//&& dri.Attributes.HasFlag(FileAttributes.Normal))                  {   

                        // dri.Attributes.HasFlag(FileAttributes.ReadOnly);
                        {
                            //  dri.Attributes.HasFlag(FileAccess.Read) 

                            string deep = dname + @"\" + dri.Name;
                            Get_Files(deep, fname);
                            Get_Directory(deep, fname);
                        }

                    }
                
            }
            catch(Exception ex)
            { throw ex; }


        }

        //function to fetch all the files present in the directory
        void Get_Files(string dname, string fname)
            {
                try
                {


                    FileInfo file = new FileInfo(dname);



                    string[] dirs = Directory.GetFiles(dname, $"*{fname}*");

                    if (dirs != null)
                    {
                        foreach (string dir in dirs)
                        {
                            searchResult.Add(dir);

                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
        }


    }
    
}
