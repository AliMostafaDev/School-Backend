using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using School.API.Data;
using School.API.Interfaces;
using School.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);       // Added By Me

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Added By Me

builder.Services.AddScoped<IStudentRepository, StudentRepository>();         // Added By Me
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();   // Added By Me
builder.Services.AddScoped<IClassRepository, ClassRepository>();             // Added By Me
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();         // Added By Me


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
