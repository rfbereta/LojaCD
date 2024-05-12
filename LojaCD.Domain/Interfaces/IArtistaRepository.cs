using LojaCD.Domain.Entity;

namespace LojaCD.Domain.Interfaces
{
    public interface IArtistaRepository
    {
        Task<Artista> GetById(int id);
        Task<IEnumerable<Artista>> GetAll();
        Task Insert(Artista artista);
        Task Update(int id, Artista artista);
        Task Delete(int id);
    }

}
