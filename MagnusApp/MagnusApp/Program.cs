using MagnusApp.Client.Pages;
using MagnusApp.Components;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIzMDA3M0AzMjM1MmUzMDJlMzBMbjBGM3E0WHV1UnZNazVLWXFXaVljbk1WRk5JMEZCUFAwTS9wT1RWSTIwPQ==");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
