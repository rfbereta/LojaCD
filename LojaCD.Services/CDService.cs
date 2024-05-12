using AutoMapper;
using LojaCD.Domain.Entity;
using LojaCD.Domain.Interfaces;
using LojaCD.Services.ViewModels;
using LojaCD.Services.Interfaces;

namespace LojaCD.Services
{

    public class CDService : ICDService
    {
        private readonly IMapper _mapper;
        private readonly ICDRepository _cdRepository;

        public CDService(IMapper mapper, ICDRepository cdRepository)
        {
            _mapper = mapper;
            _cdRepository = cdRepository;
        }


        public async Task<CDViewModel> Add(CDViewModel cdViewModel)
        {

            var cd = _mapper.Map<CD>(cdViewModel);
                    
            cd = await _cdRepository.Insert(cd);

            return _mapper.Map<CDViewModel>(cd);

        }

        public async Task AddMusica(MusicaViewModel musicaViewModel)
        {

            var musica = _mapper.Map<Musica>(musicaViewModel);

            await _cdRepository.InsertMusica(musica);

        }


        public async Task Update(CDViewModel cdViewModel)
        {

            var cd = _mapper.Map<CD>(cdViewModel);

            await _cdRepository.Update(cd);

        }

        public async Task UpdateMusica(MusicaViewModel musicaViewModel)
        {

            var musica = _mapper.Map<Musica>(musicaViewModel);

            await _cdRepository.UpdateMusica(musica);

        }
        public async Task Delete(int id)
        {
            await _cdRepository.Delete(id);
        }
        public async Task DeleteMusica(int id)
        {
            await _cdRepository.DeleteMusica(id);
        }
        public async Task<CDViewModel> GetCDById(int id)
        {
            var cd = await _cdRepository.GetById(id);
            return _mapper.Map<CDViewModel>(cd);
            
        }
        public async Task<MusicaViewModel> GetMusicaById(int id)
        {
            var musica = await _cdRepository.GetMusicaById(id);
            return _mapper.Map<MusicaViewModel>(musica);

        }

        public async Task<List<CDViewModel>> GetAllCD()
        {
            var cds = await _cdRepository.GetAll();
            return _mapper.Map<List<CDViewModel>>(cds.ToList());
        }
        public async Task<List<CDViewModel>> GetCDFitlrados(FiltroViewModel filtro)
        {
            var cds = await _cdRepository.GetCDFitlrados(filtro.TituloCD, filtro.ArtistaID, filtro.GeneroMusicalID, filtro.NomeMusica);
            return _mapper.Map<List<CDViewModel>>(cds.ToList());
        }
    }

}
