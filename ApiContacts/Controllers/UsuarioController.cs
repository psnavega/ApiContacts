using System;
using ApiContacts.Domains.Repositories;
using ApiContacts.Filters;
using ApiContacts.Infra;
using ApiContacts.Models;
using ApiContacts.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiContacts.Controllers
{
    [PaginaParaAdmin]
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
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id) ?? throw new Exception("Usuário não encontrado");
                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Falha ao apagar usuário: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(Guid id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id) ?? throw new Exception("Usuário não encontrado");
                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Falha ao apagar usuário: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Editar(usuario);
                    TempData["MensagemSucesso"] = $"Usuário atualizado com sucesso!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Falha ao editar usuário: {error.Message}";
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Apagar(Guid id)
        {
            try
            {
                bool response = _usuarioRepository.Deletar(id);

                if (!response)
                {
                    throw new Exception("Usuario não encontrado");
                }
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Falha ao apagar usuário: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.SetSenhaHash();
                    Usuario usuarioCriado = _usuarioRepository.Criar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Usuário não cadastrado, falha no processo: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

