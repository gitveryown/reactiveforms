var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
});

builder.Services.AddControllers();

var app = builder.Build();


app.UseCors("AllowAngularApp");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();