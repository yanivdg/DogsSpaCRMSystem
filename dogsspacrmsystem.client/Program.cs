using DogsSpaCRMSystem.Server.Data;
using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using DogsSpaCRMSystem.Server.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle;
//*******sql server*************

var config = builder.Configuration;
string sqlConnectionString = config.GetConnectionString("SqlServerConnection") ?? "";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(sqlConnectionString));


builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false; // if not using endpoint routing
});

//
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false; // if not using endpoint routing
});
//controller - 
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My nextjs .core App",
        Version = "v1",
        Description = "My nextjs .core App"
    });
    // Add security options if needed
});

//

//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging();
builder.Services.AddLogging(options =>
{
    options.AddConsole();
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder
            .AllowAnyOrigin() // Replace with specific origins if needed
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");
app.MapControllers();
app.UseHttpsRedirection();

app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();

