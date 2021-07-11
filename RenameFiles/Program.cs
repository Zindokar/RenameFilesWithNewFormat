using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RenameFiles
{
    class Program
    {
        /**
         * Easy way to rename files to get proper order in directory 
         * From: C:\Users\alexm\Desktop\Files\File-31102020.mp4
         * To: C:\Users\alexm\Desktop\Files\File-20201031.mp4
         */
        static void Main(string[] args)
        {
            string subdir = @"C:\Users\alexm\Desktop\Files";
            FileController fileController = new();
            if (fileController.directoryExist(subdir))
            {
                Console.WriteLine("Exist: {0}", subdir);
                IEnumerable<string> fileList = fileController.getDirectoryList(subdir);
                Console.WriteLine("Files count: {0}", fileList.Count());
                int fileCount = 0;
                foreach (string filePath in fileList)
                {
                    Console.WriteLine("Checking file[{0}]: {1}", fileCount, filePath);
                    if (fileController.fileExists(filePath))
                    {
                        Console.WriteLine("File[{0}]: Exists.", fileCount);
                        string renamedFileName = fileController.renameFileWithDashSeparation(filePath, fileCount);
                        if (renamedFileName != null && renamedFileName != "")
                        {
                            Console.WriteLine("File[{0}] Renamed to name: {1}", fileCount, renamedFileName);
                        }
                        else
                        {
                            Console.WriteLine("File[{0}] Not renamed.", fileCount);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File[{0}]: Does not exist.", fileCount);
                    }
                    fileCount++;
                    Console.WriteLine();
                }
            }
        }
    }
}
