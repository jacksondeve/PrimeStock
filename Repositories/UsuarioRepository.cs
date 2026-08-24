using System;
using PrimeStock.API.Data;
using PrimeStock.API.Models;




namespace PrimeStock.API.Repositories
{

	public class UsuarioRepository
	{
		private readonly PrimeStockDbContext _context;

		public UsuarioRepository(PrimeStockDbContext context)
		{
			_context = context;
		}

		public Usuario? buscaporemail(string email) { 
			return  _context.Usuarios.FirstOrDefault(u => u.Email == email);
		
		}

        public void CadastroUsuario(Usuario usuario)
        {
			_context.Usuarios.Add(usuario);			
			_context.SaveChanges();
        }

        public Usuario? BuscaPorEmaileSenha(string email, string senha)
        {
            
		return	 _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        }

    }

		

}
