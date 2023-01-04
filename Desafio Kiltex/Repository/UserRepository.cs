using Desafio_Kiltex.Dto;
using Desafio_Kiltex.Interfaces;
using Desafio_Kiltex.Data;
using Desafio_Kiltex.Models;

namespace Desafio_Kiltex.Repository
{
	public class UserRepository : IUser
	{
		private readonly UserContext _context;

		public UserRepository(UserContext context)
		{
			_context = context;
		}

		public bool CreateUser(User User)
		{
			_context.Add(User);
			return Save();
		}

		public bool DeleteUser(User User)
		{
			_context.Remove(User);
			return Save();
		}

		public User GetUser(int id)
		{
			return _context.Users.Where(u => u.Id == id).FirstOrDefault();
		}

		public User GetUser(string name)
		{
			return _context.Users.Where(u => u.Name == name).FirstOrDefault();
		}

		public ICollection<User> GetUsers()
		{
			return _context.Users.OrderBy(u => u.Id).ToList();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool UpdateUser(User user)
		{
			_context.Update(user);
			return Save();
		}

		public bool UserExists(int id)
		{
			return _context.Users.Any(u => u.Id == id);
		}
	}
}