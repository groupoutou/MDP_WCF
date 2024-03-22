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
            private int mj = 0;
            private string password = "calamar";
            private int nb_jouer;
            private int nb_winner;

            public ServiceImplementation(FormServeur f)
            {
                ihm = f;
            }

            public void Envoie(int ID, string msg)
            {
                if (msg == password)
                {
                    string newline = string.Format("joueur{0} à trouvé le mot de passe ", ID);
                    ihm.Historique.Items.Add(newline);
                    nb_winner++;
                    if(nb_jouer-1 == nb_winner)
                    {
                        mj = (mj + 1 )% (nb_jouer-1);
                        nb_winner = 0;
                       ihm.Historique.Items.Add("tous les joueur ont gagnes");
                    }
                }
                else
                {
                    string newline = string.Format("joueur{0} : ", ID) + msg;
                    if (ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString() != newline)
                    {
                        ihm.Historique.Items.Add(newline);
                    }
                }
            }

            public string Maj(int ID , int mode)
            {

                if(mode == 2){
                    if (ihm.Historique.Items.Count - 1 == -1)
                    {
                        return ihm.Historique.Items[0].ToString();
                    }
                    else
                    {
                        return ihm.Historique.Items[ihm.Historique.Items.Count - 1].ToString();
                    }
                }
                if(mode == 1)
                {
                   if(ID == mj)
                    {
                        ihm.Historique.Items.Add(string.Format("joueur{0} est le mj ", mj));
                        return ("1" + password);
                    }
                   else { return "2" ; }
                }
                return null;
            }

            // ajout d'une ID au jouer
            public int AskID() { 
                for (int i = 0; i < Program.nb_max_joueur; i++)
                {
                    if(Program.etat[i] == -1){
                        Program.etat[i] = 1;
                        ihm.Historique.Items.Add(string.Format("joueur{0} a rejoint ", i));
                        nb_jouer = i+1;
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
                typeof(TestWCF.IService),               //Démaragge du serveur
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
