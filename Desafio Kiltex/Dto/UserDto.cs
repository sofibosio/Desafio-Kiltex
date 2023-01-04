namespace Desafio_Kiltex.Dto
{
	//Creo clase para el metodo GET para pasarle el Id, Name y UserName 
	public class UserDto
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public String UserName { get; set; }// maximo 100 caracteres
		
	
	}
}
