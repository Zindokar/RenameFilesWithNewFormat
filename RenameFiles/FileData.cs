using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RenameFiles
{
    class FileData
    {
        public FileData()
        {

        }

        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public override string ToString()
        {
            return Path + Name + Extension;
        }
    }
}
