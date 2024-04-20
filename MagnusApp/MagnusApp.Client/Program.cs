global using MagnusApp.Shared.Services.EmailService;
global using MagnusApp.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MimeKit;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

await builder.Build().RunAsync();
