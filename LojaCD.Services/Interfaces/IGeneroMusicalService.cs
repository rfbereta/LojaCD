using LojaCD.Services.ViewModels;

namespace LojaCD.Services.Interfaces
{
    public interface IGeneroMusicalService
    {
        Task Add(GeneroMusicalViewModel generoMusicalViewModel);
        Task Update(int id, GeneroMusicalViewModel generoMusicalViewModel);
        Task Delete(int id);
        Task<GeneroMusicalViewModel> GetGeneroMusicalById(int id);
        Task<List<GeneroMusicalViewModel>> GetAllGeneroMusical();

    }
}
