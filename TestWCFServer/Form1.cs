﻿using System;
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
using System.Threading;

namespace TestWCFServer
{
    public partial class FormServeur : Form
    {

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        class ServiceImplementation : TestWCF.IService
        {
            FormServeur ihm;
            private int mj = 0;
            private string banlist;
            private string password;
            private int nb_jouer;
            private int nb_winner;

            public void ChangePassword()
            {
                var rand = new Random();
                string filepath = "../../../synonyme.csv";
                StreamReader sr = new StreamReader(filepath);
                for (int i = 0; i < rand.Next(0, 45); i++)
                {
                    banlist= sr.ReadLine();
                }
                int num = rand.Next(0, 9);
                string[] tab = banlist.Split(';');
                banlist = num + banlist;
                password = tab[num];
            }
            public ServiceImplementation(FormServeur f)
            {
                ihm = f;
            }

            public void Envoie(int ID, string msg,string horodatage = null)
            {
                if (msg.ToLower() == password.ToLower())
                {
                    string newline = string.Format("joueur {0} à trouvé le mot de passe ", ID);
                    ihm.Historique.Items.Add(newline);
                    nb_winner++;
                    if(nb_jouer-1 == nb_winner)
                    {
                        mj = (mj + 1 )% (nb_jouer-1);
                        nb_winner = 0;
                       ihm.Historique.Items.Add("tous les joueur ont gagnés");
                    }
                }
                else
                {        
                    string newline = string.Format("joueur{0} : ", ID) + msg;
                    int k = msg.Length;
                    for (int i = 0; i < 41 - (2 * k); i++)
                    {
                        newline += " ";
                    }
                    newline += horodatage;
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
                        ihm.Historique.Items.Add(string.Format("joueur {0} est le mj ", mj));
                        ChangePassword();
                       
                        return ("1" + banlist);
                    }
                   else { return "2" ; }
                }
                return null;
            }

            // ajout d'une ID au joueur
            public int AskID() { 
                for (int i = 0; i < Program.nb_max_joueur; i++)
                {
                    if(Program.etat[i] == -1){
                        Program.etat[i] = 1;
                        ihm.Historique.Items.Add(string.Format("joueur {0} a rejoint ", i));
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
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.DoubleBuffered = true;
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
