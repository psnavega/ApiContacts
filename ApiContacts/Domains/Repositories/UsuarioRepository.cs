using System;
using ApiContacts.Models;

namespace ApiContacts.Domains.Repositories
{
	public interface IUsuarioRepository
	{
		Usuario Criar(Usuario usuario);

        List<Usuario> BuscaTodos();

		Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailELogin(string email, string login);

        Boolean Deletar(Guid id);

		Usuario Editar(Usuario usuario);

		Usuario Autenticar(string login, string senha);

		Boolean AtualizarSenha(Usuario usuario);

		Usuario AtualizarNovaSenha(AlterarSenha alterarSenha);

    }
}

