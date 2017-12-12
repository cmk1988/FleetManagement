using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class FileInputOutput : IFileInputOutput
    {
        public string[] ReadLine(string filename)
        {
            if (File.Exists(filename))
                return File.ReadLines(filename).ToArray();
            return null;
        }

        public void WriteLine(string filename, string data)
        {
           File.WriteAllText(filename,data);
        }
    }
}
