using System;
using System.ComponentModel.DataAnnotations;
using ApiContacts.Domains.Enums;

namespace ApiContacts.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o login do contato")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite uma senha válida")]
        public PerfilEnum Perfil;
        public DateTime criadoEm;
        public DateTime? atualizadoEm;

        public Usuario(string nome, string email, string login, string senha, PerfilEnum perfil)
        {
            Id = new Guid();
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Perfil = perfil;
        }

        public Usuario()
        {

        }
    }
}

