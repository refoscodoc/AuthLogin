using System.Reflection;
using Auth_Validator_MediatR.DataAccess;
using Auth_Validator_MediatR.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var sqlConnectionString = builder.Configuration.GetConnectionString("DataAccessMySqlProvider");
var serverVersion = new MySqlServerVersion(new Version(10, 7, 3));

builder.Services.AddDbContext<UserContext>(options =>
    options.UseMySql(sqlConnectionString, serverVersion));

builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("corspolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();