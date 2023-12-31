using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using practice.Model;
using practice.Repo;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;
using practice.Services.SearchObjects;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type=Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme="basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="basicAuth"}
            },
            new string[]{ }
        }
    });
});


builder.Services.AddAutoMapper(typeof(ProfileMapper));

builder.Services.AddTransient<IKorisnikService,KorisnikService>();
builder.Services.AddTransient<IUlogeService,UlogeService>();
builder.Services.AddTransient<IPriceService,PriceService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PracticeContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

Console.WriteLine("before code....");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PracticeContext>();
    context.Database.EnsureCreated();
    if (!context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
        Console.WriteLine("migrated");
    }
    else { Console.WriteLine("not migrated"); }
}

Console.WriteLine("after code...");

app.Run();
