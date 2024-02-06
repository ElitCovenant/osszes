using KonyvtarBackEnd.Dto;
namespace KonyvtarBackEnd.Service.IEmailServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
    }
}
