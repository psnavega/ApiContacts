using System;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ApiContacts.Filters
{
	public class PaginaParaUsuarioLogado : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ { "controller", "Login" }, { "action", "Index"}  });
            } else
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

                if (usuario is null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}

