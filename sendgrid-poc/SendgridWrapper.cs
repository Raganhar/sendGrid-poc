using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace sendgrid_poc;

public class SendgridWrapper
{
    public async Task<Response> SendMail()
    {
        var apikey = JsonConvert.DeserializeObject<SecretStuff>(File.ReadAllText("credentials.json"));
        var client = new SendGridClient(apikey.ApiKey);
        var from = new EmailAddress(apikey.SenderEmail, "Example User");
        var to = new EmailAddress(apikey.RecieverEmail, "Example User");
        // var subject = "Sending with SendGrid is Fun";
        // var plainTextContent = "and easy to do anywhere, even with C#";
        // var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        // var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-5f1a9c59d13747edbf340c81a62942ab",
            new {name="Nicklas", auctionList = new List<AuctionItemForEmail>{new AuctionItemForEmail
            {
                url = "google.dk",
                Title = "mega fed mazda"
            }} });
        var response = await client.SendEmailAsync(msg);
        return response;
    }
}

public class AuctionItemForEmail
{
    public string Title { get; set; }
    public string url { get; set; }
}