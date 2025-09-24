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
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// FluentValidation setup
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<LoginRequest>, ValidatorLogin>();
builder.Services.AddScoped<IValidator<DtoChangePassword>, ValidatorChangePassword>();
builder.Services.AddScoped<IValidator<DtoMeetingSlotRequest>, ValidatorMeetingSlotRequest>();
builder.Services.AddScoped<IValidator<DtoMeetingLinkRequest>, ValidatorMeetingLinkRequest>();
builder.Services.AddScoped<IValidator<DtoCreateUser>, ValidatorCreateUser>();
builder.Services.AddScoped<IValidator<DtoUpdateUser>, ValidatorUpdateUser>();
builder.Services.AddScoped<IValidator<DtoRole>, ValidatorRole>();

// Register services and repositories
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IMeetingRepository,MeetingRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClients", policy =>
    {
        //policy.WithOrigins("http://192.168.100.55:4200", "http://localhost:4200")
        policy.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
               //.AllowCredentials(); 
    });
});

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
                    Encoding.UTF8.GetBytes(jwtSettings["Key"])),
            NameClaimType = ClaimTypes.Name
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
app.UseCors("AllowAngularClients");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
