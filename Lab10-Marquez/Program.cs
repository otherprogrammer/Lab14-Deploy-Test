using Lab10_Marquez.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureServices();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();