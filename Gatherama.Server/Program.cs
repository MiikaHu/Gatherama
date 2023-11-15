using Gatherama.Server.Models;
using Gatherama.Server.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<GatheramaDatabaseSettings>(
    builder.Configuration.GetSection("Gatherama"));
builder.Services.AddSingleton<PersonService>();
builder.Services.AddSingleton<MediaService>();
builder.Services.AddSingleton<FriendshipService>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddScoped(sp => new GatheramaDbContext("Replace with MongoDb connection string", "Replace with the name of your collection")); // Add your MongoDb Atlas connection string with the proper username and password and collection name
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5000") }); Can also be used locally but only for the windows version
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
