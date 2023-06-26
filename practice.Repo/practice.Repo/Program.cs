using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(IKorisnikService));
builder.Services.AddTransient<IPriceService,PriceService>();
builder.Services.AddTransient<IKorisnikService,KorisnikService>();
builder.Services.AddTransient<IUlogeService,UlogeService>();
builder.Services.AddTransient<IBService<MKorisnici>,BaseService<MKorisnici,Korisnici>>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PracticeContext>(options=>options.UseSqlServer(connectionString));

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
