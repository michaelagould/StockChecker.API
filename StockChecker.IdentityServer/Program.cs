using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using StockChecker.IdentityServer.Helpers;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

X509Certificate2 x509Certificate2 = null;
using (var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
{
    certStore.Open(OpenFlags.ReadOnly);
    var certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint,"091FDE8E35C5AD8A7A39AEC05753144EA3071AC7",false);
    if (certCollection.Count == 0)
        throw new Exception("No certificate found");
    x509Certificate2 = certCollection[0];
}

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentityServer()
    //.AddDeveloperSigningCredential()
    .AddSigningCredential(x509Certificate2)
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
