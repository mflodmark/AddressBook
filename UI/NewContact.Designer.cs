namespace AddressBook.UI
{
    partial class NewContact
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
            this.Label2 = new System.Windows.Forms.Label();
            this.NewFirstNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NewLastNameTxtBox = new System.Windows.Forms.TextBox();
            this.NewAddressGrid = new System.Windows.Forms.DataGridView();
            this.NewTelephoneGrid = new System.Windows.Forms.DataGridView();
            this.NewEmailGrid = new System.Windows.Forms.DataGridView();
            this.CreateContactBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NewZipTextBox = new System.Windows.Forms.TextBox();
            this.NewTelNrTextBox = new System.Windows.Forms.TextBox();
            this.NewEmailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddAddressBtn = new System.Windows.Forms.Button();
            this.AddTelBtn = new System.Windows.Forms.Button();
            this.AddEmailBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NewTypeComboBox = new System.Windows.Forms.ComboBox();
            this.NewCityTextBox = new System.Windows.Forms.TextBox();
            this.NewStreetTextBox = new System.Windows.Forms.TextBox();
            this.NewDiallingTextBox = new System.Windows.Forms.TextBox();
            this.NewCountryTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NewAddressGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewTelephoneGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEmailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(115, 57);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 20);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Förnamn";
            // 
            // NewFirstNameTxtBox
            // 
            this.NewFirstNameTxtBox.Location = new System.Drawing.Point(246, 51);
            this.NewFirstNameTxtBox.MaxLength = 25;
            this.NewFirstNameTxtBox.Name = "NewFirstNameTxtBox";
            this.NewFirstNameTxtBox.Size = new System.Drawing.Size(156, 26);
            this.NewFirstNameTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Efternamn";
            // 
            // NewLastNameTxtBox
            // 
            this.NewLastNameTxtBox.Location = new System.Drawing.Point(246, 88);
            this.NewLastNameTxtBox.MaxLength = 25;
            this.NewLastNameTxtBox.Name = "NewLastNameTxtBox";
            this.NewLastNameTxtBox.Size = new System.Drawing.Size(156, 26);
            this.NewLastNameTxtBox.TabIndex = 2;
            // 
            // NewAddressGrid
            // 
            this.NewAddressGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NewAddressGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewAddressGrid.Location = new System.Drawing.Point(43, 284);
            this.NewAddressGrid.Name = "NewAddressGrid";
            this.NewAddressGrid.RowTemplate.Height = 28;
            this.NewAddressGrid.Size = new System.Drawing.Size(418, 188);
            this.NewAddressGrid.TabIndex = 4;
            // 
            // NewTelephoneGrid
            // 
            this.NewTelephoneGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NewTelephoneGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewTelephoneGrid.Location = new System.Drawing.Point(467, 284);
            this.NewTelephoneGrid.Name = "NewTelephoneGrid";
            this.NewTelephoneGrid.RowTemplate.Height = 28;
            this.NewTelephoneGrid.Size = new System.Drawing.Size(327, 188);
            this.NewTelephoneGrid.TabIndex = 5;
            // 
            // NewEmailGrid
            // 
            this.NewEmailGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NewEmailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewEmailGrid.Location = new System.Drawing.Point(800, 284);
            this.NewEmailGrid.Name = "NewEmailGrid";
            this.NewEmailGrid.RowTemplate.Height = 28;
            this.NewEmailGrid.Size = new System.Drawing.Size(358, 188);
            this.NewEmailGrid.TabIndex = 6;
            // 
            // CreateContactBtn
            // 
            this.CreateContactBtn.BackColor = System.Drawing.Color.Green;
            this.CreateContactBtn.Location = new System.Drawing.Point(1049, 568);
            this.CreateContactBtn.Name = "CreateContactBtn";
            this.CreateContactBtn.Size = new System.Drawing.Size(119, 66);
            this.CreateContactBtn.TabIndex = 7;
            this.CreateContactBtn.Text = "Create contact!";
            this.CreateContactBtn.UseVisualStyleBackColor = false;
            this.CreateContactBtn.Click += new System.EventHandler(this.CreateContactBtn_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.BackColor = System.Drawing.Color.Red;
            this.UndoBtn.Location = new System.Drawing.Point(12, 568);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(124, 66);
            this.UndoBtn.TabIndex = 8;
            this.UndoBtn.Text = "Undo and go back...";
            this.UndoBtn.UseVisualStyleBackColor = false;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Adresser";
            // 
            // NewZipTextBox
            // 
            this.NewZipTextBox.Location = new System.Drawing.Point(43, 252);
            this.NewZipTextBox.MaxLength = 10;
            this.NewZipTextBox.Name = "NewZipTextBox";
            this.NewZipTextBox.Size = new System.Drawing.Size(336, 26);
            this.NewZipTextBox.TabIndex = 6;
            this.NewZipTextBox.Text = "Postkod";
            // 
            // NewTelNrTextBox
            // 
            this.NewTelNrTextBox.Location = new System.Drawing.Point(467, 252);
            this.NewTelNrTextBox.MaxLength = 7;
            this.NewTelNrTextBox.Name = "NewTelNrTextBox";
            this.NewTelNrTextBox.Size = new System.Drawing.Size(245, 26);
            this.NewTelNrTextBox.TabIndex = 9;
            this.NewTelNrTextBox.Text = "Telefonnummer";
            // 
            // NewEmailTextBox
            // 
            this.NewEmailTextBox.Location = new System.Drawing.Point(800, 252);
            this.NewEmailTextBox.MaxLength = 30;
            this.NewEmailTextBox.Name = "NewEmailTextBox";
            this.NewEmailTextBox.Size = new System.Drawing.Size(276, 26);
            this.NewEmailTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Telefonnummer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(796, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email";
            // 
            // AddAddressBtn
            // 
            this.AddAddressBtn.Location = new System.Drawing.Point(385, 188);
            this.AddAddressBtn.Name = "AddAddressBtn";
            this.AddAddressBtn.Size = new System.Drawing.Size(76, 90);
            this.AddAddressBtn.TabIndex = 16;
            this.AddAddressBtn.Text = "Add";
            this.AddAddressBtn.UseVisualStyleBackColor = true;
            this.AddAddressBtn.Click += new System.EventHandler(this.AddAddressBtn_Click);
            // 
            // AddTelBtn
            // 
            this.AddTelBtn.Location = new System.Drawing.Point(718, 188);
            this.AddTelBtn.Name = "AddTelBtn";
            this.AddTelBtn.Size = new System.Drawing.Size(76, 90);
            this.AddTelBtn.TabIndex = 17;
            this.AddTelBtn.Text = "Add";
            this.AddTelBtn.UseVisualStyleBackColor = true;
            this.AddTelBtn.Click += new System.EventHandler(this.AddTelBtn_Click);
            // 
            // AddEmailBtn
            // 
            this.AddEmailBtn.Location = new System.Drawing.Point(1082, 244);
            this.AddEmailBtn.Name = "AddEmailBtn";
            this.AddEmailBtn.Size = new System.Drawing.Size(76, 34);
            this.AddEmailBtn.TabIndex = 18;
            this.AddEmailBtn.Text = "Add";
            this.AddEmailBtn.UseVisualStyleBackColor = true;
            this.AddEmailBtn.Click += new System.EventHandler(this.AddEmailBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Typ";
            // 
            // NewTypeComboBox
            // 
            this.NewTypeComboBox.FormattingEnabled = true;
            this.NewTypeComboBox.Location = new System.Drawing.Point(537, 51);
            this.NewTypeComboBox.Name = "NewTypeComboBox";
            this.NewTypeComboBox.Size = new System.Drawing.Size(171, 28);
            this.NewTypeComboBox.TabIndex = 3;
            // 
            // NewCityTextBox
            // 
            this.NewCityTextBox.Location = new System.Drawing.Point(43, 220);
            this.NewCityTextBox.MaxLength = 30;
            this.NewCityTextBox.Name = "NewCityTextBox";
            this.NewCityTextBox.Size = new System.Drawing.Size(336, 26);
            this.NewCityTextBox.TabIndex = 5;
            this.NewCityTextBox.Text = "Stad";
            // 
            // NewStreetTextBox
            // 
            this.NewStreetTextBox.Location = new System.Drawing.Point(43, 188);
            this.NewStreetTextBox.MaxLength = 30;
            this.NewStreetTextBox.Name = "NewStreetTextBox";
            this.NewStreetTextBox.Size = new System.Drawing.Size(336, 26);
            this.NewStreetTextBox.TabIndex = 4;
            this.NewStreetTextBox.Text = "Adress";
            // 
            // NewDiallingTextBox
            // 
            this.NewDiallingTextBox.Location = new System.Drawing.Point(467, 220);
            this.NewDiallingTextBox.MaxLength = 3;
            this.NewDiallingTextBox.Name = "NewDiallingTextBox";
            this.NewDiallingTextBox.Size = new System.Drawing.Size(245, 26);
            this.NewDiallingTextBox.TabIndex = 8;
            this.NewDiallingTextBox.Text = "Riktnummer";
            // 
            // NewCountryTextBox
            // 
            this.NewCountryTextBox.Location = new System.Drawing.Point(467, 188);
            this.NewCountryTextBox.MaxLength = 3;
            this.NewCountryTextBox.Name = "NewCountryTextBox";
            this.NewCountryTextBox.Size = new System.Drawing.Size(245, 26);
            this.NewCountryTextBox.TabIndex = 7;
            this.NewCountryTextBox.Text = "Landkod";
            // 
            // NewContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 646);
            this.Controls.Add(this.NewCountryTextBox);
            this.Controls.Add(this.NewDiallingTextBox);
            this.Controls.Add(this.NewStreetTextBox);
            this.Controls.Add(this.NewCityTextBox);
            this.Controls.Add(this.NewTypeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddEmailBtn);
            this.Controls.Add(this.AddTelBtn);
            this.Controls.Add(this.AddAddressBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NewEmailTextBox);
            this.Controls.Add(this.NewTelNrTextBox);
            this.Controls.Add(this.NewZipTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UndoBtn);
            this.Controls.Add(this.CreateContactBtn);
            this.Controls.Add(this.NewEmailGrid);
            this.Controls.Add(this.NewTelephoneGrid);
            this.Controls.Add(this.NewAddressGrid);
            this.Controls.Add(this.NewLastNameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewFirstNameTxtBox);
            this.Controls.Add(this.Label2);
            this.Name = "NewContact";
            this.Text = "NewContact";
            ((System.ComponentModel.ISupportInitialize)(this.NewAddressGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewTelephoneGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEmailGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox NewFirstNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewLastNameTxtBox;
        private System.Windows.Forms.DataGridView NewAddressGrid;
        private System.Windows.Forms.DataGridView NewTelephoneGrid;
        private System.Windows.Forms.DataGridView NewEmailGrid;
        private System.Windows.Forms.Button CreateContactBtn;
        private System.Windows.Forms.Button UndoBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NewZipTextBox;
        private System.Windows.Forms.TextBox NewTelNrTextBox;
        private System.Windows.Forms.TextBox NewEmailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddAddressBtn;
        private System.Windows.Forms.Button AddTelBtn;
        private System.Windows.Forms.Button AddEmailBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox NewTypeComboBox;
        private System.Windows.Forms.TextBox NewCityTextBox;
        private System.Windows.Forms.TextBox NewStreetTextBox;
        private System.Windows.Forms.TextBox NewDiallingTextBox;
        private System.Windows.Forms.TextBox NewCountryTextBox;
    }
}