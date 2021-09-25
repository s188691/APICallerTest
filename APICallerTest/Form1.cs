using System;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace APICallerTest
{
    public partial class Form1 : Form
    {
        private const string m_URL = Helper.MAINURL;
        private string m_GetUrlParameters = Helper.GETURLPARAMS;
        private string m_PostUrlParameters = Helper.POSTURLPARAMS;
        private const string m_AppIDKey = Helper.APPIDKEY;
        private const string m_AppIDValue = Helper.APPIDVALUE;
        private HttpClient m_Client;
        private UsersMainData m_UsersMainData;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = m_Client.GetAsync(m_GetUrlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                string dataObject = response.Content.ReadAsStringAsync().Result;

                m_UsersMainData = new UsersMainData();
                m_UsersMainData = JsonConvert.DeserializeObject<UsersMainData>(dataObject);

                for (int x = 0; x < m_UsersMainData.data.Length; x++)
                {
                    string print = m_UsersMainData.data[x].firstName;
                    PrintToRichTextBox(print, richTextBox1);
                }

            }
            else
            {
                richTextBox1.Text =
                    response.ReasonPhrase.ToString() + " " + 
                    response.Content.ReadAsStringAsync().Result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreatePost createPost = new CreatePost();
            createPost.text = "Dogger oh ye";
            createPost.image = @"https://peteu.b-cdn.net/wp-content/uploads/2019/10/Pupreme-the-dog-face-red-dog.jpg";
            createPost.likes = 999;
            createPost.tags = new string[] {"animal", "shiba"};
            createPost.owner = "60d0fe4f5311236168a109ca";

            var output = new StringContent(JsonConvert.SerializeObject(createPost), Encoding.UTF8, "application/json");
            var postCall = m_Client.PostAsync(m_PostUrlParameters, output);
            string result = postCall.Result.Content.ReadAsStringAsync().Result;

            //Could be deserialized into new Object that matches JSON structure
            //to present response body data in nice way.

            PrintToRichTextBox(result, richTextBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_Client = new HttpClient();
            m_Client.BaseAddress = new Uri(m_URL);
            m_Client.DefaultRequestHeaders.Add(m_AppIDKey, m_AppIDValue);

            // This part should use the simplest possible GET call.
            HttpResponseMessage response = m_Client.GetAsync(@"https://dummyapi.io/data/v1/user/60d0fe4f5311236168a109ca").Result;
            if (response.IsSuccessStatusCode)
            {
                progressBar1.Value = 100;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        #region Helper methods
        private void PrintToRichTextBox(string input, RichTextBox textBox)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.AppendText(Environment.NewLine + input);
            }
            else
            {
                textBox.AppendText(input);
            }
            textBox.ScrollToCaret();
        }
        #endregion
    }
}
