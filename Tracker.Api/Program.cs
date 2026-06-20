using Tracker.Api.Handlers;
using Tracker.Application.Events.Incoming;
using Tracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(IncomingEventHandler).Assembly);
});

// Configure app services

// Configure global exception handling
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Configure our custom services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Setup middleware
app.UseExceptionHandler();
app.UseHttpsRedirection();

// Setup controllers
app.MapControllers();

// Run the application
app.Run();
