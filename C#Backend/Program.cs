var builder = WebApplication.CreateBuilder(args);

//Add CORS services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("https://4200") //Allows Angular's dev server
              .AllowAnyHeader() // Allow all headers 
              .AllowAnyMethod(); // Allow all HTTP methods (Get, Post, etc)
    });
});

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Use the CORS middleware with the specified policy
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.MapControllers();



app.Run();
