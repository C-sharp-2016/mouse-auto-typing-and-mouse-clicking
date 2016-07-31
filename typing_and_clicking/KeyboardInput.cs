using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Threading;
using System.Windows.Input;

 

namespace typing_and_clicking
{
   public class KeyboardInput : Form
    {
        private bool CheckForIllegalCrossThreadCalls;
        bool isRunning = true;
     


        public static string testFunctionCall ( )
        {
            return "nice";
        }
         
        public KeyboardInput()
        {


            Form1._Form1.updateLabelTest("started the program");


            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }
         
        void Keyboardd()
        {

         
            Form1 f1 = new Form1();

             
            while (isRunning)
            {
                Thread.Sleep(40);

                if (Keyboard.IsKeyDown(Key.E))
                {
                    //keypressed_label.Text = "test";
                      Console.WriteLine("key e pressed ");
                    //f1.keypressed_label.Text = "test pressed";

                    Form1._Form1.updateLabelTest("started the program pressed e");

                    

                }
            } 

        }
    }
}
