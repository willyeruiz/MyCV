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
	//Commands to run migrations:
	//dotnet ef migrations add InitialCreate --project MyCV.Infrastructure --startup-project MyCV.API -o Persistence/Migrations
	 //In order to update the database, run the following command:
	 //dotnet ef database update -p MyCV.Infrastructure -s MyCV.API
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});


app.Run();
