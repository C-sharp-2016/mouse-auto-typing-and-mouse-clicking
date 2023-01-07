using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading; 


// resources: https://www.demo2s.com/csharp/csharp-thread-setdata-localdatastoreslot-slot-object-data.html
namespace typing_and_clicking
{
    public partial class Login : Form
    {
     
        private string loginStatus = "";


        public Login()
        {
            /*
            HttpContext context = HttpContext.Current;
            context.Session["FirstName"] = firstName;
            firstName = (string)(context.Session["FirstName"])
                */
            InitializeComponent();

            label_failed_login.Text = "";
            label_login_wait.Text = "";

            //username.Text = "mrjesuserwinsuarez@gmail.com";
            //password.Text = "password";

            //username.Text = "jesus@gmail.com";
           // password.Text = "password";
        } 
        private void groupBox1_Enter(object sender, EventArgs e)
        { 
        } 
        private void username_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(" enter username"); 
        }  
        private void password_TextChanged(object sender, EventArgs e)
        { 
            Console.WriteLine(" enter passw");  
        }   
        private void login_btn_Click(object sender, EventArgs e)
        {
            this.setLogin();
        } 
        private void setLogin ()
        {
            label_login_wait.Text = "Please wait..";
            label_failed_login.Text = "";

            HttpClient client = new HttpClient();
            // client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            client.BaseAddress = new Uri("https://app.easimpt.com/api/");
            // client.BaseAddress = new Uri("http://easimpt.test/api/");
            HttpResponseMessage response = client.GetAsync("authenticate/login?password=" + password.Text + "&email="+username.Text).Result;
            loginStatus = response.Content.ReadAsStringAsync().Result;
             
            Console.WriteLine(loginStatus);

           /*
           if (contents.response)
           {
               Console.WriteLine(" response " + contents.response.message);
           }

           var client = new RestClient("http://localhost:3000/Api/GetCustomerDetailsByCustomerId/" + id);
           var request = new RestRequest(Method.GET);
           request.AddHeader("X-Token-Key", "dsds-sdsdsds-swrwerfd-dfdfd");
           IRestResponse response = client.Execute(request);
           var content = response.Content; // raw content as string
           dynamic json = JsonConvert.DeserializeObject(content);
           JObject customerObjJson = json.CustomerObj;
           var customerObj = customerObjJson.ToObject<Customer>();
           return customerObj;
           */
              
            // Console.WriteLine("login now.."); 
            //Console.WriteLine("username" + username.Text);
            //Console.WriteLine("password" + password.Text);
             
            if(loginStatus != string.Empty && loginStatus != "422")
           // if (password.Text == "test" && username.Text == "test")
            {
                // Thread.SetData(Program.dataslot, "loggedin");
                
                Authentication Auth = new Authentication();
                Auth.login(loginStatus);

                if (Auth.getLoggedin() != string.Empty)
                {
                    Program.UserID = "loggedin"; 
                }
                 
                //if ((string)Thread.GetData(Program.dataslot) == "loggedin")
                if (Program.UserID == "loggedin")
                {
                    // this will hide the current login form if the authentication is correct.
                    this.Hide();

                    // this will show the login form if the authentication username and password is correct from the server.
                    Form1 myForm1 = new Form1();

                    myForm1.Show();

                    Console.WriteLine("Successfully Authenticated");

                    label_login_wait.Text = "";
                     
                    Authentication auth = new Authentication();   
                }
            }
            else
            {
                Console.WriteLine("Invalid Credintials");

                label_failed_login.Text = "Invalid Credintials, please reset your password.";
                label_login_wait.Text = "";
            }

            Console.WriteLine("finalizer thread ID: {0}", Program.UserID);
        }

        private void label_failed_login_Click(object sender, EventArgs e)
        {

        }

        private void forgot_password_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            System.Diagnostics.Process.Start("https://easimpt.com/password/reset");
        }
    }
}
