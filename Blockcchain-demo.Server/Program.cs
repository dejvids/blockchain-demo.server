using Blockcchain_demo.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blockchain_demo.Modules.Users.Api;
using Blockchain_demo.Shared.Database;
using Blockchain_demo.Modules.Transactions.Api;

const string localCorsPolicyName = "_local";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddCors(cors => cors.AddPolicy(localCorsPolicyName,
    config => config.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));

builder.Services.AddDbOptions(builder.Configuration);

builder.Services.AddUsersModule();
builder.Services.AddTransactionModule();

builder.Services.AddJwt(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSwagger();
app.MapGet("/", () => "Blockchain-demo web server");

//Modules API
app.AddUsersApi();
app.AddTransactionEndpoints();

app.UseCors(localCorsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerUI();

app.Run();
