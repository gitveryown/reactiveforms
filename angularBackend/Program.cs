var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection()
app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();