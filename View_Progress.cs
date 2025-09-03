using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class View_Progress : Form
    {
        private readonly User _user;
        private const string ConnectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";

        public View_Progress(User user)
        {
            _user = user;
            InitializeComponent();
            lblUsername.Text = _user.username;
            LoadProgressData();
        }

        private void LoadProgressData()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT g.GoalType, g.TargetCalories, g.TargetWeight, g.StartDate, g.EndDate,
                               u.Weight AS CurrentWeight,
                               (SELECT IFNULL(SUM(a.Calories), 0)
                                FROM Activity a
                                WHERE a.Username = g.Username
                                  AND a.ActivityDate BETWEEN g.StartDate AND g.EndDate) AS CaloriesBurned
                        FROM Goals g
                        JOIN Users u ON u.Username = g.Username
                        WHERE g.Username = @Username
                        ORDER BY g.EndDate DESC
                        LIMIT 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", _user.username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string goal = reader["GoalType"].ToString();
                                float targetCalories = Convert.ToSingle(reader["TargetCalories"]);
                                float burnedCalories = Convert.ToSingle(reader["CaloriesBurned"]);
                                float targetWeight = Convert.ToSingle(reader["TargetWeight"]);
                                float currentWeight = Convert.ToSingle(reader["CurrentWeight"]);
                                DateTime startDate = Convert.ToDateTime(reader["StartDate"]);
                                DateTime endDate = Convert.ToDateTime(reader["EndDate"]);

                                int totalDays = (endDate - startDate).Days;
                                int daysLeft = Math.Max(0, (endDate - DateTime.Today).Days);
                                float weightLeft = currentWeight - targetWeight;

                                float progressPercent = targetCalories > 0
                                    ? (burnedCalories >= targetCalories ? 100f : (burnedCalories / targetCalories) * 100f)
                                    : 0f;

                                // Update UI Labels
                                lblGoal.Text = goal;
                                lblCalories.Text = targetCalories.ToString("F2");
                                lblBurn.Text = burnedCalories.ToString("F2");
                                lblRemain.Text = daysLeft.ToString();
                                lbltime.Text = totalDays.ToString();
                                lblPercentage.Text = progressPercent.ToString("F1") + "%";
                                lblweighttarget.Text = targetWeight.ToString("F2");
                                lblWeight.Text = currentWeight.ToString("F2");
                                lblRemin.Text = weightLeft.ToString("F2");

                                progressBar1.Value = (int)Math.Min(100, progressPercent);
                            }
                            else
                            {
                                MessageBox.Show("No goal data found for this user.", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading progress: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main_Form(_user).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProgressData();
        }
    }
}

