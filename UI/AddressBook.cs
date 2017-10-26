﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.DAL;

namespace AddressBook
{
    public partial class AddressBook : Form
    {
        public AddressBook()
        {
            InitializeComponent();

            LoadAddressBook();
        }

        private void LoadAddressBook()
        {
            var dataAccess = new DataAccess();
            var cmdText = "select Name from Contact;";

            var orders = dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, null);

            AddressDataGridView.DataSource = orders.Tables[0];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenSecondFormOnClose = true;

            Close();
        }
    }
}
