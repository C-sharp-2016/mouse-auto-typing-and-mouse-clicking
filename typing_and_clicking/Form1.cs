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
using System.Media;
using System.Windows.Input;

using System.Net.Http;
// https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.codebase?source=recommendations&view=net-6.0
using System.Reflection; 

namespace typing_and_clicking
{
    public partial class Form1 : Form
    {

        private string announcement = "..";

        // system will know if we will allow the user to use the app or not.
        private int accessStatus = 200;


        //public static LocalDataStoreSlot dataslot = Thread.AllocateDataSlot();


        // src: keys send - http://go-gaga-over-testing.blogspot.com/2011/01/sendkeys-cheat-sheet.html   
        private int log_click_total = 0, log_typing_total = 0, sounds_time_play_value = 0;
        private int seconds = 0, minutes = 0, hours = 0;
        private string seconds_zero, minutes_zero, hours_zero;

        private string sounds_src = "";
        private string nextScreen = "";

        private string nextTabPhpstorm = "%{RIGHT}";  // tab + arrow-right 
        private string nextTabVsSublimeBrowser = "^+{Tab}"; // ctr + shift + tab
        //private string nextScreen = "";
        //private string nextTab = "^+{Tab}"; 

        private int s1, s2 = 100, n1, r1, key_typing_counter, mouse_click_counter;
        private int moveFast = 0;
        public event EventHandler Click;
        private string keyPressed;
        private string[] randKey = new string[] {
            "{DOWN}", "{UP}", "{LEFT}", "{RIGHT}"
            // "a","b","c","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            //,"{BACKSPACE}","{TAB}",
            // "a","b", " ",
             // "{BACKSPACE}", "{BACKSPACE}","{BACKSPACE}","{BACKSPACE}",
             //"{Enter}" ,"{Enter}" ,"{Enter}" 
             //"+(a)", "%{TAB}",,"{Enter}" ,"{Enter}" ,"{Enter}" 
        };

        private string[] changeScreenKeys = new string[] {
            "^{Tab}"
             //"^{3}","^{4}","^{8}","^{Tab}" ,"^{2}","^{Tab}","^{5}","^{Tab}","^{Tab}","^{Tab}","^{Tab}",
            //"^{Tab}","^{Tab}","^{1}",
           // "^{Tab}","^{Tab}","^{Tab}","^{Tab}","^{6}","^{Tab}",
            //"^{Tab}","^{7}","^{Tab}","^{Tab}","^{9}"
        };
        //private string[] changeScreenKeysUsed = new string[] { 
        // };

        private bool playSoundStatus = true;


        private string[] soundsStr1 = new string[] {
            "626","392","392","392","392","392","392","392","392","392"
        };
        private string[] soundsStr2 = new string[] {
            "2000","2000","4000","100","3530","3500","3504","3540","3500","3550"
        };


        private int prevHour = 0, prevMin = 0, prevSec = 0;


        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        /**
         *  When the apps, clicking....
         * 
         * 
         */
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (enable_click_checkbox1.Checked == true)
            {
                try
                {
                    // Console.WriteLine("timer 2 ticking");
                    Random r = new Random();

                    timer2.Interval = r.Next(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                    mouse_click_counter++;

                    int x = System.Windows.Forms.Cursor.Position.X;
                    int y = System.Windows.Forms.Cursor.Position.Y;

                    Clicker(x, y);

                    label4.Text = mouse_click_counter.ToString();
                    // //Console.WriteLine("Typing Pause " + s2);

                    // Console.WriteLine("Clicking Pause " + timer2.Interval);

                    log_click_total++;

                    if (checkbox_clicking_sound.Checked == true)
                    {
                        sounds_src = "sound/Mouse_click.wav";
                        Thread th = new Thread(playSoundsDynamic);
                        th.Start();
                    }
                }
                catch (Exception ex)
                {
                    Log lg = new Log();
                    lg.addText(" Error handling clicking " + ex.Message);
                }
            }
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
            textBox4.Text = "5000";


            sound_duration_textBox5.Text = "2000";

            ctr_plug_tab_checkbox1.Checked = true;
            //enable_click_checkbox1.Checked = true;
            enable_typing_checkbox2.Checked = true;

            // time
            timer3.Start();


            //// Initialized 
            /// thread for keypressed detect  
            startKeyPressDetectThread();


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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void loginStatus()
        {
            // //  Console.WriteLine("finalizer thread ID: {0}", (string)Thread.GetData(Program.dataslot));
            // Console.WriteLine("finalizer thread ID: {0}", Program.UserID);
        }
        private void button3_Click(object sender, EventArgs e)
        {


            timerSettingDisabledEnabled();

            this.loginStatus();

            // // Console.WriteLine("finalizer thread ID: {0}", (string)Thread.GetData(Program.dataslot));

            keypressed_label.Text = "Reset";


            start.Enabled = true;
            button2.Enabled = true;



            mouse_click_counter = 0;
            key_typing_counter = 0;

            // typing interval
            textBox1.Text = "100";
            textBox2.Text = "5000";


            //clicking interval
            textBox3.Text = "100";
            textBox4.Text = "5000";

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
            comboBox1.Enabled = true;
            sounds_time_play_value_textBox5.Enabled = true;
            enable_click_checkbox1.Enabled = true;
            enable_typing_checkbox2.Enabled = true;
            ctr_plug_tab_checkbox1.Enabled = true;


            timer1.Stop();
            timer2.Stop();

        }


        // change tab
        private void timer3_Tick(object sender, EventArgs e)
        {




            try {


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
                sounds_time_play_value = Int32.Parse(sounds_time_play_value_textBox5.Text);

                if (sounds_time_play_type_comboBox1.Text == "Hours")
                {
                    // //Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " hours ");
                    if (hours % sounds_time_play_value == 0)
                    {
                        if (hours != 0) {
                            if (prevHour != hours) {
                                if (start.Enabled == false)
                                {
                                    Thread th = new Thread(playSounds);
                                    th.Start();
                                    prevHour = hours;

                                    if (ctr_plug_tab_checkbox1.Checked == true)
                                    {
                                        send_key_ctr_plus_tab();
                                    }

                                    setMessageLog();
                                }
                            }
                        }
                    }
                }
                else if (sounds_time_play_type_comboBox1.Text == "Minutes")
                {
                    // //Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " mins ");
                    if (minutes % sounds_time_play_value == 0)
                    {
                        if (minutes != 0)
                        {
                            if (prevMin != minutes)
                            {
                                if (start.Enabled == false)
                                {
                                    Thread th = new Thread(playSounds);
                                    th.Start();
                                    prevMin = minutes;

                                    if (ctr_plug_tab_checkbox1.Checked == true)
                                    {
                                        send_key_ctr_plus_tab();
                                    }

                                    setMessageLog();
                                }
                            }
                        }
                    }
                }
                else if (sounds_time_play_type_comboBox1.Text == "Seconds")
                {
                    // //Console.WriteLine(" Sounds will play every  " + sounds_time_play_value_textBox5.Text + " seconds ");
                    if (seconds % sounds_time_play_value == 0)
                    {
                        if (seconds != 0)
                        {
                            if (prevSec != seconds)
                            {
                                if (start.Enabled == false) {

                                    Thread th = new Thread(playSounds);
                                    th.Start();
                                    prevSec = seconds;

                                    if (ctr_plug_tab_checkbox1.Checked == true)
                                    {
                                        send_key_ctr_plus_tab();
                                    }

                                    setMessageLog();
                                }
                            }
                        }
                    }
                }
                /**
                * Beed Sounds End
                */
                label10.Text = hours_zero + hours.ToString() + " : " + minutes_zero + minutes.ToString() + " : " + seconds_zero + seconds.ToString();
            }
            catch (Exception ex)
            {
                Log lg = new Log();
                lg.addText(" Error Exception Message: " + ex.Message);
            }
        }



        void setMessageLog()
        {
            Log log = new Log();

            // add log 
            log.addText(
                "Time Interval: " + sounds_time_play_value + " " + sounds_time_play_type_comboBox1.Text + "\n" +
                "Typing time interval between " + textBox1.Text + " and " + textBox2.Text + "\n" +
                "Clicking time interval between " + textBox3.Text + " and " + textBox4.Text + "\n" +
                "Total Click: " + log_click_total + "\n" +
                "Total Typing: " + log_typing_total
            );

            // refresh total typing and clicking for log
            log_click_total = 0;
            log_typing_total = 0;
        }

        void send_key_ctr_plus_tab()
        {
            // Random r = new Random();
            // n1 = r.Next(0, changeScreenKeys.Length); // select letters
            // nextScreen = changeScreenKeys[n1];
            //if (changeScreenKeysUsed.Contains(test)) { 
            // }
            //Console.log(" change screen " + nextScreen);


            // sublime,browser,vs-code
            //SendKeys.Send(nextTab);


            // // Console.WriteLine(" box " + tab_type_combobox.Text);
            // //Console.WriteLine(" box " + tab_type_combobox.Text);

            //label10.Text =
            // label13.Text = comboBox1.Text; 

            if (comboBox1.Text == "Phpstorm")
            {
                // SendKeys.Send("^{Tab}"); 
                SendKeys.Send(nextTabPhpstorm);
            }
            else
            {
                // phpstorm
                SendKeys.Send(nextTabVsSublimeBrowser);


            }

        }

        /**
        * src: http://www.soundjay.com/typewriter-sounds.html
        * src: http://www.grsites.com/archive/sounds/category/23/
        * src: http://www.soundjig.com/pages/soundfx/beeps.html
        */

        void playSoundsDynamic()
        {
            SoundPlayer sound = new SoundPlayer(@"" + sounds_src + "");
            sound.Play();
        }

        private void sounds_time_play_type_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void enable_typing_checkbox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void enable_click_checkbox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //if ((string)Thread.GetData(Program.dataslot) == "loggedin")


            Authentication Auth = new Authentication();
            Auth.logout();


            if (Program.UserID == "loggedin")
            {
                // Thread.SetData(Program.dataslot, "");

                this.Hide();

                Login myLogin = new Login();

                myLogin.Show();


                Program.UserID = "";

            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();

            System.Windows.Forms.Application.Exit();

            System.Environment.Exit(0);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }


        private bool timerSettingDisable()
        {
            radioButton_TimerSetting_Do_Nothing.Enabled = false;
            radioButton_TimerSetting_Auto_Stop.Enabled = false;
            radioButton_TimerSetting_Auto_Shutdown.Enabled = false;
            numeric_Setting_Hour.Enabled = false;
            numeric_Setting_Minute.Enabled = false;

            return false;
        }
        private bool timerSettingEnable()
        {
            radioButton_TimerSetting_Do_Nothing.Enabled = true;
            radioButton_TimerSetting_Auto_Stop.Enabled = true;
            radioButton_TimerSetting_Auto_Shutdown.Enabled = true;
            numeric_Setting_Hour.Enabled = true;
            numeric_Setting_Minute.Enabled = true;


            return true;
        }

        private bool timerSettingDisabledEnabled()
        {
            if (checkbox_Setting_Enable_Disable.Checked == true)
            {
                if (start.Enabled == false)
                {
                    return timerSettingDisable();
                }
                else
                {
                    return timerSettingEnable();
                }
            }
            else
            {

                Console.WriteLine("Timer settings - can't do disable or enable because it's not checked");

                return timerSettingDisable();
            }


        }
        public static String minutesToTime(int mins)
        {
            int hours = (mins - mins % 60) / 60;
            return "" + hours + ":" + (mins - hours * 60);
        }

        private int getTotalMinutes(int settingHour, int settingMinute, int hour, int minute)
        {
         

            int minutes = 0; 
 

            try
            {
                // calculate the total time as countdown
                String pabaigosLaikoLaukelis = settingHour + ":" + settingMinute;
                String pradziosLaikoLaukelis = hour + ":" + minute;
                TimeSpan startTime = Convert.ToDateTime(pradziosLaikoLaukelis).TimeOfDay;
                TimeSpan endTime = Convert.ToDateTime(pabaigosLaikoLaukelis).TimeOfDay;
                TimeSpan diff = endTime > startTime ? endTime - startTime : endTime - startTime + TimeSpan.FromDays(1);
                // String minutes = diff.TotalMinutes.ToString();
                minutes = (int)diff.TotalMinutes;

            }
            catch (Exception e)
            {

                timerSettingReset(); 

                System.Windows.Forms.MessageBox.Show("Invalid input");
                Console.WriteLine("{0} Exception caught.", e);
            }
              
            return minutes;
        }

        private void timerSettingReset()
        {

            numeric_Setting_Hour.Value = 0;
            numeric_Setting_Minute.Value = 0;
        }

        private void timer_setting_Tick(object sender, EventArgs e)
        { 
            // Console.WriteLine("Timer counting");
            Console.Write("Current Date and Time is : ");
            DateTime now = DateTime.Now;
            // Console.WriteLine(now.TimeOfDay);
            // Console.WriteLine(now.Hour);
            // Console.WriteLine(now.Minute);
     
             
            int settingHour = (int) numeric_Setting_Hour.Value;
            int settingMinute = (int) numeric_Setting_Minute.Value;
             
            int minute = now.Minute;
            int hour = now.Hour;
             
            timerSettingDisabledEnabled();

            if (checkbox_Setting_Enable_Disable.Checked == true)
            { 
                Console.WriteLine("custom hour " + settingHour);

                Console.WriteLine("custom minute " + settingMinute);

                Console.WriteLine(" radioButton_TimerSetting_Do_Nothing = " + radioButton_TimerSetting_Do_Nothing.Checked);
                Console.WriteLine(" radioButton_TimerSetting_Auto_Stop = " + radioButton_TimerSetting_Auto_Stop.Checked);
                Console.WriteLine(" radioButton_TimerSetting_Shutdown = " + radioButton_TimerSetting_Auto_Shutdown.Checked);

                if (start.Enabled == false)
                {
                    if (settingHour == hour && settingMinute == minute)
                    {

                        if (radioButton_TimerSetting_Auto_Stop.Checked == true)
                        {

                            pauseApp();
                            Console.WriteLine("Time Setting Running: Pause Timer");

                            
                        }
                        else if (radioButton_TimerSetting_Auto_Shutdown.Checked == true)
                        {

                           shutdownApp();
                            Console.WriteLine("Time Setting Running: Shutdown Unit");
                        }
                        else
                        {
                            Console.WriteLine("Time Setting Running:  Do Nothing");
                        }
                    }
                    else if (settingHour < hour)
                    {
                        Console.WriteLine("Time Setting Running: Too much late");
                    }
                    else
                    {
                        Console.WriteLine("Waiting for time to arrive to execute time settings ");

                        Console.WriteLine(" Time Set Hour: " + settingHour);
                        Console.WriteLine(" Time Set Minute: " + settingMinute);

                        Console.WriteLine(" Time System Hour: " + hour);
                        Console.WriteLine(" Time System Minute: " + minute);
                    }
                }
                else
                {
                    if (settingHour == hour && settingMinute == minute)
                    {
                        Console.WriteLine("Time Setting: It's time now");

                        if (radioButton_TimerSetting_Auto_Stop.Checked == true)
                        {
                            Console.WriteLine("Stop Timer");
                        }
                        else if (radioButton_TimerSetting_Auto_Shutdown.Checked == true)
                        {
                            Console.WriteLine("Shutdown Unit");
                        }
                        else
                        {
                            Console.WriteLine("Do Nothing");
                        }
                    }
                    else if ((settingHour == hour && settingMinute > minute) ||
                            (settingHour > hour)) 
                    {
                         
                         Console.WriteLine("Time Setting: Correct Setup - you are waiting to reach time time. Start now! ");
                        
                    }
                    else if (settingHour < hour)
                    {
                        Console.WriteLine("Time Setting: Too much late");
                    }
                    else
                    {
                        Console.WriteLine("Time Setting: Nothing");
                    }
                     
                    Console.WriteLine("Waiting to start for time settings");

                    Console.WriteLine(" Time Set Hour: " + settingHour);
                    Console.WriteLine(" Time Set Minute: " + settingMinute);

                    Console.WriteLine(" Time System Hour: " + hour);
                    Console.WriteLine(" Time System Minute: " + minute);
                }
                 
                label_Setting_Time_Setting_Display.Text = settingHour + ":" + settingMinute;
                label_Setting_Time_System_Display.Text = hour + ":" + minute + ":" + now.Second;
                   
                label_Setting_Time_Total.Text =  minutesToTime(getTotalMinutes(settingHour, settingMinute, hour, minute)); 
            }
            else
            {
                Console.WriteLine(" Timer Settings isn't enabled (countdown - stop, shutdown) ");
            }
             
            // string[] words = now.TimeOfDay.Split(':');
            // foreach (var word in words)
            // {
            // //     System.Console.WriteLine($"<{word}>");
            // }
        }

        private void checkbox_Setting_Enable_Disable_CheckedChanged(object sender, EventArgs e)
        {
            if(checkbox_Setting_Enable_Disable.Checked)
            {



            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

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
            if(start.Enabled == false && playSoundStatus == true)
            { 
                 int frequency = Int32.Parse("626");
                 int duration = Int32.Parse(sound_duration_textBox5.Text);
                 Console.Beep(frequency, duration);   
                 //SoundPlayer simpleSound = new SoundPlayer(@"http://static1.grsites.com/archive/sounds/cartoon/cartoon008.wav");
                 //simpleSound.Play(); 
            }
            //}  
        } 

        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; 
        
        
        /**
         * Start button clicked
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {

            string origAssemblyLocation = Assembly.GetExecutingAssembly().CodeBase;

            string origAssemblyL = System.Reflection.Assembly.GetEntryAssembly().Location;

            // Console.WriteLine("Application.StartupPath; " + origAssemblyLocation);
            // Console.WriteLine("origAssemblyL; " + origAssemblyL);
            // Console.WriteLine("origAssemblyL; " + Path.GetDirectoryName(origAssemblyL));
        

            Authentication Auth = new Authentication();

            // Console.WriteLine(" Auth Token: " + Auth.getLoggedin());
             
            HttpClient client = new HttpClient();
            // client.BaseAddress = new Uri("http://easimpt.test/api/");
            client.BaseAddress = new Uri("https://app.easimpt.com/api/");
            HttpResponseMessage response = client.GetAsync("authenticate/desktp-timer-start?token=" + Auth.getLoggedin()).Result;
            
            string statusResponse = response.Content.ReadAsStringAsync().Result;



            // // Console.WriteLine(" testResponse ", testResponse);

            // todo - check if the user is allowed to start or not

            /*
            HttpClient client = new HttpClient();
            //   client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            client.BaseAddress = new Uri("https://app.easimpt.com/api/");
            HttpResponseMessage response = client.GetAsync("authenticate/check?token=12345678").Result;
            accessStatus = response.Content.ReadAsStringAsync().Result;
            */
            // Console.WriteLine("access response = " + statusResponse);


            /*JObject joResponse = JObject.Parse(response);
            JObject ojObject = (JObject)joResponse["response"];
            JArray array = (JArray)ojObject["chats"];
            int id = Convert.ToInt32(array[0].toString());
            */


            label_announcement.Text = announcement; // announcement

            if (statusResponse == "1") {
               // label_announcement.Text = "Success";
                keypressed_label.Text = "Start";
                timer1.Start(); // tpying
                timer2.Start(); // clicking
                //enable fields for interval
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                sound_duration_textBox5.Enabled = false;
                sounds_time_play_type_comboBox1.Enabled = false;
                comboBox1.Enabled = false;
                sounds_time_play_value_textBox5.Enabled = false;
                ctr_plug_tab_checkbox1.Enabled = false;
                enable_click_checkbox1.Enabled = false;
                enable_typing_checkbox2.Enabled = false;



                start.Enabled = false;
                button2.Enabled = true;

              
            } 
            else
            { 
                string title = "Announcement";
                string message = "";

                if (statusResponse == "5")
                {
                      message = "Please logout and login again \n\n STATUS: " + statusResponse;
                } else
                { 
                  message = "Sorry, using this app isn't allowed. Please contact the owner in order to resume using this app. \n\n STATUS: "  + statusResponse;
                }
                 
                // label_announcement.Text = "Sorry, using this app isn't allowed. \n Please contact the owner in order to resume \n using this app.";
                // // Console.WriteLine("Sorry, using this app isn't allowed. Please contact the owner in order to resume using this app.");
                 
                MessageBox.Show(message, title);
            }


            timerSettingDisabledEnabled();
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
            pauseApp(); 
        }

        private void pauseApp()
        {

            timerSettingDisabledEnabled();

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
            comboBox1.Enabled = true;
            sounds_time_play_value_textBox5.Enabled = true;
            ctr_plug_tab_checkbox1.Enabled = true;
            enable_click_checkbox1.Enabled = true;
            enable_typing_checkbox2.Enabled = true;

            start.Enabled = true;
            button2.Enabled = false;
        }


        private void shutdownApp()
        { 
            // System.Windows.Forms.MessageBox.Show("Assistant Message: System is about to shutdown in 5 seconds."); 
            // int wait = 0; 
            // int milliseconds = 5000;
            // await Task.Delay(milliseconds); 
            // //System.Diagnostics.Process.Start("shutdown", "/s /t 0");

            closeAllOpenApp(); 

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("shutdown", "/s /t 0")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }

        private void closeAllOpenApp()
        {

        }



        // app is typing
        private void timer1_Tick(object sender, EventArgs e)
        {
            // change speed of the time 
            // change time limit for sleep 
            // new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 1, 1, 1);

  
            if (enable_typing_checkbox2.Checked == true)
            { 
                try
                { 
                    // Console.WriteLine("timer 1 ticking");
                     
                    Random r = new Random();
                    n1 = r.Next(0, randKey.Length); // select letters
                     
                    int sleepLimit = 1000; // r.Next(0, randKey.Length);;
                      
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


                    // Console.WriteLine("Typing Pause: " + s2);



                    // form title changing while app is running
                    string str = "........";
                    this.Text = str.Substring(0, r.Next(1, str.Length));


                    log_typing_total++;



                    // Console.WriteLine(" TYPING SOUND SETTINGS " + checkbox_typing_sound.Checked);
                    if(checkbox_typing_sound.Checked == true)
                    {
                        sounds_src = "sound/typewriter-key-1.wav";
                        Thread th = new Thread(playSoundsDynamic);
                        th.Start();
                    }


                }
                catch (Exception ex)
                {
                    Log lg = new Log();
                    lg.addText(" Error handling typing message: " + ex.Message);
                }
            }
        }












        #region Key press detect


            private bool isRunning = true;
            private int pressed = 0;


            public void startKeyPressDetectThread()
            {
                Thread TH = new Thread(Keyboardd11);
                TH.SetApartmentState(ApartmentState.STA);
                CheckForIllegalCrossThreadCalls = false;
                TH.Start();
            }


            public void Keyboardd11()
            {
                while (isRunning)
                {
                    Thread.Sleep(100);

                    if ((Keyboard.GetKeyStates(Key.Escape) & KeyStates.Down) > 0)
                    {
                        PressedStopButton();
                    }
                     
                    else if ((Keyboard.GetKeyStates(Key.H) & (Keyboard.GetKeyStates(Key.LeftAlt))  & KeyStates.Down) > 0)
                    {
                        // Console.WriteLine("You've triggered to hide the application...");
                        this.Hide();
                    }
                    
                    else if ((Keyboard.GetKeyStates(Key.S) & (Keyboard.GetKeyStates(Key.LeftAlt)) & KeyStates.Down) > 0)
                    { 
                        if (Program.UserID  == "loggedin") {   
                            // Console.WriteLine("You've triggered to show the application...");
                            this.Show();
                        }
                    } 
                    else if ((Keyboard.GetKeyStates(Key.G) & KeyStates.Down) > 0)
                    {
                        this.PressedStartButton();
                    }

                }
            }





            //// this is the copy of start button click 
             void PressedStartButton()
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
            comboBox1.Enabled = false;
            sounds_time_play_value_textBox5.Enabled = false;
            ctr_plug_tab_checkbox1.Enabled = false;
            enable_click_checkbox1.Enabled = false;
            enable_typing_checkbox2.Enabled = false;

        

            start.Enabled = false;
            button2.Enabled = true;

            /*




        // Console.WriteLine("Start pressed");


            timer1.Start();
            timer2.Start();


            keypressed_label.Text = "Start";






            //enable fields for interval
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            sound_duration_textBox5.Enabled = false;
            sounds_time_play_type_comboBox1.Enabled = false;
            comboBox1.Enabled = false;
            sounds_time_play_value_textBox5.Enabled = false;
            ctr_plug_tab_checkbox1.Enabled = false;
           // enable_click_checkbox1.Enabled = false;
            enable_typing_checkbox2.Enabled = false;

        start.Enabled = false;
            button2.Enabled = true;


            // Console.WriteLine(keypressed_label.Text);

        */

        }

        //// this is the copy of start button click 
        /// this is triggered when hold [esc] key
        void PressedStopButton()
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
                comboBox1.Enabled = true;
                sounds_time_play_value_textBox5.Enabled = true;
                ctr_plug_tab_checkbox1.Enabled = true;
                enable_click_checkbox1.Enabled = true;
                enable_typing_checkbox2.Enabled = true;


            start.Enabled = true;
                button2.Enabled = false;
                // Console.WriteLine(keypressed_label.Text);
            }

            //// this is the copy of start button click 
             void PressedResetButton()
            {

                keypressed_label.Text = "Reset";

                start.Enabled = true;
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
                comboBox1.Enabled = true;
                sounds_time_play_value_textBox5.Enabled = true;
                ctr_plug_tab_checkbox1.Enabled = true;
               // enable_click_checkbox1.Enabled = true;
                enable_typing_checkbox2.Enabled = true; 
                timer1.Stop();
                timer2.Stop();
                // Console.WriteLine(keypressed_label.Text);
            }

        #endregion Key press detect
         
         
    }
}
