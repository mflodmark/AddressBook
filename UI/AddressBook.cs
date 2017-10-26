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
            var table = LoadData("select Id, Name from Contact;", -1);

            ContactDataGridView.DataSource = table.Tables[0];
        }

        private void LoadAddressInfo(int id)
        {
            var table = LoadData("select ca.ContactId, a.Street, a.City, a.PostalCode from Contact c " +
                                 "inner join Contact_Address ca on ca.ContactId = c.Id " +
                                 "inner join Address a on a.Id = ca.ContactId " +
                                 "where c.Id = @id", id);

            ShowAddressGridView.DataSource = table.Tables[0];
        }

        private void LoadTelephoneInfo(int id)
        {
            var table = LoadData("select Id, Name from Contact;", id);

            ShowTelephoneGridView.DataSource = table.Tables[0];
        }

        private void LoadEmailInfo(int id)
        {
            var table = LoadData("select Id, Name from Contact;",id);

            ShowEmailGridView.DataSource = table.Tables[0];
        }

        private DataSet LoadData(string command, int id)
        {
            var dataAccess = new DataAccess();
            var cmdText = command;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            return dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, parameters);
           
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
            if (ContactDataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < ContactDataGridView.Rows.Count; i++)
                {
                    if (ContactDataGridView.Rows[i].Selected)
                    {
                        var id = ContactDataGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Id", id)
                        };

                        var command = "delete from Contact where Id = @Id;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) ContactDataGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void EditAddressBook(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = ContactDataGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ContactDataGridView.Columns[e.ColumnIndex].HeaderText;
            var id = ContactDataGridView[0, e.RowIndex].Value;

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
            var searchCity = SearchCity.Text;
            var searchContact = "";

            if (SearchName.Text != "") searchName = $"%{SearchName.Text}%";

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

            ContactDataGridView.DataSource = contacts.Tables[0];
        }

        private void AddressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)ContactDataGridView[0, e.RowIndex].Value;

            LoadAddressInfo(id);
            LoadTelephoneInfo(id);
            LoadEmailInfo(id);
        }
    }
}
