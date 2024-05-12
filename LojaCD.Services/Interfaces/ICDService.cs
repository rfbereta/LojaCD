using LojaCD.Services.ViewModels;

namespace LojaCD.Services.Interfaces
{
    public interface ICDService
    {
        Task<CDViewModel> Add(CDViewModel cdViewModel);
        Task AddMusica(MusicaViewModel musicaViewModel);
        Task Update(CDViewModel cdViewModel);
        Task UpdateMusica(MusicaViewModel musicaViewModel);

        Task Delete(int id);
        Task<CDViewModel> GetCDById(int id);
        Task<MusicaViewModel> GetMusicaById(int id);
        Task<List<CDViewModel>> GetAllCD();
        Task DeleteMusica(int id);
        Task<List<CDViewModel>> GetCDFitlrados(FiltroViewModel filtro);


    }
}
