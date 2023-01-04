using Desafio_Kiltex.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Kiltex.Data;

//Creo el DbContext para consultar a la base de datos
public partial class UserContext : DbContext
{
   

    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

     
    //Conexión a la base de datos
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6LMV028\\SQLEXPRESS;Initial Catalog=DesafioKiltex;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

}
