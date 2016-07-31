using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
 


namespace typing_and_clicking
{

     
    static class Program
    {

           

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /////////////////////////////
            // calling the classes 
            /////////////////////////////

            // calling under classes folder
            // Classess.TestClass2 C2 = new Classess.TestClass2();

            //calling outside folder
            //TestClass1    tc = new TestClass1();

























            //call functions inside classes and display
            //C2.class2Testing1(); 
            //Classess.TestClass2.class2Testing();

            //tc.testing1234();
            //TestClass1.testing123();



            #region Used in this application
            // control key pressed detect external

            //calling the form display
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
            


            #endregion Used in this application

        }

    }
}
