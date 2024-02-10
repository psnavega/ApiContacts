using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContacts.Domains.Repositories;
using ApiContacts.Helper;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiContacts.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // se usuário estiver logado, redirect para a home

            if (_sessao.BuscaSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepository.Autenticar(login.Username, login.Senha);

                    if (usuario != null)
                    {
                        _sessao.CriarSessaoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"Usuário ou senha inválidos, por favor tente novamente";
                }
                return View("Index");
            }
            catch(Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível realizar o login, tente novamente mais tarde: {error.Message}";
                return View("Index");
            }
        }
    }
}

