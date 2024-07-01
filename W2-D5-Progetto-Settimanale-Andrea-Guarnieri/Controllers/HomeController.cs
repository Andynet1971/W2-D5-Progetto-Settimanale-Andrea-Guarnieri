
// Con più tempo sono riuscito a risolvere gli errori nel codice e a cercare di rendere il codice stesso più modulare e leggibile
// Ho utilizzato interface e services come spiegato a lezione.
// Ho anche inserito 3 prodotti nel codice in modo che all'avvio dell'applicazione la pagina non sia vuota.
// Ho anche cercato di dare una veste grafica dignitosa scrivendo quasi 200 righe di css.
// Come plus ho implementato un algoritmo per la formattazione della descrizione in modo tale da rendere la visualizzazione chiara.
// La spiegazione di tale algoritmo si trova nella view Details
// Nella cartella wwwroot ho creato altre 3 cartelle :
// Images che contiene le immagini dei 3 prodotti che ho inserito a mano ed è anche la cartella di salvataggio delle immagini dei nuovi prodotti
// SiteImage è una cartella in cui ho inserito l'immagine di sfondo del sito ed il logo.
// SampleImage è una cartella che contiene 3 immagine che si possono utilizzare per creare un nuovo prodotto

// Buona lettura del codice !


using Microsoft.AspNetCore.Mvc;
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models;
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Services;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Controllers
{
    /// <summary>
    /// Controller per la gestione delle azioni relative ai prodotti.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Costruttore del controller.
        /// </summary>
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Azione per visualizzare la lista dei prodotti.
        /// </summary>
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        /// <summary>
        /// Azione per visualizzare i dettagli di un prodotto.
        /// </summary>
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// Azione GET per visualizzare il form di creazione di un nuovo prodotto.
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Azione POST per gestire l'invio del form di creazione di un nuovo prodotto.
        /// </summary>
        [HttpPost]
        public IActionResult Create(ProductInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.AddProduct(inputModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(inputModel);
        }
    }
}
