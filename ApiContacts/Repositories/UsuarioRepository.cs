using System;
using ApiContacts.Domains.Repositories;
using ApiContacts.Infra;
using ApiContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiContacts.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly DatabaseContext _databaseContext;

		public UsuarioRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

        public List<Usuario> BuscaTodos()
        {
            return _databaseContext.Usuarios.ToList();
        }

        public Usuario BuscarPorId(Guid id)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");  
            }

            return usuario;
        }

        public Usuario Criar(Usuario usuario)
        {
            _databaseContext.Usuarios.Add(usuario);
            _databaseContext.SaveChanges();
            return usuario;
        }

        public Boolean Deletar(Guid id)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                return false;
            }
            else
            {
                _databaseContext.Usuarios.Remove(usuario);
                _databaseContext.SaveChanges();
                return true;
            }
        }
    }
}

