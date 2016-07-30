using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;


namespace typing_and_clicking
{
    public partial class Form1 : Form
    {



        private int seconds = 0, minutes = 0, hours = 0;
        private string seconds_zero, minutes_zero, hours_zero;

        private int s1, s2 = 100, n1, r1, key_typing_counter,mouse_click_counter;
        private int moveFast = 0;
        public event EventHandler Click;
        private string keyPressed;
        private string[] randKey = new string[] {
             "a","b","c","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            //,"{BACKSPACE}","{TAB}",
             "a","b", " ",
             // "{BACKSPACE}", "{BACKSPACE}","{BACKSPACE}","{BACKSPACE}",
             //"{Enter}" ,"{Enter}" ,"{Enter}" 
             //"+(a)", "%{TAB}",,"{Enter}" ,"{Enter}" ,"{Enter}" 
        };

        private void timer2_Tick(object sender, EventArgs e)
        {

            Random r = new Random();

            timer2.Interval = r.Next(int.Parse(textBox3.Text), int.Parse(textBox4.Text)); 
            mouse_click_counter++;
            
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
             
            Clicker(x, y);
             
            label4.Text = mouse_click_counter.ToString();
            //Console.WriteLine("Typing Pause " + s2);

            Console.WriteLine("Clicking Pause " + timer2.Interval);
             
              
        }

        public Form1()
        {
            InitializeComponent();


            // typing times
            label1.Text = "0";

            // clicking times
            label4.Text = "0";

             
            // typing interval
            textBox1.Text = "100";
            textBox2.Text = "2000";


            //clicking interval
            textBox3.Text = "100";
            textBox4.Text = "3000";
             

            // time
            timer3.Start(); 

        }



        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        private const int MOUSEEVENTF_RIGHTUP = 0x0010;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            mouse_click_counter = 0;
            key_typing_counter = 0;

            // typing interval
            textBox1.Text = "100";
            textBox2.Text = "1000";


            //clicking interval
            textBox3.Text = "100";
            textBox4.Text = "1000";

            // typing times
            label1.Text = "0";

            // clicking times
            label4.Text = "0"; 



            timer1.Stop();
            timer2.Stop(); 

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
             
            seconds++; 
            
            if (seconds > 59)
            {
                minutes++;   
                seconds = 1; 
            } 
            if (minutes > 59)
            { 
                hours++;
                minutes = 1; 
            }
               
            if (seconds.ToString().Length == 1)
            {
                seconds_zero = "0"; 
            }
            else
            {
                seconds_zero = "";
            }
             
            if (minutes.ToString().Length == 1)
            {
                minutes_zero = "0";
            }
            else
            {
                minutes_zero = "";
            }
             
            if (hours.ToString().Length == 1)
            {
                hours_zero = "0";
            }
            else
            {
                hours_zero = "";
            }

            label10.Text = hours_zero + hours.ToString() + " : " + minutes_zero + minutes.ToString() + " : " + seconds_zero + seconds.ToString();
        
        }

        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        public void Clicker(int x, int y)
        {
            SetCursorPos(x, y);
            this.Refresh();
            Application.DoEvents();
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // change speed of the time 
            // change time limit for sleep 
            // new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 1, 1, 1);


            int sleepLimit = 1000;

            Random r = new Random();
            n1 = r.Next(0, randKey.Length); // select letters


            //move fast 5 times only
            if (s2 < 500 && moveFast == 0)
            {
                moveFast = 5;
            }
            else if (moveFast <= 0)
            {
                moveFast = 0;
                //random numbers 
                r1 = r.Next(0, 1000); // will tell when we will do the pause or sleep
                s1 = r.Next(0, 30) * sleepLimit;  // sleep limit seconds
                s2 = r.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));  // seconds interval
            }
            else
            {
                moveFast--;

                if (moveFast == 0)
                {
                    s2 = 1000;
                }
            }

            timer1.Interval = s2;
            key_typing_counter++;
             
            // send key to our ui desktop
            SendKeys.Send(randKey[n1]);
             
            label1.Text = key_typing_counter.ToString();


            Console.WriteLine( "Typing Pause " + s2); 

        }
    }
}
