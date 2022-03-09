using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus;
using azlearn_app.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAzureClients(az => {
    az.AddServiceBusClient(builder.Configuration.GetConnectionString("AzureServiceBus"))
    .WithName("sb-azlearn")
    .ConfigureOptions(opt=>{
        opt.RetryOptions=new ServiceBusRetryOptions{
            Mode=ServiceBusRetryMode.Fixed,
            MaxRetries = 100
        };
    });
});
builder.Services.AddSingleton<AzLearnSender>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
