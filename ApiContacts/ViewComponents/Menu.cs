using System;
using System.Threading.Tasks;
using ApiContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiContacts.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            return View(usuario);
        }
    }
}
