using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NitroSongs.Infrastructure.Extensions;
using NitroSongs.Infrastructure.Persistence.Contexts;
using NitroSongs.Infrastructure.Persistence.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCortexMediator(builder.Configuration, [typeof(NitroSongs.ApplicationLayer.Extensions.ServiceResponseExtensions)]);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<INitroSongContext>();

    if (db is DbContext context)
    {
        context.Database.Migrate();
        var songContext = context as NitroSongsDbContext;
        await DataSeeder.SeedAsync(songContext!);
    }
}

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
