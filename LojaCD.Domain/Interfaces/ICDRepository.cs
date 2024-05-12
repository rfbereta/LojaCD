using LojaCD.Domain.Entity;

namespace LojaCD.Domain.Interfaces
{
    public interface ICDRepository
    {
        Task<CD> GetById(int id);
        Task<Musica> GetMusicaById(int id);

        Task<IEnumerable<CD>> GetAll();
        Task<CD> Insert(CD cd);
        Task InsertMusica(Musica musica);
        Task Update(CD cd);
        Task UpdateMusica(Musica musica);
        Task Delete(int id);

        Task DeleteMusica(int id);

        Task<IEnumerable<CD>> GetCDFitlrados(string titulo, int? artistaId, int? generoMusicalId, string nomeMusica);

    }

}
