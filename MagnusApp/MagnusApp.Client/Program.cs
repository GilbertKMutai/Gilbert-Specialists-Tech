global using MagnusApp.Shared.Services.EmailService;
global using MagnusApp.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MimeKit;
using MailKit.Net.Smtp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IEmailService, EmailService>();

await builder.Build().RunAsync();
