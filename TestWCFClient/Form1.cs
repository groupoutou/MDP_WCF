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
        public FormClient()
        {
            InitializeComponent();
            scf = new ChannelFactory<TestWCF.IService>(new NetTcpBinding(), "net.tcp://localhost:8000");
            s = scf.CreateChannel();
            ID =  s.AskID();
            if (ID == -1)
            {
                MessageBox.Show("capacité maximal atteinte");
                this.Close();
            }

        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
           s.Envoie( ID , textBoxPing.Text);
           textBoxPing.Clear();
          
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            (s as ICommunicationObject).Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string newline = s.Maj();
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add(newline);
            }
            else {
                if (newline != listBox1.Items[listBox1.Items.Count - 1].ToString())
                {
                    listBox1.Items.Add(newline);
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
