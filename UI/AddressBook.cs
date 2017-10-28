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
using AddressBook.UI;

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
            var table = LoadData("select a.Id, a.Street, a.City, a.PostalCode from Contact c " +
                                 "inner join Contact_Address ca on ca.ContactId = c.Id " +
                                 "inner join Address a on a.Id = ca.AddressId " +
                                 "where c.Id = @id", id);

            ShowAddressGridView.DataSource = table.Tables[0];
        }

        private void LoadTelephoneInfo(int id)
        {
            var table = LoadData("select t.Id, t.CountryCode, t.DiallingCode, t.TelephoneNumber from Contact c " +
                                 "inner join Telephone t on c.Id = t.ContactId " +
                                 "where c.Id = @id", id);

            ShowTelephoneGridView.DataSource = table.Tables[0];
        }

        private void LoadEmailInfo(int id)
        {
            var table = LoadData("select e.Id, e.Email from Contact c " +
                                 "inner join Email e on c.Id = e.ContactId " +
                                 "where c.Id = @id", id);

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
            var openForm = new NewContact();
            openForm.Show();
            this.Hide();

            FormState.PreviousPage = this;
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

            var command = $"update Contact " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private void UpdateData(string command, SqlParameter[] parameters)
        {
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

            ShowAddressGridView.Columns.Clear();
            ShowEmailGridView.Columns.Clear();
            ShowTelephoneGridView.Columns.Clear();
        }

        private void AddressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)ContactDataGridView[0, e.RowIndex].Value;

            LoadAddressInfo(id);
            LoadTelephoneInfo(id);
            LoadEmailInfo(id);
            ClearResultLabel();
        }

        private void ClearResultLabel()
        {
            ResultLabel.BackColor = Color.Empty;
            ResultLabel.Text = "";
        }

        private void ClearSearchBtn_Click(object sender, EventArgs e)
        {
            LoadAddressBook();
            ShowAddressGridView.Columns.Clear();
            ShowEmailGridView.Columns.Clear();
            ShowTelephoneGridView.Columns.Clear();
        }

        private void EditAddressInfo(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = ShowAddressGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ShowAddressGridView.Columns[e.ColumnIndex].HeaderText;
            var id = ShowAddressGridView[0, e.RowIndex].Value;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Address " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private void EditEmailInfo(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = ShowEmailGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ShowEmailGridView.Columns[e.ColumnIndex].HeaderText;
            var id = ShowEmailGridView[0, e.RowIndex].Value;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Email " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private void EditTelephoneInfo(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = ShowTelephoneGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ShowTelephoneGridView.Columns[e.ColumnIndex].HeaderText;
            var id = ShowTelephoneGridView[0, e.RowIndex].Value;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Telephone " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private void ClearResultLabel(object sender, DataGridViewCellEventArgs e)
        {
            ClearResultLabel();
        }
    }
}
