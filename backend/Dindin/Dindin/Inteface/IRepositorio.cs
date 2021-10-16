using System.Collections.Generic;

namespace Dindin.Interface
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T RetornaPorTitulo(string titulo);
        bool Inserir(T objeto);
        bool Atualizar(string titulo, T objeto);
        bool Excluir(string titulo);
    }
}
