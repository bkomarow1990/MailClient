using EAGetMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailClient
{
    /// <summary>
    /// Interaction logic for MailForm.xaml
    /// </summary>
    public partial class MailForm : Window
    {
        ViewModel viewModel;
        public MailForm(ViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            try
            {
                viewModel.MailClient.Connect(viewModel.MailServer);

                // show all folders
                foreach (var f in viewModel.MailClient.GetFolders())
                {
                    //Console.WriteLine(f.Name);
                    categoriesListBox.Items.Add(f);
                    categoriesListBox.DisplayMemberPath = nameof(Imap4Folder.Name);
                    //foreach (var subF in f.SubFolders)
                    //{
                    //    Console.WriteLine("\t" + subF.Name);
                    //}
                }
                //Next
                // select Trash folder
                //client.SelectFolder(client.Imap4Folders[1].SubFolders[2]);

                // get mails in selected folder
                //MailInfo[] messages = client.GetMailInfos();
                messageListBox.ItemsSource = viewModel.MailClient.GetMailInfos();
                //messagesListBox.client.GetMailInfos();

                //foreach (var m in messages)
                //{
                //    Console.WriteLine($"Index: {m.Index}{Environment.NewLine}Size: {m.Size}\n");

                //    Mail message = client.GetMail(m);

                //    if (m.Index == 21)
                //    {
                //        // save attachment
                //        message.Attachments[0].SaveAs(message.Attachments[0].Name, true);
                //    }

                //    Console.WriteLine($"From: {message.From}\n\n\t{message.Subject}");
                //    Console.WriteLine($"Date: {message.SentDate}\tAttachments: {message.Attachments.Count()}");
                //    Console.WriteLine($"Body: {new string(message.TextBody.Take(50).ToArray())}...");
                //    Console.WriteLine("-----------------------------------------------------");
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
