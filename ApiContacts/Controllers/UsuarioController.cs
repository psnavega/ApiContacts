using System;
using ApiContacts.Domains.Repositories;
using ApiContacts.Infra;
using ApiContacts.Models;
using ApiContacts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioController(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public IActionResult Index()
		{
			List<Usuario> usuarios = _usuarioRepository.BuscaTodos();
			return View(usuarios);
		}

		public IActionResult Criar()
		{
			return View();
		}

        public IActionResult ApagarConfirmacao(Guid id)
        {
			Usuario usuario = _usuarioRepository.BuscarPorId(id);

			if (usuario == null)
			{
                TempData["MensagemErro"] = "Falha ao apagar usuário";
				return RedirectToAction("Index");
            }
			else {
                return View(usuario);
            }
        }

		[HttpPost]
        public IActionResult Apagar(Guid id)
        {
			bool response = _usuarioRepository.Deletar(id);

			if (response)
			{
				TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
			}
			else
			{
                TempData["MensagemErro"] = "Falha ao apagar usuário";
            }

			return RedirectToAction("Index");
        }

        [HttpPost]
		public IActionResult Criar(Usuario usuario)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    Usuario usuarioCriado = _usuarioRepository.Criar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
				return View(usuario);
            }
			catch
			{
                TempData["MensagemErro"] = "Usuário não cadastrado, falha no processo";
				return RedirectToAction("Index");
			}
		}
    }
}

