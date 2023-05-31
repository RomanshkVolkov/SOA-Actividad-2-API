using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.IServices;
using Service.Services;

var _MyCors = "MyCors";

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<HashHelperService>();
builder.Services.AddTransient<IPersona, PersonaServicio>();
builder.Services.AddTransient<IActivo, ActivoServicio>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAuth, AuthService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.RequireHttpsAttribute());

});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _MyCors,
               builder =>
               {
                   builder.WithOrigins("https://localhost:7027")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                   builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
               });
});


var app = builder.Build();

app.UseCors(_MyCors);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
