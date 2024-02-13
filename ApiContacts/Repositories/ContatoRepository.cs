using System;
using ApiContacts.Domains.Repositories;
using ApiContacts.Infra;
using ApiContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiContacts.Repositories
{
    public class ContatoRepository : IContatoRepository
	{
        private readonly DatabaseContext _databaseContext;

		public ContatoRepository(DatabaseContext databaseContext)
		{
            _databaseContext = databaseContext;
		}

        public Contato Adicionar(Contato contato)
        {
            _databaseContext.Contatos.Add(contato);
            _databaseContext.SaveChanges();

            return contato;
        }

        public bool Apagar(Guid id)
        {
            Contato contato = this.BuscaPorId(id);

            if (contato == null)
            {
                throw new Exception("Usuário não encontrado na base de dados");
            }

            _databaseContext.Contatos.Remove(contato);

            _databaseContext.SaveChanges();

            return true;
        }

        public Contato Atualizar(Contato contato)
        {
            Contato contatoNoBanco = _databaseContext.Contatos.FirstOrDefault(x => x.Id == contato.Id);

            if (contatoNoBanco == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            contatoNoBanco.Nome = contato.Nome;
            contatoNoBanco.Email = contato.Email;
            contatoNoBanco.Celular = contato.Celular;

            _databaseContext.Update(contatoNoBanco);
            _databaseContext.SaveChanges();

            return contatoNoBanco;
        }

        public Contato BuscaPorId(Guid id)
        {
            return _databaseContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<Contato> BuscarTodos(Guid usuarioId)
        {
            return _databaseContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }
    }
}

