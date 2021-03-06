﻿using System;
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
        private int contactId;
        private string addressLink;

        public AddressBook()
        {
            InitializeComponent();

            AddItemsToComboBox();

            LoadAddressBook();
        }

        private void AddItemsToComboBox()
        {
            SearchContactType.Items.Add("Personlig");
            SearchContactType.Items.Add("Jobb");
            SearchContactType.Items.Add("Övrig");
        }

        #region LoadContactInfo

        public void LoadAddressBook()
        {
            var table = LoadData("select c.Id, c.Name, ct.Type from Contact c " +
                                 "inner join ContactType ct on ct.Id = c.ContactTypeId;", -1);

            ContactDataGridView.DataSource = table.Tables[0];
        }

        private void LoadAddressInfo(int id)
        {
            var table = LoadData("select a.Id, a.Street, a.City, a.ZipCode from Contact c " +
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

        #endregion

        #region EditContactInfo


        #region Address

        
        private void AmendAddress(object sender, DataGridViewCellEventArgs e)
        {
            AmendCityTxtBox.Text = ShowAddressGridView["City", e.RowIndex].Value.ToString();
            AmendStreetTxtBox.Text = ShowAddressGridView["Street", e.RowIndex].Value.ToString();
            AmendZipCodeTxtBox.Text = ShowAddressGridView["ZipCode", e.RowIndex].Value.ToString();

            addressLink = AmendStreetTxtBox.Text + AmendCityTxtBox.Text + AmendZipCodeTxtBox.Text;
        }

        private void AddAddressBtn_Click(object sender, EventArgs e)
        {
            var dataAccess = new DataAccess();
            
            var address = new Address()
            {
                Street = AmendStreetTxtBox.Text,
                City = AmendCityTxtBox.Text,
                ZipCode = AmendZipCodeTxtBox.Text
            };


            SqlParameter[] parameters = {
                new SqlParameter("@Street", address.Street),
                new SqlParameter("@City", address.City),
                new SqlParameter("@ZipCode", address.ZipCode)
            };

            var cmdText = "Declare @ExistingId int; " +
                            "Select @ExistingId = Id from Address " +
                            "where Street + City + ZipCode = @Street + @City + @ZipCode; " +
                            "If (@ExistingId is null) " +
                            "Begin " +
                            "insert into Address (Street, City, ZipCode) " +
                            "values (@Street, @City, @ZipCode) " +
                            "End";

            dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);

            var cmd = "Select Id from Address " +
                        "where Street + City + ZipCode = @Address ";

            SqlParameter[] parameters2 = {
                new SqlParameter("@Address", address.Street + address.City + address.ZipCode),
            };

            var contacts = dataAccess.ExecuteSelectCommand(cmd, CommandType.Text, parameters2);

            var idFromAddress = contacts.Tables[0].Rows[0]["Id"].ToString();

            var addContactAddress = "insert into Contact_Address (ContactId, AddressId) " +
                                    $"values ({contactId}, {idFromAddress}) ";

            dataAccess.ExecuteNonQuery(addContactAddress, CommandType.Text, null);
            
            LoadAddressInfo(contactId);

            AmendZipCodeTxtBox.Text = "";
            AmendCityTxtBox.Text = "";
            AmendStreetTxtBox.Text = "";
        }

        private void amendAddressBtn_Click(object sender, EventArgs e)
        {
            var dataAccess = new DataAccess();

            var address = new Address()
            {
                Street = AmendStreetTxtBox.Text,
                City = AmendCityTxtBox.Text,
                ZipCode = AmendZipCodeTxtBox.Text
            };

            var cmd = "Select Id from Address " +
                      $"where Street + City + ZipCode = '{addressLink}'; ";

            var contacts = dataAccess.ExecuteSelectCommand(cmd, CommandType.Text, null);

            var idFromAddress = contacts.Tables[0].Rows[0]["Id"].ToString();


            SqlParameter[] parameters = {
                new SqlParameter("@Street", address.Street),
                new SqlParameter("@City", address.City),
                new SqlParameter("@ZipCode", address.ZipCode)
            };

            var cmdText = "Declare @ExistingId int; " +
                          "Select @ExistingId = Id from Address " +
                          "where Street + City + ZipCode = @Street + @City + @ZipCode; " +
                          "If (@ExistingId is null) " +
                          "Begin " +
                          "update Address " +
                          "set Street = @Street, City = @City, ZipCode = @ZipCode " +
                          $"where Id = {idFromAddress} " +
                          "End";

            dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);

            LoadAddressInfo(contactId);

            AmendZipCodeTxtBox.Text = "";
            AmendCityTxtBox.Text = "";
            AmendStreetTxtBox.Text = "";
        }

        #endregion

        #region Telephone

        private void EditTelephoneInfo(object sender, DataGridViewCellEventArgs e)
        {
            var telId = 0;

            if (ShowTelephoneGridView[0, e.RowIndex].Value.ToString() == "")
            {
                telId = InsertTelephone();
                ShowTelephoneGridView[0, e.RowIndex].Value = telId;
            }
            else
            {
                telId = (int)ShowTelephoneGridView[0, e.RowIndex].Value;
            }

            var newValue = ShowTelephoneGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ShowTelephoneGridView.Columns[e.ColumnIndex].HeaderText;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", telId),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Telephone " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private int InsertTelephone()
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Id", contactId)

            };

            var cmdInsert = "insert into Telephone (CountryCode, DiallingCode, TelephoneNumber, ContactId) " +
                            "values ('*','*','*',@Id)";

            UpdateData(cmdInsert, parameters);

            var dataAccess = new DataAccess();

            var cmd = "select top(1) Id from Telephone order by Id desc";

            var contacts = dataAccess.ExecuteSelectCommand(cmd, CommandType.Text, null);

            var id = contacts.Tables[0].Rows[0]["Id"].ToString();

            return int.Parse(id);
        }

        #endregion

        #region Email

        private void EditEmailInfo(object sender, DataGridViewCellEventArgs e)
        {
            var emailId = 0;

            if (ShowEmailGridView[0, e.RowIndex].Value.ToString() == "")
            {
                emailId = InsertEmail();
                ShowEmailGridView[0, e.RowIndex].Value = emailId;
            }
            else
            {
                emailId = (int)ShowEmailGridView[0, e.RowIndex].Value;
            }

            var newValue = ShowEmailGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = ShowEmailGridView.Columns[e.ColumnIndex].HeaderText;

            SqlParameter[] parameters = {
                new SqlParameter("@Id", emailId),
                new SqlParameter("@" + columnName, newValue)
            };

            var command = $"update Email " +
                          $"set {columnName} = @{columnName} " +
                          $"where Id = @Id";

            UpdateData(command, parameters);
        }

        private int InsertEmail()
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Id", contactId)

            };

            var cmdInsert = "insert into Email (Email,ContactId) " +
                            "values ('*', @Id)";

            UpdateData(cmdInsert, parameters);

            var dataAccess = new DataAccess();

            var cmd = "select top(1) Id from Email order by Id desc";

            var contacts = dataAccess.ExecuteSelectCommand(cmd, CommandType.Text, null);

            var id = contacts.Tables[0].Rows[0]["Id"].ToString();

            return int.Parse(id);
        }


        #endregion

        #region Contact

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


        #endregion


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

        
        #endregion

        #region Clicks

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

            ShowAddressGridView.Columns.Clear();
            ShowEmailGridView.Columns.Clear();
            ShowTelephoneGridView.Columns.Clear();
        }


        private void DeleteEmailBtn_Click(object sender, EventArgs e)
        {
            if (ShowEmailGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < ShowEmailGridView.Rows.Count; i++)
                {
                    if (ShowEmailGridView.Rows[i].Selected)
                    {
                        var id = ShowEmailGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Id", id)
                        };

                        var command = "delete from Email where Id = @Id;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) ShowEmailGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void DeleteAddressBtn_Click(object sender, EventArgs e)
        {
            if (ShowAddressGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < ShowAddressGridView.Rows.Count; i++)
                {
                    if (ShowAddressGridView.Rows[i].Selected)
                    {
                        var id = ShowAddressGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Id", id)
                        };

                        var command = "delete from Address where Id = @Id;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) ShowAddressGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void DeleteTelBtn_Click(object sender, EventArgs e)
        {
            if (ShowTelephoneGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < ShowTelephoneGridView.Rows.Count; i++)
                {
                    if (ShowTelephoneGridView.Rows[i].Selected)
                    {
                        var id = ShowTelephoneGridView[0, i].Value;

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Id", id)
                        };

                        var command = "delete from Telephone where Id = @Id;";
                        var dataAccess = new DataAccess();
                        var result = dataAccess.ExecuteNonQuery(command, CommandType.Text, parameters);

                        ResultLabel.Text = result ? "Deleted successfully!" : "Delete didn't work...";

                        if (result) ShowTelephoneGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var dataAccess = new DataAccess();
            var searchName = "";
            var searchCity = SearchCity.Text;
            var searchContactType = "";

            if (SearchName.Text != "") searchName = $"%{SearchName.Text}%";

            if (SearchContactType.SelectedItem != null) searchContactType = SearchContactType.SelectedItem.ToString();

            SqlParameter[] parameters = {
                new SqlParameter("@Name", searchName),
                new SqlParameter("@City", searchCity),
                new SqlParameter("@ContactType", searchContactType)
            };

            var cmdText = "select c.Id, c.Name, ct.Type from Contact c " +
                          "left join Contact_Address ca on ca.ContactId = c.Id " +
                          "left join Address a on a.Id = ca.AddressId " +
                          "left join ContactType ct on ct.Id = c.ContactTypeId " +
                          "where c.Name like @Name " +
                          "or a.City like @City " +
                          "or ct.Type = @ContactType;";

            var contacts = dataAccess.ExecuteSelectCommand(cmdText, CommandType.Text, parameters);

            ContactDataGridView.DataSource = contacts.Tables[0];

            ShowAddressGridView.Columns.Clear();
            ShowEmailGridView.Columns.Clear();
            ShowTelephoneGridView.Columns.Clear();
        }

        private void AddressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)ContactDataGridView[0, e.RowIndex].Value;
            contactId = int.Parse(id.ToString());

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

        private void ClearResultLabel(object sender, DataGridViewCellEventArgs e)
        {
            ClearResultLabel();
        }

        private void ClearSearchBtn_Click(object sender, EventArgs e)
        {
            LoadAddressBook();
            ShowAddressGridView.Columns.Clear();
            ShowEmailGridView.Columns.Clear();
            ShowTelephoneGridView.Columns.Clear();
            SearchContactType.SelectedItem = null;
        }



        #endregion


    }
}
