using fleet_of_knowledge.Models;
using fleet_of_knowledge.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MovieStoreDatabaseSettings>(builder.Configuration.GetSection("MovieStoreDatabase"));

// Add services to the container.
builder.Services.AddSingleton<MovieService>(); // TO-DO: replace for the service 

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

app.UseStaticFiles();

app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI"); c.InjectStylesheet("swagger-ui/SwaggerDark.css"); });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

