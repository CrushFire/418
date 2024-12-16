using Application.Services;
using AutoMapper;
using Core.Mappers;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Mappers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Core.Mappers.AutoMapper));

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AnalisService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<HumanService>();
builder.Services.AddScoped<AnamnesService>();
builder.Services.AddScoped<TreatmentService>();
builder.Services.AddScoped<PlaceService>();
builder.Services.AddScoped<WardService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Убедитесь, что строка подключения указана в appsettings.json

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
//    c.OperationFilter<FileUploadOperationFilter>(); // Обработчик для корректной работы с файлами
//});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
