using System;
using ApiContacts.Models;

namespace ApiContacts.Domains.Repositories
{
	public interface IUsuarioRepository
	{
		Usuario Criar(Usuario usuario);

        List<Usuario> BuscaTodos();

		Usuario BuscarPorId(Guid id);

		Boolean Deletar(Guid id);
    }
}

