namespace JobPortalSystemProject.Forms
{
    partial class MainDashBoard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAllUser = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalusers = new System.Windows.Forms.Label();
            this.pnlAppliedJobs = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAppliedJob = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalJobs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowJobs = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.pnlAllUser.SuspendLayout();
            this.pnlAppliedJobs.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlAllUser);
            this.panel1.Controls.Add(this.pnlAppliedJobs);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 340);
            this.panel1.TabIndex = 5;
            // 
            // pnlAllUser
            // 
            this.pnlAllUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.pnlAllUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAllUser.Controls.Add(this.label4);
            this.pnlAllUser.Controls.Add(this.lblTotalusers);
            this.pnlAllUser.Location = new System.Drawing.Point(527, 50);
            this.pnlAllUser.Name = "pnlAllUser";
            this.pnlAllUser.Size = new System.Drawing.Size(195, 132);
            this.pnlAllUser.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(15, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Users";
            // 
            // lblTotalusers
            // 
            this.lblTotalusers.AutoSize = true;
            this.lblTotalusers.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalusers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(35)))), ((int)(((byte)(24)))));
            this.lblTotalusers.Location = new System.Drawing.Point(52, 15);
            this.lblTotalusers.Name = "lblTotalusers";
            this.lblTotalusers.Size = new System.Drawing.Size(56, 45);
            this.lblTotalusers.TabIndex = 0;
            this.lblTotalusers.Text = "12";
            // 
            // pnlAppliedJobs
            // 
            this.pnlAppliedJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.pnlAppliedJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAppliedJobs.Controls.Add(this.label3);
            this.pnlAppliedJobs.Controls.Add(this.lblAppliedJob);
            this.pnlAppliedJobs.Location = new System.Drawing.Point(531, 46);
            this.pnlAppliedJobs.Name = "pnlAppliedJobs";
            this.pnlAppliedJobs.Size = new System.Drawing.Size(195, 132);
            this.pnlAppliedJobs.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Applied  Jobs";
            // 
            // lblAppliedJob
            // 
            this.lblAppliedJob.AutoSize = true;
            this.lblAppliedJob.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(35)))), ((int)(((byte)(24)))));
            this.lblAppliedJob.Location = new System.Drawing.Point(52, 15);
            this.lblAppliedJob.Name = "lblAppliedJob";
            this.lblAppliedJob.Size = new System.Drawing.Size(56, 45);
            this.lblAppliedJob.TabIndex = 0;
            this.lblAppliedJob.Text = "12";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTotalJobs);
            this.panel2.Location = new System.Drawing.Point(160, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 132);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(17, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Jobs";
            // 
            // lblTotalJobs
            // 
            this.lblTotalJobs.AutoSize = true;
            this.lblTotalJobs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJobs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(35)))), ((int)(((byte)(24)))));
            this.lblTotalJobs.Location = new System.Drawing.Point(52, 15);
            this.lblTotalJobs.Name = "lblTotalJobs";
            this.lblTotalJobs.Size = new System.Drawing.Size(56, 45);
            this.lblTotalJobs.TabIndex = 0;
            this.lblTotalJobs.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(45, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 60);
            this.label2.TabIndex = 6;
            this.label2.Text = "Recomended Jobs:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowJobs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 340);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1190, 315);
            this.panel3.TabIndex = 6;
            // 
            // flowJobs
            // 
            this.flowJobs.AutoScroll = true;
            this.flowJobs.BackColor = System.Drawing.Color.Transparent;
            this.flowJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowJobs.Location = new System.Drawing.Point(0, 0);
            this.flowJobs.Name = "flowJobs";
            this.flowJobs.Size = new System.Drawing.Size(1190, 315);
            this.flowJobs.TabIndex = 5;
            // 
            // MainDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 655);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainDashBoard";
            this.Text = "MainDashBoard";
            this.Load += new System.EventHandler(this.MainDashBoard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAllUser.ResumeLayout(false);
            this.pnlAllUser.PerformLayout();
            this.pnlAppliedJobs.ResumeLayout(false);
            this.pnlAppliedJobs.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAllUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalusers;
        private System.Windows.Forms.Panel pnlAppliedJobs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAppliedJob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalJobs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowJobs;
    }
}