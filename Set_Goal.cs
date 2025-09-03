using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fitness_Tracker
{
    public partial class Set_Goal : Form
    {
        private User user;
        private readonly User _user;
        private const string ConnectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";

        public Set_Goal(User user)
        {
            InitializeComponent();
            _user = user;

            lblUsername.Text = _user.username;
            lblWeight.Text = _user.weight + " kg";

          
            comboBox1.SelectedIndex = 0;

            dateTimePicker_Start.Value = DateTime.Today;
            dateTimePicker_End.Value = DateTime.Today.AddDays(7);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate target weight
            if (!decimal.TryParse(textBox1.Text.Trim(), out decimal targetWeight) || targetWeight <= 0)
            {
                MessageBox.Show("Please enter a valid target weight.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            
            if (!int.TryParse(txtClaroiesBurn.Text.Trim(), out int targetCalories) || targetCalories <= 0)
            {
                MessageBox.Show("Please enter a valid target calories value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaroiesBurn.Focus();
                return;
            }

            DateTime start = dateTimePicker_Start.Value.Date;
            DateTime end = dateTimePicker_End.Value.Date;

            
            if (start >= end)
            {
                MessageBox.Show("Start date must be earlier than end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker_Start.Focus();
                return;
            }

            string goalType = comboBox1.Text;

            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO Goals
                        (Username, GoalType, TargetWeight, TargetCalories, StartDate, EndDate)
                        VALUES
                        (@Username, @GoalType, @TargetWeight, @TargetCalories, @StartDate, @EndDate)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", _user.username);
                        cmd.Parameters.AddWithValue("@GoalType", goalType);
                        cmd.Parameters.AddWithValue("@TargetWeight", targetWeight);
                        cmd.Parameters.AddWithValue("@TargetCalories", targetCalories);
                        cmd.Parameters.AddWithValue("@StartDate", start);
                        cmd.Parameters.AddWithValue("@EndDate", end);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Your goal has been set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                textBox1.Clear();
                txtClaroiesBurn.Clear();

                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form main_Form = new Main_Form(_user);
            main_Form.Show();

        }
    }
}
