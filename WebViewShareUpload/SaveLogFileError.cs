using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewShareUpload
{
    internal class SaveLogFileError
    {
        public static void SaveLogFile(string exeption)
        {
            string fileDIR = Directory.GetCurrentDirectory() + "\\ErrorLog-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
            File.WriteAllText(fileDIR, exeption);
        }
    }
}
