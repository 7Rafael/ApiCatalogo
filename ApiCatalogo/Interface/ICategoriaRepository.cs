using APICatalogo.Models;

namespace ApiCatalogo.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
        Categoria GetCategoria(int id);
        Categoria CreateCategoria(Categoria categoria);
        Categoria UpdateCategoria(Categoria categoria);
        Categoria DeleteCategoria(int id);
        long
    }
}
