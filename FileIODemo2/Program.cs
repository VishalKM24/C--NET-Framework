using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            GetAllDrives();
            
            GetAllFiles();
        }

        public static void GetAllFiles()
        {
            string[] files = Directory.GetFiles("C:\\Users\\Admin\\Desktop\\Framework-Projects\\Sum\\ContactsManagementsApp");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        public static void GetAllDrives()
        {
            // get access of all drives
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (var drive in drivers)
            {
                Console.WriteLine(drive.Name + "\t" + drive.TotalSize + "/" + drive.TotalFreeSpace);
            }
        }
    }
}
