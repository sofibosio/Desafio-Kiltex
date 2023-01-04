using System.ComponentModel.DataAnnotations;
namespace Desafio_Kiltex.Models;

//Creo la clase User para crear la base de datos
public partial class User
{
	
	[Display(Name= "Id")]
    public int Id { get; set; }

	[Display(Name = "Nombre")]
	[MaxLength(200)]
	[StringLength(200)]
	public string? Name { get; set; }

	[MaxLength(100)]
	[StringLength(100)]
	[Display(Name = "Nombre de Usuario")]
	public string? UserName { get; set; }

	[MaxLength(100)]
	[StringLength(100)]
	[Display(Name = "Contraseña")]
	public string? Password { get; set; }
	
}
