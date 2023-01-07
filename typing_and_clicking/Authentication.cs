using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Reflection;


namespace typing_and_clicking
{
    class Authentication
    {

        private string getBasePath()
        {
            string origAssemblyLocation = Assembly.GetExecutingAssembly().CodeBase;

            return Path.GetDirectoryName(origAssemblyLocation);
        }


        public void login(string token)
        { 
            try
            {
               // Console.WriteLine("     base path " + this.getBasePath());
               //Console.WriteLine("     base path " + this.getBasePath() + "/auth/authentication.txt");
                 
                this.logout(); 

                using (StreamWriter w = File.AppendText("auth/authentication.txt"))
                {
                    w.WriteLine(token);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string getLoggedin()
        {

            string result = "";

            try
            { 
                using (StreamReader r = File.OpenText("auth/authentication.txt"))
                {
                    string line;

                    while ((line = r.ReadLine()) != null)
                    {
                        result = line; 
                    }

                }
            }
            catch (Exception ex)
            {
                //
            }


            return result;
        }
        public void logout()
        {
            try
            {
                //using (StreamWriter w = File.AppendText("auth/authentication.txt"))
                //{
                    File.WriteAllText("auth/authentication.txt", "");
                //} 
            }
            catch (Exception ex)
            {

            }
        } 


    }
}
