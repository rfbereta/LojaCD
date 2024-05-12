using LojaCD.Domain.Entity;

namespace LojaCD.Domain.Interfaces
{
    public interface IGeneroMusicalRepository
    {
        Task<GeneroMusical> GetById(int id);
        Task<IEnumerable<GeneroMusical>> GetAll();
        Task Insert(GeneroMusical generoMusical);
        Task Update(int id, GeneroMusical generoMusical);
        Task Delete(int id);
    }

}
