namespace Music.Web.Utilities.Contracts
{
    public interface IEmailSender
    {

        void send(string to, string subject, string body);


    }
}
