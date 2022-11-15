using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Drives
{
    public class DriveFinderFactory
    {
        public static IDriveFinder Create(string choice)
        {
            try
            {
                IDriveFinder finder;

                if (choice.Equals("ALL"))
                {
                    finder = new SystemDriveFinder();
                }
                else if (choice.Equals("ACTIVE"))
                {
                    finder = new ActiveDriveFinder();
                }
                else
                    throw new InvalidDriveChoiceException("Choose the Drive Type ");

                return finder;
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}
