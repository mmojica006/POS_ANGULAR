using POS.Api.Extensions;
using POS.Application.Extensions;
using POS.Infrastructure.Extensions;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.

var Cors = "Cors";


builder.Services.AddInjectionInfraestructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);

builder.Services.AddAuthentication(Configuration);
builder.Services.AddSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors, builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();



app.UseCors(Cors);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

//Hacer uso de un middleware para hacer la atentication correctamente

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(configuration =>
{
    configuration.WatchPageUsername = Configuration.GetSection("WatchDog:Usermame").Value;
    configuration.WatchPagePassword = Configuration.GetSection("WatchDog:Password").Value;
});

app.Run();
public partial class Program { }
