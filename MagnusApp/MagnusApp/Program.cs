using MagnusApp.Client.Pages;
using MagnusApp.Components;
using Syncfusion.Blazor;
using Microsoft.OpenApi.Models;
using MagnusApp.Shared.Configuration;
using MagnusApp.Repositories.EmailRepository;
using MagnusApp.Shared.Services.EmailService;
using Microsoft.AspNetCore.Http.Extensions;


var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIzMDA3M0AzMjM1MmUzMDJlMzBMbjBGM3E0WHV1UnZNazVLWXFXaVljbk1WRk5JMEZCUFAwTS9wT1RWSTIwPQ==");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddControllers();

builder.Services.AddScoped<IEmailRepository, EmailRepository>();

builder.Services.AddHttpClient<IEmailService, EmailService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUri")!);
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Example API",
        Version = "v1",
        Description = "An example of an ASP.NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Email = "example@example.com",
            Url = new Uri("https://localhost:44398/api/mail"),
        },
    });
});


builder.Services.AddSingleton<IMailSettings, MailSettings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MagnusApp.Client._Imports).Assembly);

app.Run();
