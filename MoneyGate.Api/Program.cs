using Microsoft.EntityFrameworkCore;
using MoneyGate.Api.Data;
using MoneyGate.Api;
using MoneyGate.Api.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString,
        optionsBuilder =>
        {
            optionsBuilder.EnableRetryOnFailure();
            optionsBuilder.MigrationsAssembly("MoneyGate.Api");
        });
});

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddScoped<ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.MapControllers();
app.UseHttpsRedirection();

SeedData.Initialize(app);
app.Run();