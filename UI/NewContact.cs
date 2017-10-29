using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.DAL;

namespace AddressBook.UI
{
    public partial class NewContact : Form
    {
        Contact contact = new Contact();

        public NewContact()
        {
            InitializeComponent();

            AddItemsToComboBox();
        }

        private void AddItemsToComboBox()
        {
            NewTypeComboBox.Items.Add("Personlig");
            NewTypeComboBox.Items.Add("Jobb");
            NewTypeComboBox.Items.Add("Övrig");
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            Close();
        }

        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            var addContact = "insert into Contact (Name, ContactType) " +
                             "values (@Name, @Type) ";

            var name = NewFirstNameTxtBox.Text + " " + NewLastNameTxtBox.Text;

            InsertContact(addContact, name, NewTypeComboBox.SelectedItem.ToString());

            FormState.PreviousPage.Show();
            Close();
        }

        private bool InsertContact(string command, string name, string type)
        {
            var dataAccess = new DataAccess();
            var cmdText = command;

            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Type", type)
            };

            return dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);

        }

        private void AddAddressBtn_Click(object sender, EventArgs e)
        {
            var newAddress = new Address()
            {
                Street = NewStreetTextBox.Text,
                City = NewCityTextBox.Text,
                ZipCode = NewZipTextBox.Text
            };

            contact.Addresses.Add(newAddress);

            NewAddressGrid.DataSource = null;
            NewAddressGrid.DataSource = contact.Addresses;
        }

        private void AddTelBtn_Click(object sender, EventArgs e)
        {
            var newTel = new Telephone()
            {
                CountryCode = NewCountryTextBox.Text,
                DiallingCode = NewDiallingTextBox.Text,
                TelephoneNumber = NewTelNrTextBox.Text
            };

            contact.Telephones.Add(newTel);

            NewTelephoneGrid.DataSource = null;
            NewTelephoneGrid.DataSource = contact.Telephones;
        }

        private void AddEmailBtn_Click(object sender, EventArgs e)
        {
            var newEmail = new EmailAddress()
            {
                Email = NewEmailTextBox.Text
            };

            contact.Email.Add(newEmail);

            NewEmailGrid.DataSource = null;
            NewEmailGrid.DataSource = contact.Email;
        }
    }
}
