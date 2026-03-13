using IdentityService.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

app.ConfigurePipeline();

//Apply any pending EF Core migrations before application start.
if (app.Environment.IsDevelopment())
    await app.InitAndRunAsync();
else
    await app.RunAsync();
