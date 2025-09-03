using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Fitness_Tracker.Model
{
    public class User
    {
        private string Username;
        private int Age;
        private float Height;
        private float Weight;
        private string Gender;

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }
        public int age
        {
            get { return Age; }
            set { Age= value; }
        }
        public float height
        {
            get { return Height; }
            set { Height = value; }
        }
        public float weight
        {
            get { return Weight; }
            set { Weight= value; }
            
        }
        public string gender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public User(string username, int age, float height, float weight, string gender)
        {
            Username = username;
            Age = age;
            Height = height;
            Weight = weight;
            Gender = gender;
        }
    }


}

