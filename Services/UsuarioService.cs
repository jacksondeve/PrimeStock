using PrimeStock.API.Repositories;
using PrimeStock.API.Models;
namespace PrimeStock.API.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioService(UsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }

        public string CadastrarUsuario(Usuario usuario)
        {
            var UsuarioExiste = _usuarioRepository.buscaporemail(usuario.Email);


                if (UsuarioExiste != null) {

                return "email ja cadastrado";
            }
            else {
                _usuarioRepository.CadastroUsuario(usuario);

                return "usuario cadastrado com sucesso";
            }
           
        }

        public string Login(string email , string senha )
        {

            var usuario = _usuarioRepository.BuscaPorEmaileSenha(email, senha); 

            if (usuario != null)
            {
                return "login efetuado com sucesso";
            }
            else
            {
                return "email ou senha invalidos";
            }
        }
    }
}
