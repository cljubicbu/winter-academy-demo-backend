using GDi.WinterAcademy.Demo.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WinterAcademyDemoDbContext>(configure => configure.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
{
    options.MigrationsAssembly(typeof(WinterAcademyDemoDbContext).Assembly.FullName);
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<WinterAcademyDemoDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(options =>
{
options.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(_ => true)
.AllowCredentials();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
