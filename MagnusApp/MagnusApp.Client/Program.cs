using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MimeKit;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Configuration;
using MagnusApp.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

await builder.Build().RunAsync();
