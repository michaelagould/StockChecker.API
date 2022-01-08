using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using StockChecker.API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://localhost:5001";
        options.ApiName = "StockCheckerApi";
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = @"Server=.;Database=StockCheckerDB;Trusted_Connection=True;ConnectRetryCount=0";
builder.Services.AddDbContext<StockContext>(options => options.UseSqlServer(connection));
//builder.Services.AddTransient<DbContext, StockContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
