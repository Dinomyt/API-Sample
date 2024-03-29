var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


app.MapGet("/hello", (string firstName)=>
{
    return "Hello " + firstName;
});


app.MapGet("/addTwo", (int x, int y) =>
{
    return $"The sum of {x} + {y} is: {x + y}";
});

app.MapGet("/wokeUp", (string name, string wakeUp)=>
{
    return $"{name} woke up at {wakeUp}";
});

app.MapGet("/comparison", (int x, int y) =>
{
    if (x == y)
    {
        return $"{x} is equal to {y}";
    }
    else if (x > y)
    {
        return $"{x} is greater than {y}\n{y} is less than {x}";
    }
    else
    {
        return $"{x} is less than {y}\n{y} is greater than {x}";    
    }    
});


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
