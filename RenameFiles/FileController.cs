using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RenameFiles
{
    class FileController
    {
        public FileController()
        {

        }

        public string getPathFromFullPath(string fullPath)
        {
            FileStream fs = File.Open(fullPath, FileMode.Open);
            string[] originPathSplitted = fs.Name.Split("\\"); // Returns full path
            fs.Close();
            string originPath = @"";
            for (int i = 0; i < originPathSplitted.Length - 1; i++)
            {
                originPath += originPathSplitted[i] + @"\"; // Appending each parth but not the last which is filename + extension
            }
            return originPath;
        }

        public string getNameFromFullPath(string fullPath)
        {
            FileStream fs = File.Open(fullPath, FileMode.Open);
            string[] originFileNameSplitted = fs.Name.Split("\\"); // Returns full path
            fs.Close();
            string originFileName = originFileNameSplitted.Length > 0 ? originFileNameSplitted[originFileNameSplitted.Length - 1] : fs.Name; // But we want only the file name
            return originFileName;
        }

        /**
         * @return Renamed filename, if empty it was not renamed.
         */
        public string renameFileWithDashSeparation(string fullPath, int fileCount)
        {
            string filePath = getPathFromFullPath(fullPath);
            string fileName = getNameFromFullPath(fullPath);
            Console.WriteLine("File[{0}] Origin name: {1}", fileCount, fileName);
            FileData renamedFile = new();
            renamedFile.Name = renameFileNameChangeDateFormat(fileName);
            renamedFile.Path = filePath;
            renamedFile.Extension = ".mp4";
            System.IO.File.Move(fullPath, renamedFile.ToString());
            return renamedFile.ToString();
        }

        private string renameFileNameChangeDateFormat(string fileName)
        {
            string[] renamedFileNameSplitted = fileName.Split("-"); // Origin file name has a separation of name and date using -
            if (renamedFileNameSplitted.Length == 2)
            {
                string namePart = renamedFileNameSplitted[0];
                string datePart = renamedFileNameSplitted[1];
                string year = datePart.Substring(4, 4);
                string month = datePart.Substring(2, 2);
                string day = datePart.Substring(0, 2);
                string fileDatePartModified = year + month + day;
                return namePart + "-" + fileDatePartModified;
            }
            else
            {
                return "";
            }
        }

        public bool directoryExist(string fullPath)
        {
            return Directory.Exists(fullPath);
        }

        public bool fileExists(string fullPath)
        {
            return File.Exists(fullPath);
        }

        public IEnumerable<string> getDirectoryList(string fullPath)
        {
            return from file in Directory.EnumerateFiles(fullPath) select file;
        }

    }
}
