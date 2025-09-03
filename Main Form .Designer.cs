namespace Fitness_Tracker
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnlogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblAge2 = new System.Windows.Forms.Label();
            this.btnaddactivity = new System.Windows.Forms.Button();
            this.btnSetGoal = new System.Windows.Forms.Button();
            this.btnViewProgress = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblCurrentGoal = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnlogout.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(413, 0);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(119, 33);
            this.btnlogout.TabIndex = 2;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(13, 3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(155, 36);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome ,";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(19, 54);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(45, 19);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Age :";
            // 
            // lblAge2
            // 
            this.lblAge2.AutoSize = true;
            this.lblAge2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge2.Location = new System.Drawing.Point(79, 54);
            this.lblAge2.Name = "lblAge2";
            this.lblAge2.Size = new System.Drawing.Size(0, 19);
            this.lblAge2.TabIndex = 5;
            // 
            // btnaddactivity
            // 
            this.btnaddactivity.BackColor = System.Drawing.Color.Lime;
            this.btnaddactivity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddactivity.ForeColor = System.Drawing.Color.White;
            this.btnaddactivity.Location = new System.Drawing.Point(39, 95);
            this.btnaddactivity.Name = "btnaddactivity";
            this.btnaddactivity.Size = new System.Drawing.Size(106, 35);
            this.btnaddactivity.TabIndex = 6;
            this.btnaddactivity.Text = "Add Activity";
            this.btnaddactivity.UseVisualStyleBackColor = false;
            this.btnaddactivity.Click += new System.EventHandler(this.btnaddactivity_Click);
            // 
            // btnSetGoal
            // 
            this.btnSetGoal.BackColor = System.Drawing.Color.Lime;
            this.btnSetGoal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGoal.ForeColor = System.Drawing.Color.White;
            this.btnSetGoal.Location = new System.Drawing.Point(216, 94);
            this.btnSetGoal.Name = "btnSetGoal";
            this.btnSetGoal.Size = new System.Drawing.Size(119, 36);
            this.btnSetGoal.TabIndex = 7;
            this.btnSetGoal.Text = "Set Goal";
            this.btnSetGoal.UseVisualStyleBackColor = false;
            this.btnSetGoal.Click += new System.EventHandler(this.btnSetGoal_Click);
            // 
            // btnViewProgress
            // 
            this.btnViewProgress.BackColor = System.Drawing.Color.Lime;
            this.btnViewProgress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProgress.ForeColor = System.Drawing.Color.White;
            this.btnViewProgress.Location = new System.Drawing.Point(378, 95);
            this.btnViewProgress.Name = "btnViewProgress";
            this.btnViewProgress.Size = new System.Drawing.Size(128, 36);
            this.btnViewProgress.TabIndex = 8;
            this.btnViewProgress.Text = "View Progress";
            this.btnViewProgress.UseVisualStyleBackColor = false;
            this.btnViewProgress.Click += new System.EventHandler(this.btnViewProgress_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.lblProgress);
            this.panel2.Controls.Add(this.lblCurrentGoal);
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 147);
            this.panel2.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(55, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(176, 115);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 19);
            this.lblProgress.TabIndex = 3;
            // 
            // lblCurrentGoal
            // 
            this.lblCurrentGoal.AutoSize = true;
            this.lblCurrentGoal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGoal.Location = new System.Drawing.Point(200, 27);
            this.lblCurrentGoal.Name = "lblCurrentGoal";
            this.lblCurrentGoal.Size = new System.Drawing.Size(0, 22);
            this.lblCurrentGoal.TabIndex = 1;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(29, 330);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(74, 22);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "Height :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(123, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 11;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(276, 330);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(78, 22);
            this.lblWeight.TabIndex = 12;
            this.lblWeight.Text = "Weight :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 22);
            this.label7.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblHeight);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnViewProgress);
            this.panel1.Controls.Add(this.btnSetGoal);
            this.panel1.Controls.Add(this.btnaddactivity);
            this.panel1.Controls.Add(this.lblAge2);
            this.panel1.Controls.Add(this.lblAge);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Location = new System.Drawing.Point(34, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 378);
            this.panel1.TabIndex = 0;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(627, 493);
            this.Controls.Add(this.panel1);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblAge2;
        private System.Windows.Forms.Button btnaddactivity;
        private System.Windows.Forms.Button btnSetGoal;
        private System.Windows.Forms.Button btnViewProgress;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblCurrentGoal;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
    }
}