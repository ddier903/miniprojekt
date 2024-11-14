using System.Net.Http;
using WebApp1.Components;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient for use in your application
builder.Services.AddHttpClient();

// Add Razor components (for Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


