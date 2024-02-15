using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;

namespace TestWCFServer
{
    public partial class FormServeur : Form
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        class ServiceImplementation : TestWCF.IService
        {
            FormServeur ihm;
            public ServiceImplementation(FormServeur f)
            {
                ihm = f;
            }

            public void Envoie(string name, string msg)
            {
                string newline = name + msg;
                if (ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString() != newline)
                {
                    ihm.Historique.Items.Add(newline);
                }
            }

            public string Maj()
            {
                return ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString();

            }
        }

        ServiceHost svh;

        public FormServeur()
        {
            InitializeComponent();
            svh = new ServiceHost(new ServiceImplementation(this));
            svh.AddServiceEndpoint(
                typeof(TestWCF.IService),
                new NetTcpBinding(),
                "net.tcp://localhost:8000");
            svh.Open();
            Historique.Items.Add("Début communication");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
