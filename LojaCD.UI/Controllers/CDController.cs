using LojaCD.Services.ViewModels;
using LojaCD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaCD.UI.Controllers
{
    public class CDController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICDService _cdService;
        private readonly IArtistaService _artistaService;
        private readonly IGeneroMusicalService _generoMusicalService;

        public CDController(ILogger<HomeController> logger, ICDService cdService, IArtistaService artistaService, IGeneroMusicalService generoMusicalService)
        {
            _logger = logger;
            _cdService = cdService;
            _artistaService = artistaService;
            _generoMusicalService = generoMusicalService;
        }

        public async Task<IActionResult> Index()
        {
            var consultaCDs = new CDScomFiltroViewModel()
            {
                CDSViewModel = await _cdService.GetAllCD()
            };

            var artistas = await _artistaService.GetAllArtista();

            //Incluindo opção em branco para o filtro não ser obrigatório no dropdownlist
            artistas.Insert(0, new ArtistaViewModel {  Id = 0, Nome = "" });

            ViewBag.ArtistaId =
            new SelectList(artistas, "Id", "Nome");

            var generosMusicais = await _generoMusicalService.GetAllGeneroMusical();
            generosMusicais.Insert(0, new GeneroMusicalViewModel { Id = 0, Nome = "" });

            ViewBag.GeneroMusicalId =
            new SelectList(generosMusicais, "Id", "Nome");

            return View(consultaCDs);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ArtistaId =
            new SelectList(await _artistaService.GetAllArtista(), "Id", "Nome");

            ViewBag.GeneroMusicalId =
            new SelectList(await _generoMusicalService.GetAllGeneroMusical(), "Id", "Nome");
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CDViewModel cdViewModel)
        {
            if (ModelState.IsValid)
            {
                cdViewModel = await _cdService.Add(cdViewModel);
                return RedirectToAction(nameof(Edit), new { Id = cdViewModel.Id });

            }

            ViewBag.ArtistaId =
           new SelectList(await _artistaService.GetAllArtista(), "Id", "Nome");

            ViewBag.GeneroMusicalId =
            new SelectList(await _generoMusicalService.GetAllGeneroMusical(), "Id", "Nome");


            return View(cdViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMusica(int cdId)
        {
            var viewModel = new MusicaViewModel { Id = cdId };
            return View("CreateMusica", viewModel);
        }

        [HttpPost(), ActionName("CreateMusica")]
        public async Task<IActionResult> CreateMusica(int cdId, MusicaViewModel musicaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _cdService.AddMusica(musicaViewModel);
                return RedirectToAction(nameof(Edit), new { Id = musicaViewModel.CDId });
            }

            return View("CreateMusica", musicaViewModel);
        }

        [HttpGet()]
        public async Task<IActionResult> EditMusica(int id)
        {
            var musicaViewModel = await _cdService.GetMusicaById(id);

            if (musicaViewModel == null) return NotFound();

            return View(musicaViewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> EditMusica(MusicaViewModel musicaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _cdService.UpdateMusica(musicaViewModel);
                return RedirectToAction(nameof(Edit), new { Id = musicaViewModel.CDId });
            }
            return View(musicaViewModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var cdViewModel = await _cdService.GetCDById(id);

            if (cdViewModel == null) return NotFound();

            var artistas = await _artistaService.GetAllArtista();

            ViewBag.ArtistaId = new SelectList(artistas, "Id", "Nome", cdViewModel.ArtistaId);

            var generosmusicais = await _generoMusicalService.GetAllGeneroMusical();

            ViewBag.GeneroMusicalId = new SelectList(generosmusicais, "Id", "Nome", cdViewModel.GeneroMusicalId);

            return View(cdViewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CDViewModel cdViewModel)
        {
            if (ModelState.IsValid)
            {
                await _cdService.Update(cdViewModel);
                return RedirectToAction(nameof(Index));
            }

            var artistas = await _artistaService.GetAllArtista();

            ViewBag.ArtistaId = new SelectList(artistas, "Id", "Nome", cdViewModel.ArtistaId);

            var generosmusicais = await _generoMusicalService.GetAllGeneroMusical();

            ViewBag.GeneroMusicalId = new SelectList(generosmusicais, "Id", "Nome", cdViewModel.GeneroMusicalId);

            return View(cdViewModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            var cdViewModel = await _cdService.GetCDById(id);

            if (cdViewModel == null) return NotFound();

            return View(cdViewModel);
        }


        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmado(int id)
        {
            await _cdService.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet()]
        public async Task<IActionResult> DeleteMusica(int id)
        {
            var musicaViewModel = await _cdService.GetMusicaById(id);

            if (musicaViewModel == null) return NotFound();

            return View(musicaViewModel);
        }

        [HttpPost(), ActionName("DeleteMusica")]
        public async Task<IActionResult> DeleteMusicaConfirmado(int id)
        {
            var musicaViewModel = await _cdService.GetMusicaById(id);

            if (musicaViewModel == null) return NotFound();

            await _cdService.DeleteMusica(id);

            return RedirectToAction(nameof(Edit), new { Id = musicaViewModel.CDId });
        }


        [HttpGet(), ActionName("VoltarParaCD")]
        public async Task<IActionResult> VoltarParaCD(int cdID)
        {
            return RedirectToAction(nameof(Edit), new { Id = cdID });
        }

        [HttpGet(), ActionName("Filtrar")]
        public async Task<IActionResult> Filtrar(CDScomFiltroViewModel cdscomFiltroView)
        {
            cdscomFiltroView.CDSViewModel = await _cdService.GetCDFitlrados(cdscomFiltroView.Filtro);

            var artistas = await _artistaService.GetAllArtista();

            //Incluindo opção em branco para o filtro não ser obrigatório no dropdownlist
            artistas.Insert(0, new ArtistaViewModel { Id = 0, Nome = "" });

            ViewBag.ArtistaId =
            new SelectList(artistas, "Id", "Nome");

            var generosMusicais = await _generoMusicalService.GetAllGeneroMusical();
            generosMusicais.Insert(0, new GeneroMusicalViewModel { Id = 0, Nome = "" });

            ViewBag.GeneroMusicalId =
            new SelectList(generosMusicais, "Id", "Nome");

            return View("Index", cdscomFiltroView);

        }
    }
}
