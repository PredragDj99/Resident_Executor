using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConnectionLink
    {
        public string TakeConnectionString()
        {
            string startupPath = Environment.CurrentDirectory;
            string filePath = startupPath.Remove(startupPath.Count() - 27);
            filePath = filePath + "FileSystem/connection_string.txt";

            string konekcija = "";

            using (StreamReader file = new StreamReader(filePath))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    konekcija = konekcija + ln;
                }
                file.Close();
            }
            return konekcija;
        }
    }
    
}
