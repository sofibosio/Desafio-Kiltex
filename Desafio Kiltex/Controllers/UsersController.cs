using Desafio_Kiltex.Models;
using Desafio_Kiltex.Dto;
using Microsoft.AspNetCore.Mvc;
using Desafio_Kiltex.Data;
using Desafio_Kiltex.Repository;
using Desafio_Kiltex.Interfaces;
using AutoMapper;
using System.Collections.Generic;

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
			using (UserContext db = new UserContext())
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

		//Metodo POST devuelve true si el name, UserName y Password existe en la BD si no lo crea y lo guarda
		[HttpPost]
		[Route("NewUser")]
		public IActionResult CreateUser([FromBody] NewUser user)
		{
			if (user.Name == null || user.UserName == null || user.Password == null)
				return StatusCode(200, false);

			using (UserContext db = new UserContext())
			{
				var lst = (from u in db.Users
						   where u.Name == user.Name && u.UserName == user.UserName && u.Password == user.Password
						   select new NewUser
						   {
							   Name = u.Name,
							   UserName = u.UserName,
							   Password = u.Password
						   }).ToList();

				User us = new User();

			//Utilizo Any para verificar que los datos esten en la BD, en le caso de que este devuelve true sino crea un nuevo usuario
				if (lst.Any())
				{ 
					return StatusCode(200, true + ", El Usuario ya existe");
				}
				else
				{
					us.Name = user.Name;
					us.UserName = user.UserName;
					us.Password = user.Password;
					_dbcontext.Users.Add(us);
					_dbcontext.SaveChanges();

					return Ok("El Usuario fue creado con exito!!");
				}

				
			}

		}



		//Metodo POST devuelve true si el UserName y el Password existe en la base de datos si no devuelve false
		[HttpPost]
		[Route("UserRequest")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public IActionResult UserRequest([FromBody] UserFiltrado user)
		{
			if (user.UserName == null || user.Password == null)
				return StatusCode(200, false);

			using (UserContext db = new UserContext())
			{

				var lst = (from u in db.Users
						   where u.UserName == user.UserName && u.Password == user.Password
						   select new UserFiltrado
						   {
							   UserName = u.UserName,
							   Password = u.Password
						   }).ToList();

				if (!lst.Any())
				{
					return StatusCode(200, false);
				}
				else
				{
					return StatusCode(200, true + ", el userName y Password existe");
				}
					


			}
		}

		
	}
}