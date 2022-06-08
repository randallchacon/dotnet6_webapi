using dotnet6_webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//it's a dependency

/*Dependency injection with scoped, transient or singleton. Most recommended scoped for stateless*/
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService()); //I can pass parameters 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//not recommended for production enviroment
{
    app.UseSwagger(); //middleware
    app.UseSwaggerUI(); //middleware
}

app.UseHttpsRedirection();  //middleware

app.UseAuthorization(); //middleware

//app.UseWelcomePage(); //middleware

//app.UseTimeMiddleware();

app.MapControllers(); //middleware

app.Run();

//all middlewares must be in order
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0

