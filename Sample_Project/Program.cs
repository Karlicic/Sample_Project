using Microsoft.EntityFrameworkCore;
using Sample_Project.Model;
using Sample_Project.Settings;
using System.Text.Json.Serialization;
using VDS.RDF;
using VDS.RDF.Storage.Management;
using VDS.RDF.Storage.Management.Provisioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration["AppSettings:ConnectionString"]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(AppSettings.AppDetails));

Options.HttpDebugging = true;

const string SERVER_URL = "http://localhost:5820";
const string STARDOG_USERNAME = "admin";
const string STARDOG_PASSWORD = "admin";
const string DATABASE_NAME = "MyDb";

using (StardogServer stardog = new StardogServer(SERVER_URL, STARDOG_USERNAME, STARDOG_PASSWORD))
{
    if(stardog.ListStores().Contains(DATABASE_NAME))
    {
        stardog.DeleteStore(DATABASE_NAME);
    }

    IStoreTemplate template = stardog.GetDefaultTemplate(DATABASE_NAME);
    stardog.CreateStore(template);
}

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
