using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace typing_and_clicking
{
    class Log
    { 
        public void addText(string msg)
        {
            try {  
                using (StreamWriter w = File.AppendText("log/log.txt"))
                {
                    logMessage(msg, w);
                }

                using (StreamReader r = File.OpenText("log/log.txt"))
                {
                    dumpLog(r);
                }
            }
            catch (Exception ex)
            {
                this.addText("Error logging message : " + ex.Message);  
            }

        }

        public static void logMessage(string logMessage, TextWriter w)
        { 
            w.WriteLine("Log Entry : {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine(":{0}", logMessage);
            w.WriteLine("----------------------------------------------------------------------------------");
        }

        public static void dumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }


    }
}
