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
using Microsoft.SqlServer.Server;

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

            public void Envoie(int ID, string msg)
            {
                string newline  = string.Format("joueur{0} : " , ID) + msg;
                if (ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString() != newline)
                {
                    ihm.Historique.Items.Add(newline);
                }
            }

            public string Maj()
            {
                if (ihm.Historique.Items.Count - 1 == -1)
                {
                    return ihm.Historique.Items[0].ToString();
                }
                else
                {
                    return ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString();
                }

            }

            public int AskID() {
                for (int i = 0; i < Program.nb_max_joueur; i++)
                {
                    if(Program.etat[i] == -1){
                        Program.etat[i] = 1;
                        ihm.Historique.Items.Add(string.Format("joueur{0} a rejoint ", i));
                        return i;
                    }
                }; 
                return -1;
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

        private void FormServeur_Load(object sender, EventArgs e)
        {

        }
    }
}
