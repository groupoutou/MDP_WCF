using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private bool mj;
        private  string[] banlist;
        private int compteur, score;
        string horodatage = string.Format("{0:00} : {1:00}", System.DateTime.Now.Hour, System.DateTime.Now.Minute);
        public FormClient()
        {
            InitializeComponent();
            scf = new ChannelFactory<TestWCF.IService>(new NetTcpBinding(), "net.tcp://localhost:8000");
            s = scf.CreateChannel();
            ID =  s.AskID();
            mode = 3;
            compteur = 0;
            score = 0;

            if (ID == -1)
            {
                MessageBox.Show("capacité maximal atteinte");
                this.Close();
            }
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;// affiche la barre des tâches en plein écran
            this.DoubleBuffered = true;
            timerpartie.Start();
            CROWNM.Hide();
            CROWNV.Hide();
            CROWNR.Hide();
            txtm.Hide();
            txtv.Hide();
            txtr.Hide();
            DIAGM.Hide();
            DIAGV.Hide();
            DIAGR.Hide();
        }

        private string Motvalide(string text )
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
                        Chat.Items.Add("Mot trop proche d'un mot banni");
                        return "Mot trop proche d'un mot banni";
                         
                    }
                }
                return text;
            }
            return text;
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            (s as ICommunicationObject).Close();
        }

        //scan du serveur
        private void timer1_Tick(object sender, EventArgs e)
        {

            string newline = s.Maj(ID , mode);
            if (mode == 2)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (newline == string.Format("joueur {0} à trouvé le mot de passe ", i))
                    {
                        if (i == 0)
                        {
                            CROWNM.Show();
                        }
                        if (i == 1)
                        {
                            CROWNR.Show();
                        }
                        if (i == 2)
                        {
                            CROWNV.Show();
                        }
                        if (i == ID)
                        {
                            gagner = true;
                            if (timerpartie.Enabled == true)
                            {
                                timerpartie.Stop();
                                score += (int)(10800 * (1 / ((double)compteur + 1)));
                                Scorelabel.Text = "Score: " + score + " pts";
                            }
                        }
                    }
                }
                if (newline == "tous les joueur ont gagnés")
                {
                    CROWNM.Show();
                    CROWNV.Show();
                    CROWNR.Show();

                    if (timerpartie.Enabled == true)
                    {
                        timerpartie.Stop();
                        score += (int)(10800 * (1 / ((double)compteur + 1)));
                        Scorelabel.Text = "Score: " + score + " pts";
                    }
                    startlabel.Show();
                    mode = 3;
                }

                if (Chat.Items.Count == 0)
                {
                    Chat.Items.Add(newline);
                }
                else
                {
                    if (newline != Chat.Items[Chat.Items.Count - 1].ToString())
                    { // ligne nouvelle
                        if (!newline.Contains("Mot trop proche d'un mot banni"))
                        {

                            if (newline.Length > 10)
                            {
                                txtm.Hide();
                                txtv.Hide();
                                txtr.Hide();
                                DIAGM.Hide();
                                DIAGV.Hide();
                                DIAGR.Hide();
                                string bubble = newline.Substring(10, newline.IndexOf(' ', 10) - 10);
                                if (newline[6] == '0')
                                {
                                    txtm.Text = bubble;
                                    txtm.Show();
                                    DIAGM.Show();
                                }
                                if (newline[6] == '1')
                                {
                                    txtr.Text = bubble;
                                    txtr.Show();
                                    DIAGR.Show();
                                }
                                if (newline[6] == '2')
                                {
                                    txtv.Text = bubble;
                                    txtv.Show();
                                    DIAGV.Show();
                                }
                            }
                            Chat.Items.Add(newline);
                        }
                    }

                }
            }
            else if (mode == 1)
            {
                CROWNM.Hide();
                CROWNV.Hide();
                CROWNR.Hide();


                if (newline[0] == '1')
                {
                    Chat.Items.Add("Vous êtes le détenteur du mot de passe");
                    int numero = newline[1] - '0';
                    newline = newline.Substring(2);
                    banw.Text = "Mots bannis: \n" + newline;
                    banw.AutoSize = true;
                    banlist = newline.Split(';');
                    role.Text = "Vous devez faire deviner: " + banlist[numero];
                    mj = true;
                    gagner = false;
                    compteur = 0;
                    timerpartie.Start();
                    mode = 2;
                }
                if (newline[0] == '2')
                {
                    role.Text = "Vous devez deviner le mot de passe";
                    banw.Text = "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪"; //tkt
                    banw.AutoSize = true;
                    gagner = false;
                    mj = false;
                    compteur = 0;
                    timerpartie.Start();
                    mode = 2;
                }

            }
            else if (mode == 3)
            {
                startlabel.Show();
                Thread.Sleep(2000);
                startlabel.Hide();
                mode = 1;
            }
            
        }

  

       
        //envoie au serveur
        private void textBoxPing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (mode == 2 && !gagner)
                {
                    string newline = textBoxPing.Text;
                    if (mj)
                    {
                         newline = Motvalide(textBoxPing.Text);
                       
                    }
                    s.Envoie(ID, newline,horodatage);
                }
                textBoxPing.Clear();
            }
        }


        private void Sendkey_Click(object sender, EventArgs e)
        {
            if (mode == 2 && !gagner)
            {
                if (mode == 2 && !gagner)
                {
                    string newline = textBoxPing.Text;
                    if (mj)
                    {
                        newline = Motvalide(textBoxPing.Text);

                    }
                    s.Envoie(ID, newline, horodatage);
                }
                textBoxPing.Clear();
            }
            textBoxPing.Clear();
            ecrirelabel.Show();
        }


        private void logo_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Voulez-vous vraiment quitter la partie ?", "Pas déjà ?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r== DialogResult.Yes)
            {
                s.Envoie(ID,string.Format("joueur {0} à quitté la partie ", ID)); 
                this.Close();
            }
        }

        private void danseclk_Tick(object sender, EventArgs e) 
        {
            if (banw.Text == "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪")
            {
                banw.Text = "   └|∵|┐♪   ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪";
            }
            else if (banw.Text == "   └|∵|┐♪   ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪   └|∵|┐♪    ♪┌|∵⁠|┘♪")
            {
                banw.Text = "   ♪┌|∵⁠|┘♪   └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪   ♪┌|∵⁠|┘♪    └|∵|┐♪";
            }
        }


        private void ecrirelabel_Click(object sender, EventArgs e)
        {
            ecrirelabel.Hide();
        }

        private void textBoxPing_Click(object sender, EventArgs e)
        {
            ecrirelabel.Hide();
        }
        private void textBoxPing_TextChanged(object sender, EventArgs e)
        {
            ecrirelabel.Hide();
        }

        private void chatpan_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void Chat_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void rolepan_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void role_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void banw_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void FormClient_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void CHRONO_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void Scorelabel_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void JMAG_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void CROWNM_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void JROUGE_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void JVERT_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void DIAGP_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void DIAGV_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void DIAGR_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void txtm_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void txtr_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void txtv_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void DIAGM_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void Chat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void j1r_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void j2v_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void j0m_Click(object sender, EventArgs e)
        {
            if (textBoxPing.Text.Length == 0)
            {
                ecrirelabel.Show();
            }
        }

        private void timerpartie_Tick(object sender, EventArgs e)
        {
            compteur++;
            CHRONO.Text = string.Format("{0:00} : {1:00}", compteur / 60, compteur % 60);
        }
    }
}
