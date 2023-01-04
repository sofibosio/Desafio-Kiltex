using Desafio_Kiltex.Models;
using Desafio_Kiltex.Dto;
using Microsoft.AspNetCore.Mvc;
using Desafio_Kiltex.Data;


namespace Desafio_Kiltex.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private UserContext _dbcontext;

		public UsersController(UserContext context)
		{
			_dbcontext = context;
		}
		
		//Metodo get devuelve de la base de datos el Id, Name y UserName
		[HttpGet]
		[Route("AllUser")]
		public IActionResult ListarUser()
		{
		
			//utilizo el UserContext para buscar el Id, Name y UserName
			using(UserContext db = new UserContext())
			{
				List<UserDto> lista = new List<UserDto>();

				//hago una query para que traiga todos los datos que esten en la base de datos
				var lst = (from u in db.Users
						   select new UserDto
						   {
							   Id = u.Id,
							   Name = u.Name,
							   UserName = u.UserName

						   }).ToList();
				return Ok(lst);
			}
			
		}

		//Metodo POST devuelve true si el UserName y el Password existe en la base de datos si no devuelve false
		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public IActionResult CreateUser([FromBody] UserFiltrado user)
		{

			if (user.UserName == null && user.Password == null)
				return StatusCode(200, false); 

			else
			{
				//a la lista le paso el Users creado en userContext para verificar en la base de datos
				List<User> lista = _dbcontext.Users.ToList();
				foreach (User u in lista)
				{
				
					if(user.UserName == u.UserName && user.Password == u.Password)
					{
						return StatusCode(200, true + ", el userName y Password existe");
					}
				}
				return StatusCode(200, false);
			}

		}
	}
}
