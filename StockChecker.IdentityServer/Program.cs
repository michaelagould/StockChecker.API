using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using StockChecker.IdentityServer.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryClients(IdentityServerHelper.GetClients())
    .AddInMemoryApiScopes(IdentityServerHelper.GetApiResources())
    .AddTestUsers(IdentityServerHelper.GetUsers())
    .AddInMemoryIdentityResources(new List<IdentityResource>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseIdentityServer();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
