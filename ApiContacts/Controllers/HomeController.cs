using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContacts.Filters;
using ApiContacts.Infra;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscaPorId(Guid Id)
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(Guid Id)
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult Atualizar(Usuario usuario)
        {
            return View();
        }
    }
}



