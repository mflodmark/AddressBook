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

            AddColorToSearchBox();

            LoadAddressBook();
        }

        private void AddColorToSearchBox()
        {
            SearchContactType.Items.Add("Personlig");
            SearchContactType.Items.Add("Jobb");
            SearchContactType.Items.Add("Övrig");
        }

        private void LoadAddressBook()
        {
            var dataAccess = new DataAccess();
            var cmdText = "select Id, Name from Contact;";

            var contacts = dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, null);

            AddressDataGridView.DataSource = contacts.Tables[0];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                        var id = AddressDataGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Id", id)
                        };

                        var command = "delete from Contact where Id = @Id;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) AddressDataGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void EditAddressBook(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = AddressDataGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = AddressDataGridView.Columns[e.ColumnIndex].HeaderText;
            var id = AddressDataGridView[0, e.RowIndex].Value;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Contact set {columnName} = @{columnName} where Id = @Id";

            var dataAccess = new DataAccess();
            var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

            if (result)
            {
                ResultLabel.Text = "Update worked as planned!";
                ResultLabel.BackColor = Color.Green;
            }
            else
            {
                ResultLabel.Text = "Doh! Update didn't work...";
                ResultLabel.BackColor = Color.Red;
            }
            
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var dataAccess = new DataAccess();
            var searchName = "";
            if (SearchName.Text != "") searchName = $"%{SearchName.Text}%";
            var searchCity = SearchCity.Text;
            var searchContact = "";
            if (SearchContactType.SelectedItem != null) searchContact = SearchContactType.SelectedItem.ToString();
            

            SqlParameter[] parameters = {
                new SqlParameter("@Name", searchName),
                new SqlParameter("@City", searchCity),
                new SqlParameter("@ContactType", searchContact)
            };


            var cmdText = "select c.Id, c.Name from Contact c " +
                          "inner join Contact_Address ca on ca.ContactId = c.Id " +
                          "inner join Address a on a.Id = ca.AddressId " +
                          "where c.Name like @Name " +
                          "or a.City like @City " +
                          "or c.ContactType like @ContactType;";

            var contacts = dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, parameters);

            AddressDataGridView.DataSource = contacts.Tables[0];
        }
    }
}
