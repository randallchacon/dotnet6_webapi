var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //middleware
    app.UseSwaggerUI(); //middleware
}

app.UseHttpsRedirection();  //middleware

app.UseAuthorization(); //middleware

//app.UseWelcomePage(); //middleware

app.UseTimeMiddleware();

app.MapControllers(); //middleware

app.Run();

//all middlewares must be in order
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0

