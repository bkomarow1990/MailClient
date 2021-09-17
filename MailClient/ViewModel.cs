using EAGetMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailClient
{
    public class ViewModel
    {
        public string Mail { get; set; }
        public MailServer MailServer { get; set; }
        public string Password { get; set; }
        public EAGetMail.MailClient MailClient { get; set; }
        public void Init(string mail, string password) {
            try {
                MailServer server = new MailServer(
                    "imap.gmail.com",
                    mail,
                    password,
                    ServerProtocol.Imap4)
                {
                    SSLConnection = true,
                    Port = 993
                };

               MailClient = new EAGetMail.MailClient("TryIt"); // trial version
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public ViewModel()
        {

        }
    }
}
