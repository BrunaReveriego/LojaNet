using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public interface IProdutosDados
    {
        void Incluir(Produto produto);
        void Alterar(Produto produto);

        void Excluir(string Id);

        List<Produto> ObterTodos();
        Produto ObterPorId(string id);


    }
}
