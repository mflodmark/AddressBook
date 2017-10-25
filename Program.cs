using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.UI;

namespace AddressBook
{

    static class Program
    {
        public static bool OpenSecondFormOnClose { get; set; }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AddressBook());

            OpenSecondForm();
        }

        private static void OpenSecondForm()
        {
            if (OpenSecondFormOnClose)
            {
                Application.Run(new NewContact());
            }

            OpenSecondFormOnClose = false;
        }
    }
}
