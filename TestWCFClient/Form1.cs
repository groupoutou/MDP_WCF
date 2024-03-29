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
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;// affiche la barre des tâches en plein écran
            this.DoubleBuffered = true;
        }


        private bool Motvalide(string text )
        {
            if( text != "")
            {
                foreach(string str in banlist) {
                    string strlow = str.ToLower();
                    string textlow = text.ToLower();
                    int commonCharacters = (strlow.Distinct()).Intersect(textlow.Distinct()).Count();
                    bool isMoreThanHalf = (double)commonCharacters / strlow.Length > 0.5;
                    if (isMoreThanHalf)
                    {
                        listBox1.Items.Add("Mot trop proche d'un mot banni");
                        return false;
                    }
                }
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
                if (Chat.Items.Count == 0)
                {
                    Chat.Items.Add(newline);
                }
                else
                {
                    if (newline != Chat.Items[Chat.Items.Count - 1].ToString())
                    {
                        Chat.Items.Add(newline);
                    }
                }
            }
            else if (mode==1)
            {
                if (newline[0] == '1')
                {
                    Chat.Items.Add("Vous êtes le détenteur du mot de passe");
                    int numero = newline[1] - '0';
                    newline = newline.Substring(2);
                    banlist = newline.Split(';') ;
                    Chat.Items.Add("Vous devez faire deviner :" + banlist[numero]);
                    role.Text = "Vous devez faire deviner: " + banlist[numero];
                    banw.Text = "Mots bannis: "; //+banlist
                    gagner = false;
                    mode = 2;
                }
                if (newline[0] == '2')
                {
                    Chat.Items.Add("Vous devez deviner le mot de passe");
                    role.Text = "Vous devez deviner le mot de passe";
                    banw.Text = "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪"; //tkt
                    gagner = false;
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

        private void textBoxPing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (mode == 2 && !gagner)
                {
                    s.Envoie(ID, textBoxPing.Text);
                    textBoxPing.Clear();
                }
            }
        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sendkey_Click(object sender, EventArgs e)
        {
            if (mode == 2 && !gagner)
            {
                if (!gagner && Motvalide(textBoxPing.Text))
                    s.Envoie(ID, textBoxPing.Text);
                textBoxPing.Clear();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Voulez-vous vraiment quitter la partie ?", "Pas déjà ?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r== DialogResult.Yes)
            {
                Chat.Items.Add(string.Format("joueur{0} à quitté la partie ", ID)); //marche pas zebi
                this.Close();
            }
        }

        private void danseclk_Tick(object sender, EventArgs e) //TKT
        {
            if (banw.Text == "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪")
            {
                banw.Text = "   └|∵|┐♪   ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪";
            }
            else if (banw.Text == "   └|∵|┐♪   ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪")
            {
                banw.Text = "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪";
            }
        }

        private void banw_Click(object sender, EventArgs e)
        {

        }

        private void role_Click(object sender, EventArgs e)
        {

        }
    }
}
