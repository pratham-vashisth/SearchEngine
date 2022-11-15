using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Drives
{
    //function to find all the drives in system
    public class SystemDriveFinder : IDriveFinder
    {
        public List<string> FindDrives()
        {
            try
            {
                List<string> drives = new List<string>();

                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d in allDrives)
                {

                    drives.Add(d.Name);

                }

                return drives;
            }
            catch(Exception ex)
            { throw ex; }
        }

    }
}
