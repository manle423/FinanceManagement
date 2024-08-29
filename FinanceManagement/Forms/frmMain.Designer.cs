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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnRecurring = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnToCategory = new System.Windows.Forms.Button();
            this.btnToDashBoard = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lblMain);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 46);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMain.Location = new System.Drawing.Point(4, 5);
            this.lblMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(492, 33);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "Finance Management | Dashboard";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(1395, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 46);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.AutoSize = true;
            this.pnlControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlControl.Controls.Add(this.btnRecurring);
            this.pnlControl.Controls.Add(this.btnLogout);
            this.pnlControl.Controls.Add(this.btnToCategory);
            this.pnlControl.Controls.Add(this.btnToDashBoard);
            this.pnlControl.Location = new System.Drawing.Point(0, 45);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(231, 800);
            this.pnlControl.TabIndex = 4;
            // 
            // btnRecurring
            // 
            this.btnRecurring.Location = new System.Drawing.Point(0, 72);
            this.btnRecurring.Name = "btnRecurring";
            this.btnRecurring.Size = new System.Drawing.Size(225, 64);
            this.btnRecurring.TabIndex = 3;
            this.btnRecurring.Text = "RECURRING TRANSACTIONS";
            this.btnRecurring.UseVisualStyleBackColor = true;
            this.btnRecurring.Click += new System.EventHandler(this.btnRecurring_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(10, 737);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 46);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnToCategory
            // 
            this.btnToCategory.Location = new System.Drawing.Point(0, 329);
            this.btnToCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnToCategory.Name = "btnToCategory";
            this.btnToCategory.Size = new System.Drawing.Size(225, 69);
            this.btnToCategory.TabIndex = 1;
            this.btnToCategory.Text = "CATEGORY";
            this.btnToCategory.UseVisualStyleBackColor = true;
            this.btnToCategory.Click += new System.EventHandler(this.btnToCategory_Click);
            // 
            // btnToDashBoard
            // 
            this.btnToDashBoard.Location = new System.Drawing.Point(2, 191);
            this.btnToDashBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnToDashBoard.Name = "btnToDashBoard";
            this.btnToDashBoard.Size = new System.Drawing.Size(225, 69);
            this.btnToDashBoard.TabIndex = 0;
            this.btnToDashBoard.Text = "DASHBOARD";
            this.btnToDashBoard.UseVisualStyleBackColor = true;
            this.btnToDashBoard.Click += new System.EventHandler(this.btnToDashBoard_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(234, 45);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.TabIndex = 5;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 550);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnToCategory;
        private System.Windows.Forms.Button btnToDashBoard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRecurring;
    }
}