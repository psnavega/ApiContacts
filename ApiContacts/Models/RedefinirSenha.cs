using System;
using System.ComponentModel.DataAnnotations;

namespace ApiContacts.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        public string Email { get; set; }

        public RedefinirSenha()
        {
        }
    }
}

