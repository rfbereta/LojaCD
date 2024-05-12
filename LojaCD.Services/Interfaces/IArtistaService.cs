using LojaCD.Services.ViewModels;

namespace LojaCD.Services.Interfaces
{
    public interface IArtistaService
    {
        Task Add(ArtistaViewModel artistaViewModel);
        Task Update(int id, ArtistaViewModel artistaViewModel);
        Task Delete(int id);
        Task<ArtistaViewModel> GetArtistaById(int id);
        Task<List<ArtistaViewModel>> GetAllArtista();

    }
}
