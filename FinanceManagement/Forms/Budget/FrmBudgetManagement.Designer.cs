namespace FinanceManagement.Forms.Budget
{
    partial class FrmBudgetManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControl = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAmountUpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategoryUpdate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDUpdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnToAddBudget = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.dgvBudgets = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.label7);
            this.pnlControl.Controls.Add(this.label6);
            this.pnlControl.Controls.Add(this.dtpEndDate);
            this.pnlControl.Controls.Add(this.dtpStartDate);
            this.pnlControl.Controls.Add(this.btnUpdate);
            this.pnlControl.Controls.Add(this.txtAmountUpdate);
            this.pnlControl.Controls.Add(this.label5);
            this.pnlControl.Controls.Add(this.cboCategoryUpdate);
            this.pnlControl.Controls.Add(this.label4);
            this.pnlControl.Controls.Add(this.txtIDUpdate);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlControl.Location = new System.Drawing.Point(3, 340);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(794, 211);
            this.pnlControl.TabIndex = 7;
            this.pnlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControl_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "End Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(78, 112);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(223, 22);
            this.dtpEndDate.TabIndex = 13;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(78, 84);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(223, 22);
            this.dtpStartDate.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(337, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtAmountUpdate
            // 
            this.txtAmountUpdate.Location = new System.Drawing.Point(78, 51);
            this.txtAmountUpdate.Name = "txtAmountUpdate";
            this.txtAmountUpdate.Size = new System.Drawing.Size(223, 22);
            this.txtAmountUpdate.TabIndex = 10;
            this.txtAmountUpdate.TextChanged += new System.EventHandler(this.txtAmountUpdate_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount";
            // 
            // cboCategoryUpdate
            // 
            this.cboCategoryUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoryUpdate.FormattingEnabled = true;
            this.cboCategoryUpdate.Location = new System.Drawing.Point(194, 15);
            this.cboCategoryUpdate.Name = "cboCategoryUpdate";
            this.cboCategoryUpdate.Size = new System.Drawing.Size(107, 23);
            this.cboCategoryUpdate.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Category";
            // 
            // txtIDUpdate
            // 
            this.txtIDUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUpdate.Location = new System.Drawing.Point(78, 14);
            this.txtIDUpdate.Name = "txtIDUpdate";
            this.txtIDUpdate.ReadOnly = true;
            this.txtIDUpdate.Size = new System.Drawing.Size(34, 22);
            this.txtIDUpdate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(337, 82);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(676, 14);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnToAddBudget
            // 
            this.btnToAddBudget.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToAddBudget.Location = new System.Drawing.Point(595, 14);
            this.btnToAddBudget.Name = "btnToAddBudget";
            this.btnToAddBudget.Size = new System.Drawing.Size(75, 23);
            this.btnToAddBudget.TabIndex = 10;
            this.btnToAddBudget.Text = "Add";
            this.btnToAddBudget.UseVisualStyleBackColor = true;
            this.btnToAddBudget.Click += new System.EventHandler(this.btnToAddBudget_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(468, 9);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 27);
            this.cboCategory.TabIndex = 9;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // dgvBudgets
            // 
            this.dgvBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgets.Location = new System.Drawing.Point(3, 41);
            this.dgvBudgets.MultiSelect = false;
            this.dgvBudgets.Name = "dgvBudgets";
            this.dgvBudgets.Size = new System.Drawing.Size(788, 287);
            this.dgvBudgets.TabIndex = 8;
            this.dgvBudgets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBudgets_CellClick);
            this.dgvBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBudgets_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "BUDGETS";
            // 
            // FrmBudgetManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnToAddBudget);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.dgvBudgets);
            this.Controls.Add(this.label2);
            this.Name = "FrmBudgetManagement";
            this.Size = new System.Drawing.Size(800, 560);
            this.Load += new System.EventHandler(this.FrmBudgetManagement_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAmountUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCategoryUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnToAddBudget;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.DataGridView dgvBudgets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
