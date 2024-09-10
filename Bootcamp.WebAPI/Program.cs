using Bootcamp.Data;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EngagementDbContext>(options =>
    options.UseSqlServer(
    "Server=PUDHANASHRIJADH;Database=LevviaBootcamp2;Trusted_Connection=true;TrustServerCertificate=true",
                    x => x.MigrationsAssembly("Bootcamp.Migrations")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IEngagementRepository, EngagementRepository>();

var app = builder.Build();

app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

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
