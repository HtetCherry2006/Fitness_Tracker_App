using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fitness_Tracker
{
    public partial class Main_Form : Form
    {
        private User user;
        private const string ConnectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";
        private bool goalExists = false;

        public Main_Form(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            lblWelcome.Text = $"Welcome, {user.username}!";
            lblAge2.Text = user.age.ToString();
            label5.Text = $"{user.height} cm";
            label7.Text = $"{user.weight} kg";

            LoadGoalAndProgress();
        }

        private void LoadGoalAndProgress()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string goalQuery = @"
                        SELECT GoalType, TargetCalories, StartDate, EndDate 
                        FROM Goals 
                        WHERE Username = @Username 
                          AND CURDATE() BETWEEN StartDate AND EndDate
                        ORDER BY EndDate DESC 
                        LIMIT 1";

                    using (var goalCmd = new MySqlCommand(goalQuery, conn))
                    {
                        goalCmd.Parameters.AddWithValue("@Username", user.username);

                        using (var goalReader = goalCmd.ExecuteReader())
                        {
                            if (goalReader.Read())
                            {
                                goalExists = true;

                                string goalType = goalReader["GoalType"]?.ToString() ?? "Unknown";
                                float targetCalories = goalReader["TargetCalories"] != DBNull.Value
                                    ? Convert.ToSingle(goalReader["TargetCalories"])
                                    : 0f;

                                // Close reader before executing another command
                                goalReader.Close();

                                string calorieQuery = @"
                                    SELECT IFNULL(SUM(Calories), 0) AS TodayCalories 
                                    FROM Activity 
                                    WHERE Username = @Username 
                                      AND ActivityDate = CURDATE()";

                                using (var calorieCmd = new MySqlCommand(calorieQuery, conn))
                                {
                                    calorieCmd.Parameters.AddWithValue("@Username", user.username);
                                    object result = calorieCmd.ExecuteScalar();
                                    float todayCalories = result != DBNull.Value ? Convert.ToSingle(result) : 0f;

                                    float progressPercent = targetCalories == 0 ? 0 : (todayCalories / targetCalories) * 100f;
                                    int progressValue = Math.Min((int)progressPercent, 100);

                                    // Update UI
                                    lblCurrentGoal.Text = $"Goal: {goalType}";
                                    lblProgress.Text = $"Today's Progress: {todayCalories:F2} / {targetCalories:F2} kcal";
                                    progressBar1.Value = progressValue;
                                    btnSetGoal.Visible = false;

                                    if (progressValue >= 100)
                                    {
                                        MessageBox.Show("Congratulations! You hit your target calories goal!",
                                            "Goal Achieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        new GoodBye().Show();
                                    }
                                }
                            }
                            else
                            {
                                goalExists = false;
                                lblCurrentGoal.Text = "No goal set for today.";
                                lblProgress.Text = "No progress recorded.";
                                progressBar1.Value = 0;
                                btnSetGoal.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login_Form().Show();
        }

        private void btnaddactivity_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Add_Activity(user).Show();
        }

        private void btnSetGoal_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Set_Goal(user).Show();
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            if (!goalExists)
            {
                MessageBox.Show("You need to set a goal first.", "Goal Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            new View_Progress(user).Show();
        }
    }

    public class User
    {
        public string username { get; set; }
        public int age { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public string gender { get; set; }

        public User(string username, int age, float height, float weight, string gender)
        {
            this.username = username;
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.gender = gender;
        }
    }
}
