using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI
{
    public partial class NewContact : Form
    {
        Contact contact = new Contact();

        public NewContact()
        {
            InitializeComponent();
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
        }

        private void CreateContactBtn_Click(object sender, EventArgs e)
        {

            FormState.PreviousPage.Show();
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

        }

        private void AddEmailBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
