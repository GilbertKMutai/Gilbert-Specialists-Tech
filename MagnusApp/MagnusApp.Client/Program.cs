using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MimeKit;
using MailKit.Net.Smtp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

var email = new MimeMessage();

email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));

email.Subject = "Testing out email sending";
email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
{
    Text = "Hello all the way from the land of c#"
};

using (var smtp = new SmtpClient())
{
    smtp.Connect("smtp.gmail.com", 587, false);

    // Note: only needed if the SMTP server requires authentication
    smtp.Authenticate("smtp_username", "smtp_password");

    smtp.Send(email);
    smtp.Disconnect(true);
}

await builder.Build().RunAsync();
