using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 
using System.IO;
using System.IO.IsolatedStorage;
using System.Net.Http;

namespace typing_and_clicking
{
    static class Program
    { 
        public static string UserID;
        public static string isLoggedin;
        public static LocalDataStoreSlot dataslot = Thread.AllocateDataSlot();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
               //  isoStore.CreateDirectory("TestDirectory");
               // isoStore.CreateDirectory("TopLevelDirectory/SecondLevel");
                //isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
                //onsole.WriteLine("Created directories.");

                //isoStore.CreateFile("InTheRoot.txt");
                //Console.WriteLine("Created a new file in the root.");

                //isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
                //Console.WriteLine("Created a new file in the InsideDirectory."); 
            }
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Authentication Auth = new Authentication(); 

            Console.WriteLine("Program is initiated.."); 
            Console.WriteLine(" Auth Token: " + Auth.getLoggedin());
             
            if (Auth.getLoggedin() != string.Empty)
            {
                UserID = "loggedin";
            }

            if (UserID == "loggedin")
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Login());
            } 
        } 
    }
}
