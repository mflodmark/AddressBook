﻿namespace AddressBook
{
    partial class AddressBook
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
            this.ContactDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchName = new System.Windows.Forms.TextBox();
            this.SearchCity = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchContactType = new System.Windows.Forms.ComboBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ShowAddressGridView = new System.Windows.Forms.DataGridView();
            this.ShowTelephoneGridView = new System.Windows.Forms.DataGridView();
            this.ShowEmailGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ContactDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowAddressGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowTelephoneGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowEmailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactDataGridView
            // 
            this.ContactDataGridView.AllowUserToAddRows = false;
            this.ContactDataGridView.AllowUserToDeleteRows = false;
            this.ContactDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ContactDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactDataGridView.Location = new System.Drawing.Point(114, 109);
            this.ContactDataGridView.Name = "ContactDataGridView";
            this.ContactDataGridView.RowTemplate.Height = 28;
            this.ContactDataGridView.Size = new System.Drawing.Size(686, 200);
            this.ContactDataGridView.TabIndex = 0;
            this.ContactDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddressDataGridView_CellClick);
            this.ContactDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditAddressBook);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Red;
            this.DeleteBtn.Location = new System.Drawing.Point(838, 266);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(119, 43);
            this.DeleteBtn.TabIndex = 22;
            this.DeleteBtn.Text = "Delete row";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.addContactToolStripMenuItem.Text = "Add contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.addContactToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SearchName
            // 
            this.SearchName.AccessibleDescription = "";
            this.SearchName.AccessibleName = "";
            this.SearchName.Location = new System.Drawing.Point(114, 75);
            this.SearchName.Name = "SearchName";
            this.SearchName.Size = new System.Drawing.Size(202, 26);
            this.SearchName.TabIndex = 1;
            // 
            // SearchCity
            // 
            this.SearchCity.Location = new System.Drawing.Point(322, 75);
            this.SearchCity.Name = "SearchCity";
            this.SearchCity.Size = new System.Drawing.Size(191, 26);
            this.SearchCity.TabIndex = 21;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.Cyan;
            this.SearchBtn.Location = new System.Drawing.Point(691, 47);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(109, 56);
            this.SearchBtn.TabIndex = 20;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Namn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Postort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Typ av kontakt";
            // 
            // SearchContactType
            // 
            this.SearchContactType.FormattingEnabled = true;
            this.SearchContactType.Location = new System.Drawing.Point(519, 75);
            this.SearchContactType.Name = "SearchContactType";
            this.SearchContactType.Size = new System.Drawing.Size(166, 28);
            this.SearchContactType.TabIndex = 10;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.ForeColor = System.Drawing.Color.White;
            this.ResultLabel.Location = new System.Drawing.Point(992, 277);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(65, 20);
            this.ResultLabel.TabIndex = 11;
            this.ResultLabel.Text = "-Result-";
            // 
            // ShowAddressGridView
            // 
            this.ShowAddressGridView.AllowUserToAddRows = false;
            this.ShowAddressGridView.AllowUserToDeleteRows = false;
            this.ShowAddressGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ShowAddressGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowAddressGridView.Location = new System.Drawing.Point(114, 375);
            this.ShowAddressGridView.Name = "ShowAddressGridView";
            this.ShowAddressGridView.RowTemplate.Height = 28;
            this.ShowAddressGridView.Size = new System.Drawing.Size(456, 210);
            this.ShowAddressGridView.TabIndex = 23;
            this.ShowAddressGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditAddressBook);
            // 
            // ShowTelephoneGridView
            // 
            this.ShowTelephoneGridView.AllowUserToAddRows = false;
            this.ShowTelephoneGridView.AllowUserToDeleteRows = false;
            this.ShowTelephoneGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ShowTelephoneGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowTelephoneGridView.Location = new System.Drawing.Point(576, 375);
            this.ShowTelephoneGridView.Name = "ShowTelephoneGridView";
            this.ShowTelephoneGridView.RowTemplate.Height = 28;
            this.ShowTelephoneGridView.Size = new System.Drawing.Size(351, 210);
            this.ShowTelephoneGridView.TabIndex = 24;
            this.ShowTelephoneGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditAddressBook);
            // 
            // ShowEmailGridView
            // 
            this.ShowEmailGridView.AllowUserToAddRows = false;
            this.ShowEmailGridView.AllowUserToDeleteRows = false;
            this.ShowEmailGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ShowEmailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowEmailGridView.Location = new System.Drawing.Point(933, 375);
            this.ShowEmailGridView.Name = "ShowEmailGridView";
            this.ShowEmailGridView.RowTemplate.Height = 28;
            this.ShowEmailGridView.Size = new System.Drawing.Size(327, 210);
            this.ShowEmailGridView.TabIndex = 25;
            this.ShowEmailGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditAddressBook);
            // 
            // AddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 597);
            this.Controls.Add(this.ShowEmailGridView);
            this.Controls.Add(this.ShowTelephoneGridView);
            this.Controls.Add(this.ShowAddressGridView);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.SearchContactType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchCity);
            this.Controls.Add(this.SearchName);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.ContactDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AddressBook";
            this.Text = "AddressBook";
            ((System.ComponentModel.ISupportInitialize)(this.ContactDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowAddressGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowTelephoneGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowEmailGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ContactDataGridView;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox SearchName;
        private System.Windows.Forms.TextBox SearchCity;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SearchContactType;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.DataGridView ShowAddressGridView;
        private System.Windows.Forms.DataGridView ShowTelephoneGridView;
        private System.Windows.Forms.DataGridView ShowEmailGridView;
    }
}

