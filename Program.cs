
using cheat_sheat_creater_api.Models;
using cheat_sheat_creater_api.Services;

var builder = WebApplication.CreateBuilder(args);

var  CorsOrigins = "_CorsOrigins";
builder.Services.AddCors(options => {
   options.AddPolicy(name: CorsOrigins, builder =>
        {
             builder.WithOrigins("https://*.vercel.app")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
        });
});

// Database Connection Configuration
builder.Services.Configure<DatabaseSettings>( 
    builder.Configuration.GetSection("MongoDatabase"));
// Database Connection Service
builder.Services.AddSingleton<SheetService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
