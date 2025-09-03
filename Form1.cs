using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fitness_Tracker
{
    public partial class Login_Form : Form
    {
        private const string ConnectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";
        private int failedAttempts = 0;

        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    try
                    {
                        connection.Open();

                    // SQL query to check if the username and password match
                    string query = "SELECT username, age, height, weight, gender FROM Users WHERE username = @Username AND password = @Password";


                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Fetch user data
                                    string currentUsername = reader["username"].ToString();
                                    int age = Convert.ToInt32(reader["age"]);
                                    float height = Convert.ToSingle(reader["height"]);
                                    float weight = Convert.ToSingle(reader["weight"]);
                                    string gender = reader["gender"].ToString();
                                    User user = new User(currentUsername, age, height, weight, gender);






                                // Show the success message
                                MessageBox.Show($"Welcome back, {user.username}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    ClearTextBoxes();
                                    this.Hide();

                                // Pass the User object to the Main Form
                                Main_Form mainForm = new Main_Form(user);  // this is correct
                                mainForm.Show();

                            }
                            else
                                {
                                    failedAttempts++;
                                    MessageBox.Show("You don't have an account yet !!! Please Register First.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ClearTextBoxes();

                                    // After 3 failed attempts, redirect to Register Form
                                    if (failedAttempts >= 3)
                                    {
                                        MessageBox.Show("Too many failed login attempts. Redirecting to registration.", "Login Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        this.Hide();
                                        Register_Form registerForm = new Register_Form();
                                        registerForm.Show();
                                    }
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
       
            private void ClearTextBoxes()
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                 this.Hide();
                Register_Form register =new  Register_Form();
                register.Show();
            
        }
    }
    }


