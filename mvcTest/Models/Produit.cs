using mvcTest.AOD;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcTest.Models
{
    public class Produit
    {
        public List<Produit> produit;
        public string nom { get; set; }
        public string category { get; set; }
        public double prix { get; set; }
        public int id { get; set; }
        public ConnectionBD db { get; set; }

        public Produit()
        {
            produit = new List<Produit>();
            db = new ConnectionBD();
        }
        public Produit(string nom, string category, double prix, int id)
        {
            this.nom = nom;
            this.category = category;
            this.prix = prix;
            this.id = id;
            produit = new List<Produit>();
            db = new ConnectionBD();
        }

        public List<Produit> getProduit(string table, string value)
        {
            db.openCon();
            List<Produit> list = new List<Produit>();
            string rqt = "SELECT " + value + " FROM " + table;
            MySqlCommand cmd = new MySqlCommand(rqt, db.getCon());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Produit(reader["nomItem"].ToString(), 
                    reader["categoryItem"].ToString(), 
                    double.Parse(reader["prixItem"].ToString()),
                    int.Parse(reader["idProduits"].ToString())));
            }
            db.closeCon();
            return list;
        }

        public List<Produit> afficheProduit()
        {
            return this.getProduit("`produititems`", "`nomItem`, `categoryItem`, `prixItem`, `idProduits`");
        }
    }
}