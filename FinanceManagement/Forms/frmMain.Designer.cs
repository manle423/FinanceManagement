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
            this.btnToTransactions = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnToCategory = new System.Windows.Forms.Button();
            this.btnToDashBoard = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 30);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMain.Location = new System.Drawing.Point(3, 3);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(331, 24);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "Finance Management | Dashboard";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(930, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.AutoSize = true;
            this.pnlControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlControl.Controls.Add(this.button1);
            this.pnlControl.Controls.Add(this.btnToTransactions);
            this.pnlControl.Controls.Add(this.btnLogout);
            this.pnlControl.Controls.Add(this.btnToCategory);
            this.pnlControl.Controls.Add(this.btnToDashBoard);
            this.pnlControl.Location = new System.Drawing.Point(0, 29);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(154, 520);
            this.pnlControl.TabIndex = 4;
            // 
            // btnToTransactions
            // 
            this.btnToTransactions.Location = new System.Drawing.Point(0, 307);
            this.btnToTransactions.Name = "btnToTransactions";
            this.btnToTransactions.Size = new System.Drawing.Size(150, 45);
            this.btnToTransactions.TabIndex = 3;
            this.btnToTransactions.Text = "TRANSACTIONS";
            this.btnToTransactions.UseVisualStyleBackColor = true;
            this.btnToTransactions.Click += new System.EventHandler(this.btnToTransactions_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(7, 479);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(104, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnToCategory
            // 
            this.btnToCategory.Location = new System.Drawing.Point(0, 214);
            this.btnToCategory.Name = "btnToCategory";
            this.btnToCategory.Size = new System.Drawing.Size(150, 45);
            this.btnToCategory.TabIndex = 1;
            this.btnToCategory.Text = "CATEGORY";
            this.btnToCategory.UseVisualStyleBackColor = true;
            this.btnToCategory.Click += new System.EventHandler(this.btnToCategory_Click);
            // 
            // btnToDashBoard
            // 
            this.btnToDashBoard.Location = new System.Drawing.Point(1, 124);
            this.btnToDashBoard.Name = "btnToDashBoard";
            this.btnToDashBoard.Size = new System.Drawing.Size(150, 45);
            this.btnToDashBoard.TabIndex = 0;
            this.btnToDashBoard.Text = "DASHBOARD";
            this.btnToDashBoard.UseVisualStyleBackColor = true;
            this.btnToDashBoard.Click += new System.EventHandler(this.btnToDashBoard_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(156, 29);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 520);
            this.pnlContent.TabIndex = 5;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "GOALS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 550);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnToTransactions;
        private System.Windows.Forms.Button button1;
    }
}