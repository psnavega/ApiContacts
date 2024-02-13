using System;
using System.ComponentModel.DataAnnotations;
using ApiContacts.Domains.Enums;
using ApiContacts.Helper;

namespace ApiContacts.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Digite uma senha válida")]
        public PerfilEnum Perfil { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o login do contato")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite uma senha válida")]
        public string Senha { get; set; }
        

        public Usuario(string nome, string email, string login, string senha, PerfilEnum perfil)
        {
            Id = new Guid();
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Perfil = perfil;
            CriadoEm = DateTime.Now;
        }

        public virtual List<Contato> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            var novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        public Usuario()
        {

        }
    }
}

