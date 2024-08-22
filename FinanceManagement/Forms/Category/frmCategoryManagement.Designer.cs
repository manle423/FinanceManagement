namespace FinanceManagement.Forms
{
    partial class frmCategoryManagement
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnToAddCate = new System.Windows.Forms.Button();
            this.cboCateType = new System.Windows.Forms.ComboBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDescriptionUpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCateTypeUpdate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameUpdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDUpdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.btnReload);
            this.pnlData.Controls.Add(this.btnToAddCate);
            this.pnlData.Controls.Add(this.cboCateType);
            this.pnlData.Controls.Add(this.dgvCategories);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Location = new System.Drawing.Point(3, 3);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(794, 337);
            this.pnlData.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(676, 20);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnToAddCate
            // 
            this.btnToAddCate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToAddCate.Location = new System.Drawing.Point(595, 20);
            this.btnToAddCate.Name = "btnToAddCate";
            this.btnToAddCate.Size = new System.Drawing.Size(75, 23);
            this.btnToAddCate.TabIndex = 4;
            this.btnToAddCate.Text = "Add";
            this.btnToAddCate.UseVisualStyleBackColor = true;
            this.btnToAddCate.Click += new System.EventHandler(this.btnToAddCate_Click);
            // 
            // cboCateType
            // 
            this.cboCateType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCateType.FormattingEnabled = true;
            this.cboCateType.Items.AddRange(new object[] {
            "All",
            "Expense",
            "Income"});
            this.cboCateType.Location = new System.Drawing.Point(468, 15);
            this.cboCateType.Name = "cboCateType";
            this.cboCateType.Size = new System.Drawing.Size(121, 35);
            this.cboCateType.TabIndex = 3;
            this.cboCateType.SelectedIndexChanged += new System.EventHandler(this.cboCateType_SelectedIndexChanged);
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(3, 47);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersWidth = 62;
            this.dgvCategories.Size = new System.Drawing.Size(788, 287);
            this.dgvCategories.TabIndex = 1;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            this.dgvCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "CATEGORIES";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnUpdate);
            this.pnlControl.Controls.Add(this.txtDescriptionUpdate);
            this.pnlControl.Controls.Add(this.label5);
            this.pnlControl.Controls.Add(this.cboCateTypeUpdate);
            this.pnlControl.Controls.Add(this.label4);
            this.pnlControl.Controls.Add(this.txtNameUpdate);
            this.pnlControl.Controls.Add(this.label3);
            this.pnlControl.Controls.Add(this.txtIDUpdate);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlControl.Location = new System.Drawing.Point(3, 346);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(797, 214);
            this.pnlControl.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(285, 43);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtDescriptionUpdate
            // 
            this.txtDescriptionUpdate.Location = new System.Drawing.Point(78, 82);
            this.txtDescriptionUpdate.Multiline = true;
            this.txtDescriptionUpdate.Name = "txtDescriptionUpdate";
            this.txtDescriptionUpdate.Size = new System.Drawing.Size(161, 84);
            this.txtDescriptionUpdate.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description";
            // 
            // cboCateTypeUpdate
            // 
            this.cboCateTypeUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCateTypeUpdate.FormattingEnabled = true;
            this.cboCateTypeUpdate.Items.AddRange(new object[] {
            "Expense",
            "Income"});
            this.cboCateTypeUpdate.Location = new System.Drawing.Point(132, 18);
            this.cboCateTypeUpdate.Name = "cboCateTypeUpdate";
            this.cboCateTypeUpdate.Size = new System.Drawing.Size(107, 30);
            this.cboCateTypeUpdate.TabIndex = 8;
            this.cboCateTypeUpdate.SelectedIndexChanged += new System.EventHandler(this.cboCateTypeUpdate_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtNameUpdate
            // 
            this.txtNameUpdate.Location = new System.Drawing.Point(78, 50);
            this.txtNameUpdate.Name = "txtNameUpdate";
            this.txtNameUpdate.Size = new System.Drawing.Size(161, 30);
            this.txtNameUpdate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // txtIDUpdate
            // 
            this.txtIDUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUpdate.Location = new System.Drawing.Point(44, 16);
            this.txtIDUpdate.Name = "txtIDUpdate";
            this.txtIDUpdate.ReadOnly = true;
            this.txtIDUpdate.Size = new System.Drawing.Size(34, 30);
            this.txtIDUpdate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(285, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmCategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlData);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCategoryManagement";
            this.Size = new System.Drawing.Size(800, 560);
            this.Load += new System.EventHandler(this.frmCategoryManagement_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.ComboBox cboCateType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToAddCate;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtNameUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCateTypeUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescriptionUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
    }
}
