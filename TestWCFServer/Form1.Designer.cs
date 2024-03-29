namespace TestWCFServer
{
    partial class FormServeur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServeur));
            this.Historique = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Historique
            // 
            this.Historique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Historique.FormattingEnabled = true;
            this.Historique.ItemHeight = 20;
            this.Historique.Location = new System.Drawing.Point(0, 0);
            this.Historique.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Historique.Name = "Historique";
            this.Historique.Size = new System.Drawing.Size(359, 376);
            this.Historique.TabIndex = 0;
            this.Historique.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // FormServeur
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(359, 376);
            this.Controls.Add(this.Historique);
            this.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(252, 74);
            this.Name = "FormServeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serveur";
            this.Load += new System.EventHandler(this.FormServeur_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox Historique;

    }
}

