using BibliotekaAPI.Data;
using BibliotekaAPI.Repositrory;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBibliotekaRepository, BibliotekaRepository>();
builder.Services.AddScoped<IRabbitMqSender, RabbitMqSender>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<BibliotekaContext>(options =>
{
    var connectionString = "Server=localhost;Database=BibliotekaAPI;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False";
    options.UseSqlServer(connectionString);
});
    var app = builder.Build();

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

