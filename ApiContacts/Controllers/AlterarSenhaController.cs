using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContacts.Domains.Repositories;
using ApiContacts.Helper;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiContacts.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao; 

        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alterar(AlterarSenha alterarSenha)
        {
            try
            {
                Usuario usuarioLogado = _sessao.BuscaSessaoUsuario();
                alterarSenha.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {
                    _usuarioRepository.AtualizarNovaSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Mensagem alterada com sucesso";
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Erro ao alterar senha: {error.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}

