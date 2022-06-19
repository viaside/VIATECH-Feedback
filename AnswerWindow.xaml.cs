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
using Npgsql;
using System.Data;
using System.Net.Mail;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace VIATECH_Feedback
{
    /// <summary>
    /// Логика взаимодействия для AnswerWindow.xaml
    /// </summary>
    public partial class AnswerWindow : Window
    {
        private string User_Name;
        private string Send_Message;
        private string User_EMail;

        public AnswerWindow()
        {
            InitializeComponent();
        }

        public void LoadData(string us_name, string us_email)
        {
            User_Name = us_name;
            User_EMail = us_email;
            id.Content = User_EMail;
            name.Content = User_Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Send_Message = Message_mail.Text;
            MessageBox.Show($"Name - {User_Name} ,Email - {User_EMail}, Message - {Send_Message}");
            Send_Email();
        }

        private void Send_Email()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("viaside15yo@yandex.ru", "ivan");
            // кому отправляем
            MailAddress to = new MailAddress(User_EMail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "From VIAtech Feedback";
            // текст письма
            m.Body = Send_Message;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.yandex.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("viaside15yo@yandex.ru", "zxxVanek1");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
