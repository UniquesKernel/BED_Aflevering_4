using Assignment4.Services;
using System.Net;
using Microsoft.AspNetCore.HttpLogging;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.RequestHeaders.Add(":method");
    logging.RequestHeaders.Add("Request");
    logging.MediaTypeOptions.AddText("application/json");
});

builder.Services.AddSingleton<HeartstoneService>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(option =>
{
    option.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    option.HttpsPort = 5000;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
