using Desafio_Kiltex.Dto;
using Desafio_Kiltex.Models;
namespace Desafio_Kiltex.Interfaces
{
	public interface IUser
	{
		ICollection<User> GetUsers();
		User GetUser(int Id);
		User GetUser(string Name);
		bool UserExists(int Id);
		bool CreateUser(User User);
		bool UpdateUser(User User);
		bool DeleteUser(User User);
		bool Save();
	}
}