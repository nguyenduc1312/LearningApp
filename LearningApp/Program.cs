using LearningApp.Application.Features.Common;
using LearningApp.Application.Features.Subject.Commands;
using LearningApp.Application.Profiles;
using LearningApp.Infrastructure.Data;
using LearningApp.Infrastructure.Repositories;
using LearningApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddAutoMapper(typeof(IBaseProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IBaseCommand).Assembly));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
