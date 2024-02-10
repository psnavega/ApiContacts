using System;
using ApiContacts.Models;
using Newtonsoft.Json;

namespace ApiContacts.Helper
{
	public class Sessao : ISessao
	{
        private readonly IHttpContextAccessor _httpContext;

		public Sessao(IHttpContextAccessor httpContext)
		{
            _httpContext = httpContext;
		}

        public Usuario BuscaSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoveSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}

