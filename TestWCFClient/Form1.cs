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
        public FormClient()
        {
            InitializeComponent();
            scf = new ChannelFactory<TestWCF.IService>(new NetTcpBinding(), "net.tcp://localhost:8000");
            s = scf.CreateChannel();
            ID =  s.AskID();
            mode = 1;
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
                        Chat.Items.Add("Mot trop proche d'un mot banni");
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
                    if(timerpartie.Enabled==true)
                    {
                        timerpartie.Stop();
                        score += (int)(10800 * (1 / ((double)compteur + 1)));
                        Scorelabel.Text = "Score: " + score + " pts";
                    }
                }
                if (newline == "tous les joueur ont gagnes")
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
                    mode = 1;
                }
                
                if (Chat.Items.Count == 0)
                {
                    Chat.Items.Add(newline);
                }
                else
                {
                    if (newline != Chat.Items[Chat.Items.Count - 1].ToString() && Chat.Items[Chat.Items.Count - 1].ToString() != "Mot trop proche d'un mot banni")
                    {
                        Chat.Items.Add(newline);
                    }
                }
            }
            else if (mode==1)
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
                    banlist = newline.Split(';') ;
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
            
        }

  

       

        private void textBoxPing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (mode == 2 && !gagner)
                {
                    if (mj && Motvalide(textBoxPing.Text))
                    {
                        s.Envoie(ID, textBoxPing.Text);
                    }
                    else if (!mj)
                    {
                        s.Envoie(ID, textBoxPing.Text);
                    }
                }
                textBoxPing.Clear();
            }
        }


        private void Sendkey_Click(object sender, EventArgs e)
        {
            if (mode == 2 && !gagner)
            {
                if (mj && Motvalide(textBoxPing.Text))
                {
                    s.Envoie(ID, textBoxPing.Text);
                }
                else if (!mj)
                {
                    s.Envoie(ID, textBoxPing.Text);
                }
            }
            textBoxPing.Clear();
            ecrirelabel.Show();
        }


        private void logo_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Voulez-vous vraiment quitter la partie ?", "Pas déjà ?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r== DialogResult.Yes)
            {
                s.Envoie(ID,string.Format("joueur{0} à quitté la partie ", ID)); //marche pas zebi
                this.Close();
            }
        }

        private void danseclk_Tick(object sender, EventArgs e) //TKT
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

        private void timerpartie_Tick(object sender, EventArgs e)
        {
            compteur++;
            CHRONO.Text = string.Format("{0:00} : {1:00}", compteur / 60, compteur % 60);
        }
    }
}
