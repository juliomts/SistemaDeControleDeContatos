using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroDeContatos.Models;
using SistemaDeCadastroDeContatos.Repositorio;
using System.Collections.Generic;

namespace SistemaDeCadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos =_contatoRepositorio.Buscar();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();//Como vai tá em branco para criar
        }
        public IActionResult Editar(int Id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(Id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int Id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(Id);
            return View(contato);
        }

        //Ao entrar na view esses comandos serão chamados
        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao deletar o contato!";
                }
                return RedirectToAction("Index");
            }

            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao deletar o contato!";
                return RedirectToAction("Index");
            }
           
        }

        [HttpPost]

        public IActionResult Criar (ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o contato!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Alterar(ContatoModel contato)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }

            catch(System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao atualizar o contato!";
                return RedirectToAction("Index");
            }
        }
    }
}
