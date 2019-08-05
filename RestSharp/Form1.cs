using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RestSharp
{
    public partial class Form1 : Form
    {
        RestClient restclient = new RestClient("https://mcclabeltest.servicenow.com/");


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restclient.Authenticator = new HttpBasicAuthenticator("postmate.api", "M$Fl0w2019");
            var request = new RestRequest("api/now/table/sys_user?sysparm_query=user_name%3Djohn.mark.kennedy&sysparm_display_value=true&sysparm_exclude_reference_link=true&sysparm_fields=sys_id%2C%20user_name%2C%20location&sysparm_limit=1", Method.GET);

            var response = restclient.Get(request);

            MessageBox.Show(response.StatusCode.ToString());

            var sysid=JsonConvert.DeserializeObject<RootSysID>(response.Content);

            foreach (var sysidDet in sysid.result)
            {
                MessageBox.Show(sysidDet.location.ToString());
            }
                


        }
    }



    public class RootSysID
    {
        public SysID[] result { get; set; }
    }

    public class SysID
    {
        public string sys_id { get; set; }
        public string user_name { get; set; }
        public string location { get; set; }
    }

}
