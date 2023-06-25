using Application;
using Data;
using MediatR;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using DataAccess.Repositoies.StudentRepository;
using FluentValidation.AspNetCore;
using DataAccess.Repositoies;
using FluentValidation;
using Application.Validators.StudentValidators;
using Application.Commands.StudentCommands.CreateStudent;
using Application.Commands.StudentCommands.UpdateStudent;
using AutoWrapper;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddMediatR(typeof(AppicationEntryPoint).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateStudentRequest>, CreateStudentValidator>();
builder.Services.AddScoped<IValidator<UpdateStudentRequest>, UpdateStudentValidator>();
builder.Services.Configure<MvcJsonOptions>(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<IISOptions>(options =>
{
    options.ForwardClientCertificate = false;
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IStudentRepository,StudentRepository>();

var app = builder.Build();
app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { ShowIsErrorFlagForSuccessfulResponse = true });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
