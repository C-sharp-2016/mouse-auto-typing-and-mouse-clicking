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

            InitializeComponent();

            label_failed_login.Text = "";
            label_login_wait.Text = "";
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
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            HttpResponseMessage response = client.GetAsync("test/login?password=" + password.Text + "&email="+username.Text).Result;
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
             
            if(loginStatus == "200")
           // if (password.Text == "test" && username.Text == "test")
            {
                // this will hide the current login form if the authentication is correct.
                this.Hide();

                // this will show the login form if the authentication username and password is correct from the server.
                Form1 myForm1 = new Form1();

                myForm1.Show();

                Console.WriteLine("Successfully Authenticated");
                 
                label_login_wait.Text = "";
                 
                Thread.SetData(Program.dataslot, "foo"); 
            }
            else
            {
                Console.WriteLine("Invalid Credintials");


                label_failed_login.Text = "Invalid Credintials, please reset your password.";
                label_login_wait.Text = "";
            }



            //string ID = (string)Thread.GetData(dataslot);
            Console.WriteLine("finalizer thread ID: {0}", (string)Thread.GetData(Program.dataslot));
        }

        private void label_failed_login_Click(object sender, EventArgs e)
        {

        }


        /*
        async Task<string> GetResponseString(string text)
        {
            var httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>();
            parameters["text"] = text;

            var response = await httpClient.PostAsync(BaseUri, new FormUrlEncodedContent(parameters));
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        } */
    }




}
