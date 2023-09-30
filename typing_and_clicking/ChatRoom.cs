using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;


// https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=dotnet-plat-ext-7.0
namespace typing_and_clicking
{
    public partial class ChatRoom : Form
    {

        int gravity = 1;
        int speed = 20;
        string direction = "";
        string sounds_src = ""; 

        public ChatRoom()
        {
            InitializeComponent();

            // sounds_src = "sound/Mouse_click.wav";
             
            backgroundMusicRandom(); 
        }


        /*
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }




        private void backgroundMusicRandom()
        { 
            SetInterval(() => {
                Console.WriteLine("Change Sounds"); 
                  startPlaying(); 
            }, TimeSpan.FromSeconds(20)); 
        }
        */
        private void backgroundMusicRandom()
        {
            playMusic();  
        }
        private void playMusic()
        { 
            Random rand = new Random(); 
             
            sounds_src = "music/"+ rand.Next(8)+ ".wav";
            Thread th = new Thread(playSoundsDynamic);
            th.Start();
        }

        private void playSoundsDynamic()
        {
            SoundPlayer sound = new SoundPlayer(@"" + sounds_src + "");
            sound.PlayLooping();  
        }
   
    private void walk()
        {
            if (direction == "top")
            {
                personStand.Top -= speed;
            }
            else if (direction == "left")
            {
                personStand.Left -= speed;
            }
            else if (direction == "right")
            {
                personStand.Left += speed;
            }
            else if (direction == "bottom")
            {
                personStand.Top += speed; 
            }

           // personWalk.Top = personStand.Top; 
        }

        /*
        private void standing()
        {
            personStand.Visible = true;
            personWalk.Visible = false;
        }
        private void walking()
        {
            personStand.Visible = false;
            personWalk.Visible = true;
        }*/

        private void roomTimerEvent(object sender, EventArgs e)
        {


            //standing(); 

            //  person.Top += gravity;


        }

        private void roomKeyUpEvent(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KEY UP" );
        
        }

        private void roomKeyDownEvent(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KEY DOWN");
          

            if (e.KeyCode == Keys.Down)
            {
                direction = "bottom";
            }
            else if (e.KeyCode == Keys.Up)
            {
                direction = "top";
            }
            else if (e.KeyCode == Keys.Left)
            {
                direction = "left";
            }
            else if (e.KeyCode == Keys.Right)
            {
                direction = "right";
            }

            walk(); 

          //  walking()
          // walk(); 
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void personStand_Click(object sender, EventArgs e)
        {

        }

        private void changeSoundsEvent(object sender, EventArgs e)
        {
            Console.WriteLine("change sounds event"); 
           backgroundMusicRandom();
        }
    }
}
