namespace FinanceManagement.Forms.Goal
{
    partial class frmGoalManagement
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
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtCurrentAmountUpdate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDeadlineUpdate = new System.Windows.Forms.DateTimePicker();
            this.dgvGoals = new System.Windows.Forms.DataGridView();
            this.pnlData = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEndTargetAmount = new System.Windows.Forms.TextBox();
            this.txtEndCurrentAmount = new System.Windows.Forms.TextBox();
            this.txtStartTargetAmount = new System.Windows.Forms.TextBox();
            this.txtStartCurrentAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDescriptionUpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDUpdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.txtTargetAmountUpdate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNameUpdate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Location = new System.Drawing.Point(367, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Target amount: ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(367, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Current amount: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEndDate.Location = new System.Drawing.Point(108, 35);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(26, 13);
            this.lblEndDate.TabIndex = 18;
            this.lblEndDate.Text = "To: ";
            this.lblEndDate.Click += new System.EventHandler(this.label9_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd";
            this.dtpStartDate.Location = new System.Drawing.Point(160, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 20);
            this.dtpStartDate.TabIndex = 17;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd";
            this.dtpEndDate.Location = new System.Drawing.Point(160, 33);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 20);
            this.dtpEndDate.TabIndex = 14;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStartDate.Location = new System.Drawing.Point(108, 17);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(36, 13);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "From: ";
            this.lblStartDate.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtCurrentAmountUpdate
            // 
            this.txtCurrentAmountUpdate.Location = new System.Drawing.Point(111, 47);
            this.txtCurrentAmountUpdate.Name = "txtCurrentAmountUpdate";
            this.txtCurrentAmountUpdate.ReadOnly = true;
            this.txtCurrentAmountUpdate.Size = new System.Drawing.Size(212, 22);
            this.txtCurrentAmountUpdate.TabIndex = 3;
            this.txtCurrentAmountUpdate.TextChanged += new System.EventHandler(this.txtAmountUpdate_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Current amount";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(720, 29);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(720, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(395, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Deadline";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // dtpDeadlineUpdate
            // 
            this.dtpDeadlineUpdate.Location = new System.Drawing.Point(458, 12);
            this.dtpDeadlineUpdate.Name = "dtpDeadlineUpdate";
            this.dtpDeadlineUpdate.Size = new System.Drawing.Size(214, 22);
            this.dtpDeadlineUpdate.TabIndex = 4;
            this.dtpDeadlineUpdate.ValueChanged += new System.EventHandler(this.dtpDateUpdate_ValueChanged);
            // 
            // dgvGoals
            // 
            this.dgvGoals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoals.Location = new System.Drawing.Point(1, 61);
            this.dgvGoals.MultiSelect = false;
            this.dgvGoals.Name = "dgvGoals";
            this.dgvGoals.RowHeadersWidth = 62;
            this.dgvGoals.Size = new System.Drawing.Size(800, 276);
            this.dgvGoals.TabIndex = 1;
            this.dgvGoals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoals_CellClick);
            this.dgvGoals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellContentClick);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.label12);
            this.pnlData.Controls.Add(this.label11);
            this.pnlData.Controls.Add(this.txtEndTargetAmount);
            this.pnlData.Controls.Add(this.txtEndCurrentAmount);
            this.pnlData.Controls.Add(this.txtStartTargetAmount);
            this.pnlData.Controls.Add(this.txtStartCurrentAmount);
            this.pnlData.Controls.Add(this.label10);
            this.pnlData.Controls.Add(this.label3);
            this.pnlData.Controls.Add(this.lblEndDate);
            this.pnlData.Controls.Add(this.dtpStartDate);
            this.pnlData.Controls.Add(this.dtpEndDate);
            this.pnlData.Controls.Add(this.lblStartDate);
            this.pnlData.Controls.Add(this.btnReload);
            this.pnlData.Controls.Add(this.btnAdd);
            this.pnlData.Controls.Add(this.dgvGoals);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Location = new System.Drawing.Point(-1, 3);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(798, 337);
            this.pnlData.TabIndex = 4;
            this.pnlData.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlData_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(564, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(564, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "-";
            // 
            // txtEndTargetAmount
            // 
            this.txtEndTargetAmount.Location = new System.Drawing.Point(580, 33);
            this.txtEndTargetAmount.Name = "txtEndTargetAmount";
            this.txtEndTargetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtEndTargetAmount.TabIndex = 24;
            // 
            // txtEndCurrentAmount
            // 
            this.txtEndCurrentAmount.Location = new System.Drawing.Point(580, 12);
            this.txtEndCurrentAmount.Name = "txtEndCurrentAmount";
            this.txtEndCurrentAmount.Size = new System.Drawing.Size(100, 20);
            this.txtEndCurrentAmount.TabIndex = 23;
            // 
            // txtStartTargetAmount
            // 
            this.txtStartTargetAmount.Location = new System.Drawing.Point(458, 33);
            this.txtStartTargetAmount.Name = "txtStartTargetAmount";
            this.txtStartTargetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtStartTargetAmount.TabIndex = 22;
            // 
            // txtStartCurrentAmount
            // 
            this.txtStartCurrentAmount.Location = new System.Drawing.Point(458, 12);
            this.txtStartCurrentAmount.Name = "txtStartCurrentAmount";
            this.txtStartCurrentAmount.Size = new System.Drawing.Size(100, 20);
            this.txtStartCurrentAmount.TabIndex = 21;
            this.txtStartCurrentAmount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "GOALS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(698, 43);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtDescriptionUpdate
            // 
            this.txtDescriptionUpdate.Location = new System.Drawing.Point(106, 79);
            this.txtDescriptionUpdate.Multiline = true;
            this.txtDescriptionUpdate.Name = "txtDescriptionUpdate";
            this.txtDescriptionUpdate.Size = new System.Drawing.Size(566, 84);
            this.txtDescriptionUpdate.TabIndex = 2;
            this.txtDescriptionUpdate.TextChanged += new System.EventHandler(this.txtDescriptionUpdate_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtIDUpdate
            // 
            this.txtIDUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUpdate.Location = new System.Drawing.Point(34, 11);
            this.txtIDUpdate.Name = "txtIDUpdate";
            this.txtIDUpdate.ReadOnly = true;
            this.txtIDUpdate.Size = new System.Drawing.Size(34, 22);
            this.txtIDUpdate.TabIndex = 4;
            this.txtIDUpdate.TextChanged += new System.EventHandler(this.txtIDUpdate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(698, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.txtTargetAmountUpdate);
            this.pnlControl.Controls.Add(this.label13);
            this.pnlControl.Controls.Add(this.txtNameUpdate);
            this.pnlControl.Controls.Add(this.dtpDeadlineUpdate);
            this.pnlControl.Controls.Add(this.label8);
            this.pnlControl.Controls.Add(this.txtCurrentAmountUpdate);
            this.pnlControl.Controls.Add(this.label7);
            this.pnlControl.Controls.Add(this.btnUpdate);
            this.pnlControl.Controls.Add(this.txtDescriptionUpdate);
            this.pnlControl.Controls.Add(this.label5);
            this.pnlControl.Controls.Add(this.label4);
            this.pnlControl.Controls.Add(this.txtIDUpdate);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlControl.Location = new System.Drawing.Point(-1, 346);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(798, 214);
            this.pnlControl.TabIndex = 5;
            this.pnlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControl_Paint);
            // 
            // txtTargetAmountUpdate
            // 
            this.txtTargetAmountUpdate.Location = new System.Drawing.Point(458, 47);
            this.txtTargetAmountUpdate.Name = "txtTargetAmountUpdate";
            this.txtTargetAmountUpdate.Size = new System.Drawing.Size(214, 22);
            this.txtTargetAmountUpdate.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(365, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 15);
            this.label13.TabIndex = 17;
            this.label13.Text = "Target amount";
            // 
            // txtNameUpdate
            // 
            this.txtNameUpdate.Location = new System.Drawing.Point(155, 12);
            this.txtNameUpdate.Name = "txtNameUpdate";
            this.txtNameUpdate.Size = new System.Drawing.Size(168, 22);
            this.txtNameUpdate.TabIndex = 15;
            // 
            // frmGoalManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlControl);
            this.Name = "frmGoalManagement";
            this.Size = new System.Drawing.Size(800, 560);
            this.Load += new System.EventHandler(this.frmGoalManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtCurrentAmountUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDeadlineUpdate;
        private System.Windows.Forms.DataGridView dgvGoals;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDescriptionUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.TextBox txtStartTargetAmount;
        private System.Windows.Forms.TextBox txtStartCurrentAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEndTargetAmount;
        private System.Windows.Forms.TextBox txtEndCurrentAmount;
        private System.Windows.Forms.TextBox txtNameUpdate;
        private System.Windows.Forms.TextBox txtTargetAmountUpdate;
        private System.Windows.Forms.Label label13;
    }
}