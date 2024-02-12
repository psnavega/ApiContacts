using System;
using System.ComponentModel.DataAnnotations;

namespace ApiContacts.Models
{
	public class AlterarSenha
	{
        public Guid Id { get; set; }

		[Required(ErrorMessage = "Digite a senha atual")]
		public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }

		public AlterarSenha() { }
    }
}

