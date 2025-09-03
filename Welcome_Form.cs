using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 10;  
            lblLoadingPercentage.Text = progressBar1.Value + " %";


            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                Login_Form login = new Login_Form();
                login.Show();
                this.Hide();
            }
        }
    }
}
