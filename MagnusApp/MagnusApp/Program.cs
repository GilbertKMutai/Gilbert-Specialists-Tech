using MagnusApp.Client.Pages;
using MagnusApp.Components;

using Microsoft.OpenApi.Models;
using MagnusApp.Shared.Configuration;
using MagnusApp.Repositories.EmailRepository;
using MagnusApp.Shared.Services.EmailService;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using MagnusApp.Data;
using MagnusApp.Components.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Syncfusion.Blazor;

    //IAmazonSecretsManager secretsManager = new AmazonSecretsManagerClient(Amazon.RegionEndpoint.AFSouth1);
    //var request = new GetSecretValueRequest
    //{
    //    SecretId = "Authentication_Google_ClientSecret"
    //};
    //var ClientSecret = await secretsManager.GetSecretValueAsync(request);

    //var idrequest = new GetSecretValueRequest
    //{
    //    SecretId = "Authentication_Google_ClientId"
    //};
    //var ClientId = await secretsManager.GetSecretValueAsync(idrequest);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();
//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIzMDA3M0AzMjM1MmUzMDJlMzBMbjBGM3E0WHV1UnZNazVLWXFXaVljbk1WRk5JMEZCUFAwTS9wT1RWSTIwPQ==");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI1NTE0NEAzMjM1MmUzMDJlMzBJa1RRdFUzWXl4NHBCYU1pMFExMW9PUFlVWHNBZzFJRlFrNHlQa21qTzVzPQ==");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


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

//Contact Email form 
builder.Services.AddSingleton<IMailSettings, MailSettings>();

//Identity registration
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddGoogle(options =>
{
    bool isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";
    if (isProduction)
    {
        //options.ClientId = ClientId.SecretString;
        //options.ClientSecret = ClientSecret.SecretString;
    }
        options.ClientId = builder.Configuration.GetValue<string>("Google:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("Google:ClientSecret")!;
})
.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("MagnusDbConnection") ?? throw new InvalidOperationException("Connection string 'MagnusDbConnection' not found.");
builder.Services.AddDbContext<MagnusAppDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<MagnusAppDbContext>()
      .AddSignInManager()
      .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

//builder.Services.AddAntiforgery(options =>
//{
//    options.SuppressXFrameOptionsHeader = true;
//});

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
    app.UseMigrationsEndPoint();
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

// Add additional endpoints required by the  Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
