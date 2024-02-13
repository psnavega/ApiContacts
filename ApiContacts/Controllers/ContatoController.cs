using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContacts.Domains.Repositories;
using ApiContacts.Filters;
using ApiContacts.Helper;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiContacts.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepository contatoRepository, ISessao sessao)
        {
            _contatoRepository = contatoRepository;
            _sessao = sessao;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Usuario usuario = _sessao.BuscaSessaoUsuario();
            List<Contato> contatos = _contatoRepository.BuscarTodos(usuario.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(Guid id)
        {

            Contato contato = _contatoRepository.BuscaPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(Guid id)
        {
            Contato contato = _contatoRepository.BuscaPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Apagar(Guid id)
        {
            try
            {
                bool apagado = _contatoRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso";
                 
                } else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar esse contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar esse contato {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _sessao.BuscaSessaoUsuario();
                    contato.UsuarioId = usuario.Id;
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            } catch (Exception error)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar no momento. Erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _sessao.BuscaSessaoUsuario();
                    contato.UsuarioId = usuario.Id;
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato.Id);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

