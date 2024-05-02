global using MagnusApp.Shared.Services.EmailService;
global using MagnusApp.Shared.Models;
global using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IEmailService, EmailService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

//Gets values from appsettings.json
//var clientSecret = builder.Configuration.GetValue<string>("MailSettings:EmailHost");

await builder.Build().RunAsync();
