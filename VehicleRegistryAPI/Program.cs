using Data;
using Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB to use the correct GuidRepresentation
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// Add services to the container.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();

builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();

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

