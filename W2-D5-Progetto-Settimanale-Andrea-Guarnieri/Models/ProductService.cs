
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Services
{
    /// <summary>
    /// Servizio per la gestione dei prodotti.
    /// Implementa i metodi definiti nell'interfaccia IProductService.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Product> products = new List<Product>();

        /// <summary>
        /// Costruttore del servizio dei prodotti.
        /// Inizializza i dati di esempio.
        /// </summary>
        public ProductService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            InitializeSampleData();
        }

        /// <summary>
        /// Inizializza i dati di esempio se la lista dei prodotti è vuota.
        /// </summary>
        private void InitializeSampleData()
        {
            if (products.Count == 0)
            {
                products.AddRange(new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Product 1",
                        Price = 139.99m,
                        Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Stampa,Dettagli: Aperture,Codice articolo: JOC12O01N-Q13",
                        MainImage = "/images/1a.jpg",
                        AdditionalImage1 = "/images/1b.jpg",
                        AdditionalImage2 = "/images/1c.jpg"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Product 2",
                        Price = 152.99m,
                        Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Stampa,Dettagli: Aperture,Codice articolo: JOC12N02E-Q14",
                        MainImage = "/images/2a.jpg",
                        AdditionalImage1 = "/images/2b.jpg",
                        AdditionalImage2 = "/images/2c.jpg"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Product 3",
                        Price = 119.99m,
                        Description = "Punta: Tonda,Tipo di tacco: Senza tacco,Chiusura: Lacci,Fantasia: Monocromo,Dettagli: Aperture,Codice articolo: JOC12N02L-A11",
                        MainImage = "/images/3a.jpg",
                        AdditionalImage1 = "/images/3b.jpg",
                        AdditionalImage2 = "/images/3c.jpg"
                    }
                });
            }
        }

        /// <summary>
        /// Ottiene tutti i prodotti.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// Ottiene un prodotto per ID.
        /// </summary>
        public Product GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        /// <summary>
        /// Aggiunge un nuovo prodotto alla lista.
        /// </summary>
        public void AddProduct(ProductInputModel inputModel)
        {
            var product = new Product
            {
                Id = products.Count + 1,
                Name = inputModel.Name,
                Price = inputModel.Price,
                Description = inputModel.Description
            };

            string imagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            try
            {
                // Salva l'immagine principale rinominandola con l'id seguito dalla lettera a
                if (inputModel.MainImageFile != null && inputModel.MainImageFile.Length > 0)
                {
                    var mainImagePath = Path.Combine(imagesPath, $"{product.Id}a.jpg");

                    using (var stream = new FileStream(mainImagePath, FileMode.Create))
                    {
                        inputModel.MainImageFile.CopyTo(stream);
                    }

                    product.MainImage = $"/images/{product.Id}a.jpg";
                }

                // Salva la prima immagine aggiuntiva rinominandola con l'id seguito dalla lettera b
                if (inputModel.AdditionalImage1File != null && inputModel.AdditionalImage1File.Length > 0)
                {
                    var additionalImage1Path = Path.Combine(imagesPath, $"{product.Id}b.jpg");

                    using (var stream = new FileStream(additionalImage1Path, FileMode.Create))
                    {
                        inputModel.AdditionalImage1File.CopyTo(stream);
                    }

                    product.AdditionalImage1 = $"/images/{product.Id}b.jpg";
                }

                // Salva la seconda immagine aggiuntiva rinominandola con l'id seguito dalla lettera c
                if (inputModel.AdditionalImage2File != null && inputModel.AdditionalImage2File.Length > 0)
                {
                    var additionalImage2Path = Path.Combine(imagesPath, $"{product.Id}c.jpg");

                    using (var stream = new FileStream(additionalImage2Path, FileMode.Create))
                    {
                        inputModel.AdditionalImage2File.CopyTo(stream);
                    }

                    product.AdditionalImage2 = $"/images/{product.Id}c.jpg";
                }
            }
            catch (Exception)
            {
                throw new Exception("Errore durante il caricamento delle immagini. Riprova.");
            }

            products.Add(product);
        }
    }
}
