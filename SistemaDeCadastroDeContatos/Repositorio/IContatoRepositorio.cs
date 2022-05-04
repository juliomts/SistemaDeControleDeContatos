using SistemaDeCadastroDeContatos.Models;
using System.Collections.Generic;

namespace SistemaDeCadastroDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> Buscar();

        ContatoModel ListarPorId(int id);

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);  

    }
}
