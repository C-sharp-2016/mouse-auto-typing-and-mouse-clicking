using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Media;
using System.Windows; 
using System.Windows.Input;
using System.Windows.Forms; 



using typing_and_clicking;
 


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

        internal void pressedResetButton()
        {
            throw new NotImplementedException();
        }

        private bool playSoundStatus = true; 
      

        private string[] soundsStr1 = new string[] {
            "626","392","392","392","392","392","392","392","392","392"
        };
        private string[] soundsStr2 = new string[] {
            "2000","2000","4000","100","3530","3500","3504","3540","3500","3550"
        };


        private int prevHour=0, prevMin=0, prevSec=0; 





 





        private void timer2_Tick(object sender, EventArgs e)
        {

            Random r = new Random();

            timer2.Interval = r.Next(int.Parse(textBox3.Text), int.Parse(textBox4.Text)); 
            mouse_click_counter++;

            int x = System.Windows.Forms.Cursor.Position.X;
            int y = System.Windows.Forms.Cursor.Position.Y;

             

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


            sound_duration_textBox5.Text = "2000";
            
            // time
            timer3.Start();

            _Form1 = this;

             
            //// Initialized 
            /// thread for keypressed detect  
            startKeyPressDetectThread(); 
        }



     














        public static Form1 _Form1;
         
         

        public void updateLabelTest(string str)
        {

            keypressed_label.Text = str; 
        }
         






        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

       
        private void timer4_Tick(object sender, EventArgs e)
        {
            //Change the title while app is working.. 
            Random r = new Random();
            string str = "........";
            this.Text = str.Substring(0, r.Next(1, str.Length));
        }

        private const int MOUSEEVENTF_RIGHTUP = 0x0010;

      

        private void button3_Click(object sender, EventArgs e)
        {
              

            button1.Enabled = true;
            button2.Enabled = true;
             


            mouse_click_counter = 0;
            key_typing_counter = 0;

            // typing interval
            textBox1.Text = "100";
            textBox2.Text = "2000";


            //clicking interval
            textBox3.Text = "100";
            textBox4.Text = "3000";

            // typing times
            label1.Text = "0";

            // clicking times
            label4.Text = "0";


            //enable fields for interval
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            sound_duration_textBox5.Enabled = true;

            sounds_time_play_type_comboBox1.Enabled = true;
            sounds_time_play_value_textBox5.Enabled = true;

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











            /**
            * Sound Beep Start
            * Hours has a bug
            * if hour is zero then dont play sounds
            * just play once and dont repeat it
            */
            int sounds_time_play_value  = Int32.Parse(sounds_time_play_value_textBox5.Text); 

            if (sounds_time_play_type_comboBox1.Text == "Hours")
            {
                Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " hours ");
                if (hours % sounds_time_play_value == 0)
                {
                    if(hours != 0) {  
                        if(prevHour != hours) {  
                            Thread th = new Thread(playSounds);
                            th.Start();
                            prevHour = hours;
                        }  
                    }
                }
            }
            else if (sounds_time_play_type_comboBox1.Text == "Minutes")
            {
                Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " mins ");
                if (minutes % sounds_time_play_value == 0)
                {
                    if (minutes != 0)
                    {
                        if (prevMin != minutes)
                        {
                            Thread th = new Thread(playSounds);
                            th.Start();
                            prevMin = minutes;
                        }

                       
                    }
                }
            }
            else if (sounds_time_play_type_comboBox1.Text == "Seconds")
            {
                Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " seconds ");
                if (seconds % sounds_time_play_value == 0)
                {
                    if (seconds != 0)
                    {
                        if (prevSec != seconds)
                        {
                            Thread th = new Thread(playSounds);
                            th.Start();
                            prevSec = seconds;
                        }  
                    }
                }
            }
            /**
            * Beed Sounds End
            */

             
        label10.Text = hours_zero + hours.ToString() + " : " + minutes_zero + minutes.ToString() + " : " + seconds_zero + seconds.ToString();

        }


        /**  
           sample beep inputs: 

           626, 2000, C
           392, 2000, G
           523, 4000, C
           652, 100, E
           620, 3530, EB
           621, 3500, EB
           622, 3504, EB
           626, 3540, EB
           625, 3500, EB
           622, 3550, EB 
        */ 
       private void playSounds()
        {



          // soundsStr1
          // soundsStr1
           
           // for(int i=0; i< soundsStr1.Length; i++ )
           // { 
            //only play shouds if auto typing and clicking is activated
            if(button1.Enabled == false && playSoundStatus == true)
            { 
                int frequency = Int32.Parse("626");
                int duration = Int32.Parse(sound_duration_textBox5.Text);
                Console.Beep(frequency, duration);

            }
            //  }

        }

        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;


        private void button1_Click(object sender, EventArgs e)
        {
             

            timer1.Start();
            timer2.Start();
           


            //enable fields for interval
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            sound_duration_textBox5.Enabled = false;
            sounds_time_play_type_comboBox1.Enabled = false;
            sounds_time_play_value_textBox5.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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


            //enable fields for interval
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            sound_duration_textBox5.Enabled = true; 
            sounds_time_play_type_comboBox1.Enabled = true;
            sounds_time_play_value_textBox5.Enabled = true;


            button1.Enabled = true;
            button2.Enabled = false;
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



            // form title changing while app is running
            string str = "..........";
            this.Text = str.Substring(0, r.Next(1, str.Length));

             
        }







        //Short Cut keys
      //  public void pressedResetButton()
      //  {
            //Console.WriteLine("Start button pressed");
            //disableFields();
      //  }




       // public void pressedStopButton()
       // {
            //Console.WriteLine("Stop!");
            //button3.Enabled = false;
        //    keypressed_label.Text = "stop pressed!";
      //  }
         
        public void pressedResetButton123( string str )
        {

            keypressed_label.Text = str; 
            
            //new KeyboardInput();

            //Console.WriteLine("reset!");
            //disableFields();

            //disableFields();
             
            //button3.Enabled = true;

            Console.WriteLine(" str = " + str);
             
             
        }







        #region Key press detect


            private bool isRunning = true;
            private int  pressed = 0;

            
            private void startKeyPressDetectThread()
            {
                Thread TH = new Thread(Keyboardd11);
                TH.SetApartmentState(ApartmentState.STA);
                CheckForIllegalCrossThreadCalls = false;
                TH.Start();
            }


            void Keyboardd11()
            {
                while (isRunning)
                {
                    Thread.Sleep(100);


                   
                    if (Keyboard.IsKeyDown(Key.E))
                    {
                        PressedStartButton();
                        pressed++;
                    }
                    if (Keyboard.IsKeyDown(Key.R))
                    {
                        PressedStopButton();
                    }
                    if (Keyboard.IsKeyDown(Key.T))
                    {
                        PressedResetButton(); 
                    }
                  
                     

            }
            }





            //// this is the copy of start button click 
            public void PressedStartButton()
            {


                keypressed_label.Text = "Start";

                timer1.Start();
                timer2.Start();



                //enable fields for interval
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                sound_duration_textBox5.Enabled = false;
                sounds_time_play_type_comboBox1.Enabled = false;
                sounds_time_play_value_textBox5.Enabled = false;

                button1.Enabled = false;
                button2.Enabled = true;


            Console.WriteLine(keypressed_label.Text); 

            }

            //// this is the copy of start button click 
            public void PressedStopButton()
            {
                keypressed_label.Text = "Stop";




                timer1.Stop();
                timer2.Stop();


                //enable fields for interval
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                sound_duration_textBox5.Enabled = true;
                sounds_time_play_type_comboBox1.Enabled = true;
                sounds_time_play_value_textBox5.Enabled = true;


                button1.Enabled = true;
                button2.Enabled = false;
                Console.WriteLine(keypressed_label.Text);

        }

            //// this is the copy of start button click 
            public void PressedResetButton()
            {
                keypressed_label.Text = "Reset";

                button1.Enabled = true;
                button2.Enabled = true;



                mouse_click_counter = 0;
                key_typing_counter = 0;

                // typing interval
                textBox1.Text = "100";
                textBox2.Text = "2000";


                //clicking interval
                textBox3.Text = "100";
                textBox4.Text = "3000";

                // typing times
                label1.Text = "0";

                // clicking times
                label4.Text = "0";


                //enable fields for interval
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                sound_duration_textBox5.Enabled = true;

                sounds_time_play_type_comboBox1.Enabled = true;
                sounds_time_play_value_textBox5.Enabled = true;

                timer1.Stop();
                timer2.Stop();
                Console.WriteLine(keypressed_label.Text);

        }
         
        #endregion Key press detect

         
    }
}

 