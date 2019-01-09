using System.Collections.Generic;
using System.IO;
using System.Linq;
using Echenim.Nine.Misc.Machines.Models;

namespace Echenim.Nine.Misc.Machines
{
    internal class Disk
    {
        public IEnumerable<DiskResult> GetDiskInformation()
        {
             var diskResult = new List<DiskResult>();

            
            foreach (var item in DriveInfo.GetDrives().Where(s=>s.IsReady))
            {
                
            }
            


            return diskResult;
        }

    }
}
