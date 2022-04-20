using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace mvcTest.AOD
{
    public class ConnectionBD
    {
        private MySqlConnection con;

        public MySqlConnection getCon()
        {
            return con;
        }

        public ConnectionBD()
        {
            this.con = new MySqlConnection("server= localhost;user id=root;database=membre;");
        }
        public void openCon()
        {
            con.Open();
        }
        public void closeCon()
        {
            con.Close();
        }
        public void commandeSQL(String req)
        {
            MySqlCommand cmd = new MySqlCommand(req, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}