using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            var cmdText = "select Id,Name from Contact;";

            var contacts = dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, null);

            AddressDataGridView.DataSource = contacts.Tables[0];
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (AddressDataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < AddressDataGridView.Rows.Count; i++)
                {
                    if (AddressDataGridView.Rows[i].Selected)
                    {
                        var orderId = AddressDataGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@OrderId", orderId)
                        };

                        var command = "delete from [Order Details] where OrderId =@OrderId;" +
                                      "delete from Orders where OrderId = @OrderId;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) AddressDataGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }
    }
}
