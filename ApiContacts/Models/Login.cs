using System;
using System.ComponentModel.DataAnnotations;

namespace ApiContacts.Models
{
	public class Login
	{
        [Required(ErrorMessage = "Digite o login do usuário")]
		public string Username { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

        public Login()
		{
		}
	}
}

