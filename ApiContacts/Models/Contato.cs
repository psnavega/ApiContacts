using System;
using System.ComponentModel.DataAnnotations;

namespace ApiContacts.Models
{
	public class Contato
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set; }
        
        public Contato() { }

        public Contato(Guid id, string nome, string email, string celular)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Celular = celular;
        }
    }
}

