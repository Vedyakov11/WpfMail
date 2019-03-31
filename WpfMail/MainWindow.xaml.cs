using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WpfMail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "vedyakov11@gmail.com", "vedyakov11@yandex.ru" }; // Список email'ов //кому мы отправляем письмо
            string strPassword = passwordBox.Password;

            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage
                using (MailMessage mm = new MailMessage("vedyakov11@yandex.ru", mail))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#"; // Заголовок письма
                    mm.Body = "Hello, world!"; // Тело письма
                    mm.IsBodyHtml = false; // Не используем html в теле письма

                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("vedyakov11@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
