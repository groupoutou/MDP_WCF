namespace TestWCFClient
{
    partial class FormClient
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int ID;
        private int mode;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Menu = new System.Windows.Forms.Panel();
            this.CHRONO = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.Chat = new System.Windows.Forms.ListBox();
            this.textBoxPing = new System.Windows.Forms.TextBox();
            this.chatpan = new System.Windows.Forms.Panel();
            this.ecrirelabel = new System.Windows.Forms.Label();
            this.Sendkey = new System.Windows.Forms.PictureBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rolepan = new System.Windows.Forms.Panel();
            this.banw = new System.Windows.Forms.Label();
            this.role = new System.Windows.Forms.Label();
            this.danseclk = new System.Windows.Forms.Timer(this.components);
            this.timerpartie = new System.Windows.Forms.Timer(this.components);
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.chatpan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sendkey)).BeginInit();
            this.rolepan.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(165)))), ((int)(((byte)(194)))));
            this.Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Menu.Controls.Add(this.CHRONO);
            this.Menu.Controls.Add(this.panel1);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(200, 465);
            this.Menu.TabIndex = 3;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // CHRONO
            // 
            this.CHRONO.AutoSize = true;
            this.CHRONO.Font = new System.Drawing.Font("Segoe UI Variable Small", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHRONO.Location = new System.Drawing.Point(3, 143);
            this.CHRONO.Name = "CHRONO";
            this.CHRONO.Size = new System.Drawing.Size(178, 64);
            this.CHRONO.TabIndex = 1;
            this.CHRONO.Text = "00 : 00";
            this.CHRONO.Click += new System.EventHandler(this.CHRONO_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 140);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // logo
            // 
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logo.Image = global::TestWCFClient.Properties.Resources.password_svgrepo_com100;
            this.logo.Location = new System.Drawing.Point(45, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(106, 104);
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(109)))), ((int)(((byte)(229)))));
            this.Chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.Chat.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(221)))));
            this.Chat.FormattingEnabled = true;
            this.Chat.ItemHeight = 20;
            this.Chat.Location = new System.Drawing.Point(0, 0);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(280, 400);
            this.Chat.TabIndex = 0;
            this.Chat.Click += new System.EventHandler(this.Chat_Click);
            // 
            // textBoxPing
            // 
            this.textBoxPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPing.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPing.Location = new System.Drawing.Point(3, 431);
            this.textBoxPing.Name = "textBoxPing";
            this.textBoxPing.Size = new System.Drawing.Size(240, 27);
            this.textBoxPing.TabIndex = 1;
            this.textBoxPing.Click += new System.EventHandler(this.textBoxPing_Click);
            this.textBoxPing.TextChanged += new System.EventHandler(this.textBoxPing_TextChanged);
            this.textBoxPing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPing_KeyPress);
            // 
            // chatpan
            // 
            this.chatpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(109)))), ((int)(((byte)(229)))));
            this.chatpan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatpan.Controls.Add(this.ecrirelabel);
            this.chatpan.Controls.Add(this.Sendkey);
            this.chatpan.Controls.Add(this.textBoxPing);
            this.chatpan.Controls.Add(this.Chat);
            this.chatpan.Dock = System.Windows.Forms.DockStyle.Right;
            this.chatpan.Location = new System.Drawing.Point(678, 0);
            this.chatpan.Name = "chatpan";
            this.chatpan.Size = new System.Drawing.Size(282, 465);
            this.chatpan.TabIndex = 5;
            this.chatpan.Click += new System.EventHandler(this.chatpan_Click);
            // 
            // ecrirelabel
            // 
            this.ecrirelabel.AutoSize = true;
            this.ecrirelabel.BackColor = System.Drawing.Color.White;
            this.ecrirelabel.Location = new System.Drawing.Point(12, 434);
            this.ecrirelabel.Name = "ecrirelabel";
            this.ecrirelabel.Size = new System.Drawing.Size(92, 20);
            this.ecrirelabel.TabIndex = 2;
            this.ecrirelabel.Text = "Ecrivez-ici...";
            this.ecrirelabel.Click += new System.EventHandler(this.ecrirelabel_Click);
            // 
            // Sendkey
            // 
            this.Sendkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Sendkey.Image = global::TestWCFClient.Properties.Resources.enter_key_one_svgrepo_com;
            this.Sendkey.Location = new System.Drawing.Point(249, 429);
            this.Sendkey.Name = "Sendkey";
            this.Sendkey.Size = new System.Drawing.Size(28, 29);
            this.Sendkey.TabIndex = 0;
            this.Sendkey.TabStop = false;
            this.Sendkey.Click += new System.EventHandler(this.Sendkey_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 465);
            this.panel2.TabIndex = 7;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // rolepan
            // 
            this.rolepan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(205)))), ((int)(((byte)(121)))));
            this.rolepan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rolepan.Controls.Add(this.banw);
            this.rolepan.Controls.Add(this.role);
            this.rolepan.Dock = System.Windows.Forms.DockStyle.Top;
            this.rolepan.Location = new System.Drawing.Point(200, 0);
            this.rolepan.Name = "rolepan";
            this.rolepan.Size = new System.Drawing.Size(478, 100);
            this.rolepan.TabIndex = 6;
            this.rolepan.Click += new System.EventHandler(this.rolepan_Click);
            // 
            // banw
            // 
            this.banw.AutoSize = true;
            this.banw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.banw.Font = new System.Drawing.Font("Segoe UI Variable Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banw.Location = new System.Drawing.Point(0, 79);
            this.banw.Name = "banw";
            this.banw.Size = new System.Drawing.Size(100, 19);
            this.banw.TabIndex = 1;
            this.banw.Text = "Mots bannis :";
            this.banw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.banw.Click += new System.EventHandler(this.banw_Click);
            // 
            // role
            // 
            this.role.AutoSize = true;
            this.role.Dock = System.Windows.Forms.DockStyle.Top;
            this.role.Font = new System.Drawing.Font("Segoe UI Variable Small", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role.Location = new System.Drawing.Point(0, 0);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(78, 32);
            this.role.TabIndex = 0;
            this.role.Text = "Rôle :";
            this.role.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.role.Click += new System.EventHandler(this.role_Click);
            // 
            // danseclk
            // 
            this.danseclk.Enabled = true;
            this.danseclk.Interval = 500;
            this.danseclk.Tick += new System.EventHandler(this.danseclk_Tick);
            // 
            // timerpartie
            // 
            this.timerpartie.Enabled = true;
            this.timerpartie.Interval = 1000;
            this.timerpartie.Tick += new System.EventHandler(this.timerpartie_Tick);
            // 
            // FormClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(960, 465);
            this.Controls.Add(this.rolepan);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.chatpan);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(940, 500);
            this.Name = "FormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Le Jeu du Mot de Passe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClient_FormClosed);
            this.Click += new System.EventHandler(this.FormClient_Click);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.chatpan.ResumeLayout(false);
            this.chatpan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sendkey)).EndInit();
            this.rolepan.ResumeLayout(false);
            this.rolepan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.ListBox Chat;
        private System.Windows.Forms.TextBox textBoxPing;
        private System.Windows.Forms.Panel chatpan;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Sendkey;
        private System.Windows.Forms.Panel rolepan;
        private System.Windows.Forms.Label role;
        private System.Windows.Forms.Label banw;
        private System.Windows.Forms.Timer danseclk;
        private System.Windows.Forms.Label ecrirelabel;
        private System.Windows.Forms.Label CHRONO;
        private System.Windows.Forms.Timer timerpartie;
    }
}

