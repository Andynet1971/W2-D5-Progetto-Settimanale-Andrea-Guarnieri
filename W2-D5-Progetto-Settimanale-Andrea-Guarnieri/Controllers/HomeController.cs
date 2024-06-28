// Ho provato ad implementare la pagina Create Product ma senza riuscirci. Ho provato in molti modi ma ricevo sempre degli errori per via delle immagini.
// Ho provato a debaggare mettendo dei logger ovunque ma non ne sono venuto a capo.
// Per il resto ho creato la lista statica che recupera le immagini da dentro una cartella Images dentro wwwroot e le mostra sia nella home
// che nella pagina dettaglio. Ho aggiunto un po di stile come richiesto dalla consegna.



using Microsoft.AspNetCore.Mvc;
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models;
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.ViewModels;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Controllers
{
    public class HomeController : Controller
    {
        // Lista statica di prodotti predefiniti
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 139.99m,
                Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Stampa,Dettagli: Aperture,Codice articolo: JOC12O01N-Q13",
                MainImage = "images/1a.jpg",
                AdditionalImage1 = "images/1b.jpg",
                AdditionalImage2 = "images/1c.jpg"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Price = 152.99m,
                Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Stampa,Dettagli: Aperture,Codice articolo: JOC12N02E-Q14",
                MainImage = "images/2a.jpg",
                AdditionalImage1 = "images/2b.jpg",
                AdditionalImage2 = "images/2c.jpg"
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Price = 119.99m,
                Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Monocromo,Dettagli: Aperture,Codice articolo: JOC12N02L-A11",
                MainImage = "images/3a.jpg",
                AdditionalImage1 = "images/3b.jpg",
                AdditionalImage2 = "images/3c.jpg"
            }
        };

        // Azione per visualizzare la pagina principale con la lista dei prodotti
        public IActionResult Index()
        {
            return View(products);
        }

        // Azione per visualizzare i dettagli di un singolo prodotto
        public IActionResult Details(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Azione GET per visualizzare il form di creazione di un nuovo prodotto
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                NewProduct = new Product(),
                Products = products
            };
            return View(viewModel);
        }

        // Azione POST per gestire l'invio del form di creazione di un nuovo prodotto
        [HttpPost]
        public IActionResult Create(ProductViewModel viewModel, IFormFile mainImage, IFormFile additionalImage1, IFormFile additionalImage2)
        {
            if (ModelState.IsValid)
            {
                var product = viewModel.NewProduct;
                int newId = products.Count + 1;
                product.Id = newId;

                string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                // Salvataggio dell'immagine principale
                if (mainImage != null)
                {
                    var mainImagePath = Path.Combine(imagesPath, $"{newId}a.jpg");
                    using (var stream = new FileStream(mainImagePath, FileMode.Create))
                    {
                        mainImage.CopyTo(stream);
                    }
                    product.MainImage = $"images/{newId}a.jpg";
                }

                // Salvataggio della prima immagine aggiuntiva
                if (additionalImage1 != null)
                {
                    var additionalImage1Path = Path.Combine(imagesPath, $"{newId}b.jpg");
                    using (var stream = new FileStream(additionalImage1Path, FileMode.Create))
                    {
                        additionalImage1.CopyTo(stream);
                    }
                    product.AdditionalImage1 = $"images/{newId}b.jpg";
                }

                // Salvataggio della seconda immagine aggiuntiva
                if (additionalImage2 != null)
                {
                    var additionalImage2Path = Path.Combine(imagesPath, $"{newId}c.jpg");
                    using (var stream = new FileStream(additionalImage2Path, FileMode.Create))
                    {
                        additionalImage2.CopyTo(stream);
                    }
                    product.AdditionalImage2 = $"images/{newId}c.jpg";
                }

                // Aggiunta del nuovo prodotto alla lista
                products.Add(product);

                // Reindirizza alla pagina Home (Index) dopo la creazione
                return RedirectToAction(nameof(Index));
            }

            // In caso di errore, mantieni i dati attuali nel modello di vista
            viewModel.Products = products;
            return View(viewModel);
        }
    }
}
