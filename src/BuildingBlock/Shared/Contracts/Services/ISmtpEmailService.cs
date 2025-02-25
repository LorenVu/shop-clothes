using BuildingBlock.Shared.Services.Email;

namespace BuildingBlock.Shared.Contracts.Services;

public interface ISmtpEmailService : IEmailService<MailRequest>
{
    
}