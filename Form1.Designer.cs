namespace modbus
{
    partial class Form1
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
            this.Connexionbutton1 = new System.Windows.Forms.Button();
            this.Deconnexionbutton2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IPtextBox1 = new System.Windows.Forms.TextBox();
            this.AFFtextBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Connexionbutton1
            // 
            this.Connexionbutton1.Location = new System.Drawing.Point(237, 26);
            this.Connexionbutton1.Name = "Connexionbutton1";
            this.Connexionbutton1.Size = new System.Drawing.Size(75, 23);
            this.Connexionbutton1.TabIndex = 0;
            this.Connexionbutton1.Text = "Connexion";
            this.Connexionbutton1.UseVisualStyleBackColor = true;
            this.Connexionbutton1.Click += new System.EventHandler(this.Connexionbutton1_Click);
            // 
            // Deconnexionbutton2
            // 
            this.Deconnexionbutton2.Location = new System.Drawing.Point(340, 26);
            this.Deconnexionbutton2.Name = "Deconnexionbutton2";
            this.Deconnexionbutton2.Size = new System.Drawing.Size(101, 23);
            this.Deconnexionbutton2.TabIndex = 1;
            this.Deconnexionbutton2.Text = "Deconnexion";
            this.Deconnexionbutton2.UseVisualStyleBackColor = true;
            this.Deconnexionbutton2.Click += new System.EventHandler(this.Deconnexionbutton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ip serveur";
            // 
            // IPtextBox1
            // 
            this.IPtextBox1.Location = new System.Drawing.Point(95, 26);
            this.IPtextBox1.Name = "IPtextBox1";
            this.IPtextBox1.Size = new System.Drawing.Size(100, 20);
            this.IPtextBox1.TabIndex = 3;
            this.IPtextBox1.TextChanged += new System.EventHandler(this.IPtextBox1_TextChanged);
            // 
            // AFFtextBox2
            // 
            this.AFFtextBox2.Location = new System.Drawing.Point(484, 24);
            this.AFFtextBox2.Multiline = true;
            this.AFFtextBox2.Name = "AFFtextBox2";
            this.AFFtextBox2.Size = new System.Drawing.Size(253, 341);
            this.AFFtextBox2.TabIndex = 4;
            this.AFFtextBox2.TextChanged += new System.EventHandler(this.AFFtextBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AFFtextBox2);
            this.Controls.Add(this.IPtextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Deconnexionbutton2);
            this.Controls.Add(this.Connexionbutton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connexionbutton1;
        private System.Windows.Forms.Button Deconnexionbutton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPtextBox1;
        private System.Windows.Forms.TextBox AFFtextBox2;
    }
}

