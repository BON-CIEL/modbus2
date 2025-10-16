using System;
using System.Windows.Forms;

namespace modbus
{
    public partial class Form1 : Form
    {
        // Déclaration de l'objet CModbus
        private CModbus modbus;

        public Form1()
        {
            InitializeComponent();
            // Création de l'objet CModbus
            modbus = new CModbus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void IPtextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Connexionbutton1_Click(object sender, EventArgs e)
        {
            string adresseIP = this.IPtextBox1.Text;
            this.AFFtextBox2.Text += "Connexion au serveur " + adresseIP + "\r\n";

            // Appel de la méthode Connexion de la classe CModbus
            string resultat = modbus.Connexion(adresseIP);

            if (resultat == "ok")
            {
                this.AFFtextBox2.Text += "Connexion ok\r\n";
            }
            else
            {
                this.AFFtextBox2.Text += "**Exception : Impossible de se connecter au serveur\r\n";
                this.AFFtextBox2.Text += "Message : " + resultat + "\r\n";
            }
        }

        private void Deconnexionbutton2_Click(object sender, EventArgs e)
        {
            // Appel de la méthode Deconnexion de la classe CModbus
            string resultat = modbus.Deconnexion();

            if (resultat == "ok")
            {
                this.AFFtextBox2.Text += "Déconnexion réussie\r\n";
            }
            else
            {
                this.AFFtextBox2.Text += "**Exception lors de la déconnexion\r\n";
                this.AFFtextBox2.Text += "Message : " + resultat + "\r\n";
            }
        }

        private void button1lire_Click(object sender, EventArgs e)
        {
            string strResultat = "";

            // Lecture de la tension à l'adresse 3207 avec la méthode LireUnMot
            Int16 valeurBrute = modbus.LireUnMot(3207, ref strResultat);

            if (strResultat == "ok")
            {
                // Calcul de la tension : valeur / 10
                double tension = valeurBrute / 10.0;

                // Affichage dans la textBox1
                this.textBox1.Text = String.Format("{0:F1}", tension);

                // Affichage dans la zone de statut
                this.AFFtextBox2.Text += String.Format("Tension: {0:F1} V\r\n", tension);
            }
            else
            {
                this.AFFtextBox2.Text += "**Exception lors de la lecture\r\n";
                this.AFFtextBox2.Text += "Message : " + strResultat + "\r\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AFFtextBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}


