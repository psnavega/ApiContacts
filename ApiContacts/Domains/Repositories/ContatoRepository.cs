using System;
using ApiContacts.Models;

namespace ApiContacts.Domains.Repositories
{
	public interface IContatoRepository
	{
		Contato Adicionar(Contato contato);

		List<Contato> BuscarTodos(Guid usuarioId);

		Contato BuscaPorId(Guid id);

		Contato Atualizar(Contato contato);

		Boolean Apagar(Guid id); 
	}
}

