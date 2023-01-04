using Desafio_Kiltex.Controllers;
using Desafio_Kiltex.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<UserContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hago conexion con la base de datos
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//Utilizo Swagger para documentar los servicios web REST
if (app.Environment.IsDevelopment()){
	
	app.UseSwagger();
	app.UseSwaggerUI();

}

app.UseAuthorization();

app.MapControllers();


app.Run();




