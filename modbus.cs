using System;
using System.Net;           // pour IPEndPoint
using System.Net.Sockets;   // pour les sockets

namespace modbus
{
    
    class CModbus
    {
              private Socket socket; // Socket pour la communication TCP/IP

        public CModbus()
        {
            socket = null;
        }

      
        public String Connexion(String adresseIP)
        {
            try
            {
                // Création de la socket
                // - AddressFamily.InterNetwork : IPV4
                // - SocketType.Stream : mode connecté (TCP)
                // - ProtocolType.Tcp : protocole TCP
                socket = new Socket(AddressFamily.InterNetwork,
                                   SocketType.Stream,
                                   ProtocolType.Tcp);

                // Création du point d'accès distant (adresse IP + port)
                // Port Modbus TCP/IP : 502
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(adresseIP), 502);

                // Connexion au serveur
                socket.Connect(ipEndPoint);

                return "ok";
            }
            catch (System.Exception ex)
            {
                // Retourne le message d'erreur
                return ex.Message;
            }
        }

        
        public String Deconnexion()
        {
            try
            {
                // Vérification que la socket existe
                if (socket != null)
                {
                    // Fermeture de la socket
                    socket.Close();
                }

                return "ok";
            }
            catch (System.Exception ex)
            {
                // Retourne le message d'erreur
                return ex.Message;
            }
        }

       
        public Int16 LireUnMot(Int16 adresse, ref String strResultat)
        {
            try
            {
               
                // Attention : il faut soustraire 1 à l'adresse (décalage Modbus)
                Int16 adresseModbus = (Int16)(adresse + 0);

                // Conversion de l'adresse en 2 octets (Big Endian)
                byte adresseHaut = (byte)(adresseModbus >> 8);    // Octet de poids fort
                byte adresseBas = (byte)(adresseModbus & 0xFF);   // Octet de poids faible

                // Construction de la trame
                var trameE = new byte[]
                {
                    0x00, 0x00,      // Transaction Identifier
                    0x00, 0x00,      // Protocol Identifier (0 = Modbus)
                    0x00, 0x06,      // Length (6 octets suivent)
                    0x01,            // Unit Identifier (Device ID)
                    0x03,            // Function code (03 = Read Holding Registers)
                    adresseHaut,     // Adresse haute
                    adresseBas,      // Adresse basse
                    0x00, 0x01       // Nombre de registres à lire (1)
                };

                
                socket.Send(trameE);

                
                var trameR = new byte[256];
                int nbBytesLus = socket.Receive(trameR);

                // Vérification que la réponse est valide (au moins 11 octets)
                if (nbBytesLus < 11)
                {
                    strResultat = "Erreur : trame trop courte";
                    return 0;
                }

               
                // Structure de la réponse :
                // [0-1] Transaction ID
                // [2-3] Protocol ID
                // [4-5] Length
                // [6] Unit ID
                // [7] Function code
                // [8] Byte count
                // [9-10] Data (2 octets en Big Endian)

                byte octetPoidsFort = trameR[9];
                byte octetPoidsFaible = trameR[10];

                // Reconstitution de la valeur 16 bits
                Int16 valeur = (Int16)((octetPoidsFort << 8) | octetPoidsFaible);

                strResultat = "ok";
                return valeur;
            }
            catch (System.Exception ex)
            {
                // En cas d'erreur, retourne le message d'exception
                strResultat = ex.Message;
                return 0;
            }
        }

 
     
    }
}


