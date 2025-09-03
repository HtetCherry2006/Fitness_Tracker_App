using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fitness_Tracker
{
    public partial class Register_Form : Form
    {
        public Register_Form()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string gender = cboGender.SelectedItem?.ToString();
            string ageText = txtAge.Text;
            string weightText = txtweight.Text;
            string heightText = txtheight.Text;

            string usernamePattern = "^[a-zA-Z0-9]*$";
            string passwordPattern = "^(?=.*[a-z])(?=.*[A-Z]).{12}$";
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(ageText) ||
                string.IsNullOrWhiteSpace(weightText) || string.IsNullOrWhiteSpace(heightText))
            {
                errorMessage += "Please fill in all required fields.\n";
            }

            if (!Regex.IsMatch(username, usernamePattern))
            {
                errorMessage += "Username must contain only letters and numbers.\n";
            }

            if (!Regex.IsMatch(password, passwordPattern))
            {
                errorMessage += "Password must be 12 characters, contain at least one uppercase and one lowercase letter.\n";
            }

            if (password != confirmPassword)
            {
                errorMessage += "Password and Confirm Password do not match.\n";
            }

            if (!Regex.IsMatch(email, emailPattern))
            {
                errorMessage += "Please enter a valid email address.\n";
            }

            if (!string.IsNullOrEmpty(ageText) && !int.TryParse(ageText, out int ageValue))
            {
                errorMessage += "Please enter a valid numeric value for Age.\n";
            }
            else if (int.TryParse(ageText, out ageValue))
            {
                if (ageValue < 13 || ageValue > 65)
                {
                    errorMessage += "Age must be between 13 and 65.\n";
                }
            }

            if (!string.IsNullOrEmpty(weightText) && !decimal.TryParse(weightText, out decimal weightValue))
            {
                errorMessage += "Please enter a valid numeric value for Weight.\n";
            }
            else if (decimal.TryParse(weightText, out weightValue) && weightValue > 90)
            {
                errorMessage += "Weight cannot be above 90kg.\n";
            }

            if (!string.IsNullOrEmpty(heightText) && !decimal.TryParse(heightText, out decimal heightValue))
            {
                errorMessage += "Please enter a valid numeric value for Height.\n";
            }
            else if (decimal.TryParse(heightText, out heightValue))
            {
                if (gender.ToLower() == "female" && heightValue > 180)
                {
                    errorMessage += "For females, height cannot be above 180.\n";
                }
                else if (gender.ToLower() == "male" && heightValue > 210)
                {
                    errorMessage += "For males, height cannot be above 210.\n";
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? age = string.IsNullOrWhiteSpace(ageText) ? (int?)null : int.Parse(ageText);
                decimal? weight = string.IsNullOrWhiteSpace(weightText) ? (decimal?)null : decimal.Parse(weightText);
                decimal? height = string.IsNullOrWhiteSpace(heightText) ? (decimal?)null : decimal.Parse(heightText);

                string connectionString = "Server=localhost;Database=fitness_tracker;Uid=root;Pwd=root;";
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    // Check if username exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE Username = @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, cn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO users (Username, Password, Email, Age, Gender, Weight, Height) " +
                                         "VALUES (@Username, @Password, @Email, @Age, @Gender, @Weight, @Height)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, cn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Age", (object)age ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@Weight", (object)weight ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@Height", (object)height ?? DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Welcome to Fitness Tracker, {username}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Login_Form().Show();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Age, Weight, and Height.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.Show();
        }
        private void chkShow_CheckedChanged(object sender, EventArgs e)

        {

            if (chkShow.Checked == true)

            {

                txtPassword.UseSystemPasswordChar = true;

            }

            else

            {

                txtPassword.UseSystemPasswordChar = false;



            }

        }



        private void chkShow1_CheckedChanged(object sender, EventArgs e)

        {

            if (chkShow1.Checked == true)

            {

                txtConfirmPassword.UseSystemPasswordChar = true;

            }

            else

            {

                txtConfirmPassword.UseSystemPasswordChar = false;



            }

        }

        }
    }