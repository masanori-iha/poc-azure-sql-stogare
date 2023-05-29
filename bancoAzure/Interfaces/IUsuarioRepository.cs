using bancoAzure.Models;

namespace bancoAzure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task Add(UsuarioCreate usuario);
        Task Excluir(int id);
    }
}
