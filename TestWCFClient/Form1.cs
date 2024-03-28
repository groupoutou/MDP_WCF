using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace TestWCFClient
{
    public partial class FormClient : Form

    {
        ChannelFactory<TestWCF.IService> scf;
        TestWCF.IService s;
        private bool gagner;
        private  string[] banlist;
        public FormClient()
        {
            InitializeComponent();
            scf = new ChannelFactory<TestWCF.IService>(new NetTcpBinding(), "net.tcp://localhost:8000");
            s = scf.CreateChannel();
            ID =  s.AskID();
            mode = 1;
            if (ID == -1)
            {
                MessageBox.Show("capacité maximal atteinte");
                this.Close();
            }

        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            if (mode == 2 && !gagner )
            {
                if(!gagner && Motvalide(textBoxPing.Text))
                s.Envoie(ID, textBoxPing.Text);
                textBoxPing.Clear();
            }
          
        }

        private bool Motvalide(string text )
        {
            if( text != "")
            {
                return true;
            }
            return false;
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            (s as ICommunicationObject).Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string newline = s.Maj(ID , mode);
            if (mode == 2)
            {
                if(newline == string.Format("joueur{0} à trouvé le mot de passe ", ID))
                {
                    gagner = true;
                }
                if (newline == "tous les joueur ont gagnes")
                {
                    mode = 1;
                }
                if (listBox1.Items.Count == 0)
                {
                    listBox1.Items.Add(newline);
                }
                else
                {
                    if (newline != listBox1.Items[listBox1.Items.Count - 1].ToString())
                    {
                        listBox1.Items.Add(newline);
                    }
                }
            }
            else if (mode==1)
            {
                if (newline[0] == '1')
                {
                    listBox1.Items.Add("Vous êtes le détenteur du mot de passe");
                    int numero = newline[1] - '0';
                    newline = newline.Substring(2);
                    banlist = newline.Split(';') ;
                    listBox1.Items.Add("Vous devez faire deviner :" + banlist[numero]);
                    gagner = false;
                    mode = 2;
                }
                if (newline[0] == '2')
                {
                    listBox1.Items.Add("Vous devez deviner le mot de passe");
                    gagner= false;
                    mode = 2;
                }

            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPing_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
