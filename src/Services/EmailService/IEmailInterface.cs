﻿using mail_web_app.Models;

namespace mail_web_app.Services.EmailService
{
    public interface IEmailInterface
    {
        Task<EmailModel> SaveClientsData(EmailModel info);
        Task<List<EmailModel>> ListMails(string search = null);

        Task<EmailModel> ListMailsById(int id);

        bool SendEmail(string adressEmail, string subjectEmail, string textEmail);
    }
}
