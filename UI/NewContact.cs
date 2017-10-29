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
            var id = InsertContact();

            InsertTelephone(id);

            FormState.PreviousPage.Show();
            Close();

            //var addressBook = new AddressBook();
            //addressBook.LoadAddressBook();
        }

        private int InsertContact()
        {
            var dataAccess = new DataAccess();
            var name = NewFirstNameTxtBox.Text + " " + NewLastNameTxtBox.Text;

            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Type", NewTypeComboBox.SelectedItem.ToString())
            };

            var cmdText = "insert into Contact (Name, ContactType) " +
                          "values (@Name, @Type) ";

            dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);

            var cmd = "select top(1) Id from Contact order by Id desc";

            var contacts = dataAccess.ExecuteSelectCommand(cmd, CommandType.Text, null);

            var id = contacts.Tables[0].Rows[0]["Id"].ToString();

            return int.Parse(id);
        }

        private void InsertAddress(int id)
        {
            
        }

        private void InsertTelephone(int id)
        {
            var dataAccess = new DataAccess();

            foreach (var item in contact.Telephones)
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@CountryCode", item.CountryCode),
                    new SqlParameter("@DiallingCode", item.DiallingCode),
                    new SqlParameter("@TelephoneNumber", item.TelephoneNumber)
                };

                var cmdText = "insert into Telephone (CountryCode, DiallingCode, TelephoneNumber, ContactId) " +
                              $"values (@CountryCode, @DiallingCode, @TelephoneNumber, {id})";

                dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);
            }
        }

        private void InsertEmail(int id)
        {
            var dataAccess = new DataAccess();

            foreach (var item in contact.Email)
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@Email", item.Email)

                };

                var cmdText = "insert into Email (Email, ContactId) " +
                              $"values (@Email, {id})";

                dataAccess.ExecuteNonQuery(cmdText, CommandType.Text, parameters);
            }
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
