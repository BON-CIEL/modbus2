using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace modbus
{
    public partial class Form1 : Form
    {
        private Socket socket;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void IPtextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Connexionbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                string adresseIP = this.IPtextBox1.Text;
                this.AFFtextBox2.Text += "Connexion au serveur " + adresseIP + "\r\n";

                // Création de la socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Création de l'IPEndPoint (adresse IP + port Modbus 502)
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(adresseIP), 502);

                // Connexion au serveur
                socket.Connect(endPoint);

                this.AFFtextBox2.Text += "Connexion ok\r\n";
            }
            catch (SocketException se)
            {
                this.AFFtextBox2.Text += "**Exception : Impossible de se connecter au serveur\r\n";
                this.AFFtextBox2.Text += "Message : " + se.Message + "\r\n";
            }
            catch (Exception ex)
            {
                this.AFFtextBox2.Text += "**Exception : Impossible de se connecter au serveur\r\n";
                this.AFFtextBox2.Text += "Message : " + ex.Message + "\r\n";
            }
        }

        private void Deconnexionbutton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (socket != null)
                {
                    socket.Close();
                    this.AFFtextBox2.Text += "Déconnexion réussie\r\n";
                }
            }
            catch (Exception ex)
            {
                this.AFFtextBox2.Text += "**Exception lors de la déconnexion\r\n";
                this.AFFtextBox2.Text += "Message : " + ex.Message + "\r\n";
            }
        }

        private void AFFtextBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

