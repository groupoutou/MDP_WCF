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
            this.Historique.Size = new System.Drawing.Size(438, 420);
            this.Historique.TabIndex = 0;
            this.Historique.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // FormServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 420);
            this.Controls.Add(this.Historique);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormServeur";
            this.Text = "Serveur";
            this.Load += new System.EventHandler(this.FormServeur_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox Historique;

    }
}

