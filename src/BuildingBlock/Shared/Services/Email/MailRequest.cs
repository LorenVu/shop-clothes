using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BuildingBlock.Shared.Services.Email;


public class MailRequest
{
    [EmailAddress]
    public string From { get; set; }
    
    [EmailAddress]
    public string ToAddress { get; set; }

    public IEnumerable<string> ToAddresses { get; set; } = [];
    
    public string Subject { get; set; }
    
    public string Body { get; set; }
    
    public IFormFileCollection Attachments { get; set; } = null;
}