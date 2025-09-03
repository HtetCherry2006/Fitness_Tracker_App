using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Fitness_Tracker.Model
{
    internal class DataBaseConnection

    {
        public static MySqlConnection cn;

        public static MySqlConnection dataSource()
        {
            cn = new MySqlConnection("Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;");
            return cn;

        }
        public void cnOpen()
        {
            dataSource();
            cn.Open();
        }
        public void cnClose()
        {
            dataSource();
            cn.Close();
        }
        public void executeQury(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);


        }
        public MySqlDataReader dataReader(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public object showDataGridView(string query)
        {
            cnOpen();
            MySqlCommand cmd = new MySqlCommand(query, cn);
            cmd.Connection = DataBaseConnection.dataSource();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            BindingSource bindingSource = new BindingSource();
            return bindingSource.DataSource = dt;
        }
       
    }
}
