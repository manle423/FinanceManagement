namespace FinanceManagement
{
    partial class frmMain
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
            this.lblMain = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabCtrlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lblMain);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 30);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMain.Location = new System.Drawing.Point(3, 3);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(302, 23);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "Finance Management | Dashboard";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(767, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tabDashboard);
            this.tabCtrlMain.Controls.Add(this.tabCategory);
            this.tabCtrlMain.Location = new System.Drawing.Point(0, 30);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(811, 421);
            this.tabCtrlMain.TabIndex = 4;
            this.tabCtrlMain.SelectedIndexChanged += new System.EventHandler(this.tabCtrlMain_SelectedIndexChanged);
            // 
            // tabDashboard
            // 
            this.tabDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(803, 395);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            this.tabDashboard.Click += new System.EventHandler(this.tabDashboard_Click);
            // 
            // tabCategory
            // 
            this.tabCategory.Location = new System.Drawing.Point(4, 22);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategory.Size = new System.Drawing.Size(803, 395);
            this.tabCategory.TabIndex = 1;
            this.tabCategory.Text = "Category";
            this.tabCategory.UseVisualStyleBackColor = true;
            this.tabCategory.Click += new System.EventHandler(this.tabCategory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabCtrlMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabCtrlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabCategory;
    }
}