using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using System.Text;
using TrainLink.DataAccess;
using TrainLink.Repositories;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services;
using TrainLink.Services.Interfaces;
using FluentValidation;
using TrainLink.Dtos;
using TrainLink.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// FluentValidation setup
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<DtoLogin>, ValidatorLogin>();
builder.Services.AddScoped<IValidator<DtoChangePassword>, ValidatorChangePassword>();
builder.Services.AddScoped<IValidator<DtoMeetingSlotCreate>, ValidatorMeetingSlotCreate>();
builder.Services.AddScoped<IValidator<DtoMeetingSlotUpdate>, ValidatorMeetingSlotUpdate>();
builder.Services.AddScoped<IValidator<DtoMeetingSlotDelete>, ValidatorMeetingSlotDelete>();

// Register services and repositories
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IMeetingRepository,MeetingRepository>();

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });

builder.Services.AddAuthorization();
// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
