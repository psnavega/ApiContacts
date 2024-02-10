using System;
using ApiContacts.Models;

namespace ApiContacts.Helper
{
	public interface ISessao
	{
		void CriarSessaoUsuario(Usuario usuario);

		void RemoveSessaoUsuario();

		Usuario BuscaSessaoUsuario();
	}
}

