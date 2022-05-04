using SistemaDeCadastroDeContatos.Data;
using SistemaDeCadastroDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeCadastroDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ContatoContext _contatoContext;

        public ContatoRepositorio(ContatoContext contatoContext)
        {
            _contatoContext = contatoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _contatoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> Buscar()
        {
            return _contatoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _contatoContext.Contatos.Add(contato);
            _contatoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

                if(contatoDB == null)
                {

                throw new System.Exception("Houve um erro na atualização do contato");
               
                }

                else 

                { 

                contatoDB.Nome = contato.Nome;
                contatoDB.Email = contato.Email;
                contatoDB.Celular = contato.Celular;

                _contatoContext.Contatos.Update(contatoDB);
                _contatoContext.SaveChanges();
                return contatoDB;
            }
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null)
            {

                throw new System.Exception("Houve um erro ao deletar o contato");

            }

            else
            {
                _contatoContext.Contatos.Remove(contatoDB);
                _contatoContext.SaveChanges();

                return true;
            }
        }
    }
}
