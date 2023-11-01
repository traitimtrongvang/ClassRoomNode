using Application;
using PrimaryDbPostgreSql;
using RestfulApi;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services
    // Drivens
    .AddPrimaryDbPostgreSql(config)
    
    // Application
    .AddApplicationServices()
    
    //Drivings
    .AddRestfulApiService();

var app = builder.Build();

app.UseRestfulApiConfigurations();

app.Run();