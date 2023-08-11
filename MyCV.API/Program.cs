using MyCV.API;
using MyCV.Infrastructure;
using MyCV.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
				.AddInfrastructure(builder.Configuration)
				.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCV.Api v1"));
	//For now I will work witoout DataBase, uncomment this line to create DataBase
	//app.ApplyMigrations(); 
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});


app.Run();
