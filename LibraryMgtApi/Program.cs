using LibraryMgtApiApplication.Extensions;
using LibraryMgtApiApplication.Middlewares;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiInfrastructure.Extensions;
using LibraryMgtApiInfrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5594") // 👈 your test HTML origin
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // 👈 important for SignalR
    });
});




//Because we have signalR dependency installed in the Domain Layer
builder.Services.AddSignalR();

var app = builder.Build();

//For the seedeer
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ILibraryMgtSeeder>();
await seeder.seed();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapHub<NotificationHub>("/notificationHub");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
