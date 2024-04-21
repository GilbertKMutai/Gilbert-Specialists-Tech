global using MagnusApp.Shared.Services.EmailService;
global using MagnusApp.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MimeKit;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Configuration;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Gets values from appsettings.json
//var clientSecret = builder.Configuration.GetValue<string>("MailSettings:EmailHost");

await builder.Build().RunAsync();
