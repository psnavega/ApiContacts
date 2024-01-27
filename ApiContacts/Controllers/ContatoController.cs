using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContacts.Domains.Repositories;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiContacts.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Contato> contatos = _contatoRepository.BuscarTodos();
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

        public IActionResult Apagar(Guid id)
        {
            _contatoRepository.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(Contato contato)
        {
            _contatoRepository.Atualizar(contato);
            return RedirectToAction("Index");
        }
    }
}

