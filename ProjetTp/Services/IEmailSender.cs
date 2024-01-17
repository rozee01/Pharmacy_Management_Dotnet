namespace ProjetTp.Services
{
    public interface IEmailSender
    {
        public Task<bool> SendEmailAsync(string email, string subject, string confirmLink);
    }
}
