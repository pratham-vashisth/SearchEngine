using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Drives
{
    //function to find active drives in the system
    public class ActiveDriveFinder : IDriveFinder
    {
        public List<string> FindDrives()
        {
            try
            {
                List<string> drives = new List<string>();

                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d in allDrives)
                {
                    if (d.IsReady)
                        drives.Add(d.Name);

                }

                return drives;
            }
            catch(Exception ex )
            { throw ex; }
        }
    }
}
