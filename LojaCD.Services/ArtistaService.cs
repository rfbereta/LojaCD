using AutoMapper;
using LojaCD.Domain.Entity;
using LojaCD.Domain.Interfaces;
using LojaCD.Services.ViewModels;
using LojaCD.Services.Interfaces;

namespace LojaCD.Services
{

    public class ArtistaService : IArtistaService
    {
        private readonly IMapper _mapper;
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaService(IMapper mapper, IArtistaRepository clienteRepository)
        {
            _mapper = mapper;
            _artistaRepository = clienteRepository;
        }


        public async Task Add(ArtistaViewModel artistaViewModel)
        {
            var artista = _mapper.Map<Artista>(artistaViewModel);
                    
            await _artistaRepository.Insert(artista);

        }
        public async Task Update(int id, ArtistaViewModel artistaViewModel)
        {
            var artista = _mapper.Map<Artista>(artistaViewModel);

            await _artistaRepository.Update(id, artista);

        }

        public async Task Delete(int id)
        {
            await _artistaRepository.Delete(id);
        }

        public async Task<ArtistaViewModel> GetArtistaById(int id)
        {
            var artista = await _artistaRepository.GetById(id);
            return _mapper.Map<ArtistaViewModel>(artista);
            
        }
        public async Task<List<ArtistaViewModel>> GetAllArtista()
        {
            var artistas = await _artistaRepository.GetAll();
            return _mapper.Map<List<ArtistaViewModel>>(artistas.ToList());
        }

    }

}
