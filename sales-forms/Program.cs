using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<AppUser, AppRole>(options => { }).AddEntityFrameworkStores<FormDbContext>();

builder.Services.AddDbContext<FormDbContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("FormsDb");

    if (builder.Environment.IsDevelopment())
    {
        string relativePath = Path.Combine("Data", "Database.db");
        var parentdir = Directory.GetCurrentDirectory();
        string absolutePath = Path.Combine(parentdir, relativePath);
        connectionString = string.Format("Data Source={0};", absolutePath);
        options.UseSqlite(connectionString);
    }
    else
    {
        options.UseNpgsql(connectionString);
    }
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
