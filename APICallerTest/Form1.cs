using System;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace APICallerTest
{
    public partial class Form1 : Form
    {
        private const string m_URL = "https://dummyapi.io/data/v1/";
        private string m_UrlParameters = "user?page=1&limit=1";
        private const string m_AppIDKey = "app-id";
        private const string m_AppIDValue = "614cba9854da1109414ccd6b";
        private HttpClient m_Client;
        private APIData m_APIData;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Client = new HttpClient();
            m_Client.BaseAddress = new Uri(m_URL);
            m_Client.DefaultRequestHeaders.Add(m_AppIDKey, m_AppIDValue);

            if (m_Client.DefaultRequestHeaders.Contains(m_AppIDKey))
            {
                HttpResponseMessage response = m_Client.GetAsync(m_UrlParameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    string dataObject = response.Content.ReadAsStringAsync().Result;
                    richTextBox1.Text = JsonConvert.DeserializeObject(dataObject).ToString();


                    m_APIData = new APIData();
                    m_APIData.APIDataObj = JsonConvert.DeserializeObject<string[]>(dataObject);

                    richTextBox1.Text = m_APIData.APIDataObj[0];

                    //APIDataObject m_APIOne = new APIDataObject();
                    //m_APIOne.firstName = m_APIData.APIDataObj[0];
                    //richTextBox1.Text = m_APIOne.firstName;
                }
                else
                {
                    richTextBox1.Text =
                        response.ReasonPhrase.ToString() + " " +
                        response.Content.ReadAsStringAsync().Result;
                }
            }
        }

    }
}
