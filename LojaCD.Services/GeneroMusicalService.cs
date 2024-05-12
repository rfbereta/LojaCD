using AutoMapper;
using LojaCD.Domain.Entity;
using LojaCD.Domain.Interfaces;
using LojaCD.Services.ViewModels;
using LojaCD.Services.Interfaces;

namespace LojaCD.Services
{

    public class GeneroMusicalService : IGeneroMusicalService
    {
        private readonly IMapper _mapper;
        private readonly IGeneroMusicalRepository _generoMusicalRepository;

        public GeneroMusicalService(IMapper mapper, IGeneroMusicalRepository clienteRepository)
        {
            _mapper = mapper;
            _generoMusicalRepository = clienteRepository;
        }


        public async Task Add(GeneroMusicalViewModel generoMusicalViewModel)
        {
            var generoMusical = _mapper.Map<GeneroMusical>(generoMusicalViewModel);
                    
            await _generoMusicalRepository.Insert(generoMusical);

        }
        public async Task Update(int id, GeneroMusicalViewModel generoMusicalViewModel)
        {
            var generoMusical = _mapper.Map<GeneroMusical>(generoMusicalViewModel);

            await _generoMusicalRepository.Update(id, generoMusical);

        }

        public async Task Delete(int id)
        {
            await _generoMusicalRepository.Delete(id);
        }

        public async Task<GeneroMusicalViewModel> GetGeneroMusicalById(int id)
        {
            var generoMusical = await _generoMusicalRepository.GetById(id);
            return _mapper.Map<GeneroMusicalViewModel>(generoMusical);
            
        }
        public async Task<List<GeneroMusicalViewModel>> GetAllGeneroMusical()
        {
            var generoMusicals = await _generoMusicalRepository.GetAll();
            return _mapper.Map<List<GeneroMusicalViewModel>>(generoMusicals.ToList());
        }


    }

}
