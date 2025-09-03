using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class Add_Activity : Form
    {
        private User _user;
        private const string ConnectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";

        public Add_Activity(User user)
        {
            InitializeComponent();
            _user = user;
            lblUsername.Text = _user.username;

            comboBox1.Items.AddRange(new string[] { "Walking", "Running", "Cycling", "Swimming", "Weightlifting", "Yoga" });
            comboBox1.SelectedIndexChanged += cbActivityType_SelectedIndexChanged;

            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today;

            
            textBox2.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        private void cbActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMerit.Items.Clear();

            string activity = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(activity)) return;

            if (activity == "Walking")
                cboMerit.Items.AddRange(new[] { "Slow", "Normal", "Fast" });
            else if (activity == "Running")
                cboMerit.Items.AddRange(new[] { "Jogging", "Medium", "Sprint" });
            else if (activity == "Cycling")
                cboMerit.Items.AddRange(new[] { "Leisure", "Normal", "Intense" });
            else if (activity == "Swimming")
                cboMerit.Items.AddRange(new[] { "Leisure", "Moderate", "Vigorous" });
            else if (activity == "Weightlifting")
                cboMerit.Items.AddRange(new[] { "Light", "Moderate", "Vigorous" });
            else if (activity == "Yoga")
                cboMerit.Items.AddRange(new[] { "Gentle", "Power" });

            if (cboMerit.Items.Count > 0) cboMerit.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string activityType = comboBox1.SelectedItem?.ToString();
            string meritType = cboMerit.SelectedItem?.ToString();
            string timeStr = textBox2.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(activityType) || string.IsNullOrEmpty(meritType) || !int.TryParse(timeStr, out int timeSpent))
            {
                MessageBox.Show("Please complete all fields with valid input.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Time is between 10 and 60
            if (timeSpent < 10 || timeSpent > 60)
            {
                MessageBox.Show("Time spent must be between 10 and 60 minutes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = dateTimePicker1.Value.Date;

            if (selectedDate != DateTime.Today)
            {
                MessageBox.Show("You can only add activities for today.", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float caloriesBurned = CalculateCalories(activityType, meritType, _user.weight, timeSpent);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    float totalCalories = 0f;
                    float targetCalories = 0f;

                    string totalSql = "SELECT SUM(Calories) FROM Activity WHERE Username = @Username AND ActivityDate = @Date";
                    using (MySqlCommand totalCmd = new MySqlCommand(totalSql, conn))
                    {
                        totalCmd.Parameters.AddWithValue("@Username", _user.username);
                        totalCmd.Parameters.AddWithValue("@Date", selectedDate);
                        object result = totalCmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                            totalCalories = Convert.ToSingle(result);
                    }

                    string goalSql = "SELECT TargetCalories FROM Goals WHERE Username = @Username";
                    using (MySqlCommand goalCmd = new MySqlCommand(goalSql, conn))
                    {
                        goalCmd.Parameters.AddWithValue("@Username", _user.username);
                        object targetResult = goalCmd.ExecuteScalar();
                        if (targetResult != DBNull.Value && targetResult != null)
                            targetCalories = Convert.ToSingle(targetResult);
                    }

                    if (totalCalories >= targetCalories && targetCalories > 0)
                    {
                        MessageBox.Show("You already reached your calorie goal for today. No more activities allowed.", "Goal Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string insertSql = @"INSERT INTO Activity 
                                        (Username, ActivityType, MeritType, TimeSpent, Calories, ActivityDate) 
                                        VALUES 
                                        (@Username, @ActivityType, @MeritType, @TimeSpent, @Calories, @ActivityDate)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", _user.username);
                        insertCmd.Parameters.AddWithValue("@ActivityType", activityType);
                        insertCmd.Parameters.AddWithValue("@MeritType", meritType);
                        insertCmd.Parameters.AddWithValue("@TimeSpent", timeSpent);
                        insertCmd.Parameters.AddWithValue("@Calories", caloriesBurned);
                        insertCmd.Parameters.AddWithValue("@ActivityDate", selectedDate);
                        insertCmd.ExecuteNonQuery();
                    }

                    // Reset fields
                    comboBox1.SelectedItem = null;
                    cboMerit.Items.Clear();
                    textBox2.Clear();
                    dateTimePicker1.Value = DateTime.Today;

                    MessageBox.Show($"Activity recorded. Calories burned: {caloriesBurned:F2} kcal", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    totalCalories += caloriesBurned;
                    if (targetCalories > 0 && totalCalories >= targetCalories)
                    {
                        MessageBox.Show("Goal Achieved! You hit your calorie target for today.", "Goal Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private float CalculateCalories(string activity, string merit, float weight, int time)
        {
            float met = 1.0f;

            if (activity == "Walking")
            {
                if (merit == "Slow") met = 2.5f;
                else if (merit == "Normal") met = 3.5f;
                else if (merit == "Fast") met = 4.5f;

                return (met * weight * time) / 60f;
            }
            else if (activity == "Running")
            {
                if (merit == "Jogging") met = 6.0f;
                else if (merit == "Medium") met = 7.5f;
                else if (merit == "Sprint") met = 9.0f;

                return (met * weight * time * 1.1f) / 60f;
            }
            else if (activity == "Cycling")
            {
                if (merit == "Leisure") met = 3.5f;
                else if (merit == "Normal") met = 5.0f;
                else if (merit == "Intense") met = 7.0f;

                return (met * weight * time * 0.95f) / 60f;
            }
            else if (activity == "Swimming")
            {
                if (merit == "Leisure") met = 3.0f;
                else if (merit == "Moderate") met = 5.5f;
                else if (merit == "Vigorous") met = 7.0f;

                return (met * weight * time * 1.2f) / 60f;
            }
            else if (activity == "Weightlifting")
            {
                if (merit == "Light") met = 3.0f;
                else if (merit == "Moderate") met = 5.0f;
                else if (merit == "Vigorous") met = 6.0f;

                return (met * weight * time * 0.9f) / 60f;
            }
            else if (activity == "Yoga")
            {
                if (merit == "Gentle") met = 2.0f;
                else if (merit == "Power") met = 4.0f;

                return (met * weight * time * 0.85f) / 60f;
            }

            return 0f;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form main_Form = new Main_Form(_user);
            main_Form.Show();
        }
    }
}

