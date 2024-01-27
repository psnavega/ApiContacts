using System;
namespace ApiContacts.Models
{
	public class Contato
	{
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        
        public Contato()
        {

        }

        public Contato(Guid id, string nome, string email, string celular)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Celular = celular;
        }
    }
}

