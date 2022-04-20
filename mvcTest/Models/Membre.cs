using mvcTest.AOD;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Windows.Forms;

namespace mvcTest.Models
{
    public class Membre
    {
        ConnectionBD db;

        public Membre()
        {
            db = new ConnectionBD();
        }

        public void addMembre(string table, string value)
        {
            db.openCon();
            string rqt = "INSERT INTO `" + table + "`" + value;
            db.commandeSQL(rqt);
            db.closeCon();
        }

        public void sendMail(String email, string message)
        {
            MailMessage mail = new MailMessage("simplice2236@gmail.com", email, "Facture", "<!DOCTYPE html><html><style>table, tr, th, td {border:1px solid black;}</style><body><table><tr><th>Produit</th><th>Categorie</th><th>Quantite</th><th>prix(Ar)</th><th>pharmacie</th></tr>" + message + "</table><br/></body></html>");
            mail.IsBodyHtml = true;
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("simplice2236@gmail.com", "0348664121"),
                EnableSsl = true
            };

            try
            {
                client.Send(mail);
            }
            catch
            {
                throw;
            }
        }

        public List<string> login(string table, string value, string cle)
        {
            db.openCon();
            List<String> list = new List<String>();
            string rqt = "SELECT " + value + " FROM " + table + " WHERE " + cle;
            db.commandeSQL(rqt);
            MySqlCommand cmd = new MySqlCommand(rqt, db.getCon());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["nomStag"].ToString());
                list.Add(reader["prenomStag"].ToString());
                list.Add(reader["emailStag"].ToString());
                list.Add(reader["mdpStag"].ToString());
            }
            db.closeCon();
            return list;
        }
    }
}