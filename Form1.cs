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

        private void button1lire_Click(object sender, EventArgs e)
        {
            try
            {
                // Trame Modbus TCP pour lire l'adresse 3207 (fonction 03 - Read Holding Registers)
                // Structure de la trame:
                // - Transaction ID: 0x0000 (2 octets)
                // - Protocol ID: 0x0000 (2 octets) - Modbus
                // - Length: 0x0006 (2 octets) - 6 octets suivent
                // - Unit ID: 0x01 (1 octet) - Device ID
                // - Function: 0x03 (1 octet) - Read Holding Registers
                // - Start Address: 0x0C86 (2 octets) - Adresse 3206 (3207-1 car décalage Modbus)
                // - Quantity: 0x0001 (2 octets) - Lire 1 registre (2 octets)

                var trameE = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x0C, 0x86, 0x00, 0x01 };

                // Envoi de la trame
                socket.Send(trameE);

                // Réception de la réponse
                var trameR = new byte[256];
                int nbOctets = socket.Receive(trameR);

                // Affichage de la trame reçue en hexadécimal
                this.AFFtextBox2.Text += "Trame reçue (" + nbOctets + " octets): ";
                for (int i = 0; i < nbOctets; i++)
                {
                    this.AFFtextBox2.Text += String.Format("{0:X2} ", trameR[i]);
                }
                this.AFFtextBox2.Text += "\r\n";

                // Extraction de la valeur (octets 9 et 10 de la trame)
                // La valeur est en Big Endian (octet de poids fort en premier)
                int valeurBrute = (trameR[9] << 8) | trameR[10];

                // Calcul de la tension : valeur / 10 (selon la documentation)
                double tension = valeurBrute / 10.0;

                // Affichage dans la textBox1 (textBox pour afficher la tension)
                this.textBox1.Text = String.Format("{0:F1}", tension);

                this.AFFtextBox2.Text += String.Format("Valeur brute: {0} => Tension: {1:F1} V\r\n", valeurBrute, tension);
            }
            catch (Exception ex)
            {
                this.AFFtextBox2.Text += "**Exception lors de la lecture\r\n";
                this.AFFtextBox2.Text += "Message : " + ex.Message + "\r\n";
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


