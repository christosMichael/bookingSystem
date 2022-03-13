using Microsoft.EntityFrameworkCore;
using test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection string.
// Make sure to update the Password value below from "Your_password123" to your actual password.
var connectionString = "Server=localhost;User=admin;Password=root";

// This line uses 'UseSqlServer' in the 'options' parameter
// with the connection string defined above.

builder.Services.AddDbContext<ApplicationDbContext>(
    options => {
        options.UseNpgsql(connectionString);
    });

var app = builder.Build();



//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddMvc();

// Add application services.
//builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
//builder.services.addtransient<ismssender, authmessagesender>();

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
