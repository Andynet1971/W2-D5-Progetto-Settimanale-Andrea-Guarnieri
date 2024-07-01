using Microsoft.AspNetCore.Http;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models
{
    /// <summary>
    /// Modello per l'input di un nuovo prodotto.
    /// Contiene i campi necessari per creare un nuovo prodotto.
    /// </summary>
    public class ProductInputModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile MainImageFile { get; set; }
        public IFormFile AdditionalImage1File { get; set; }
        public IFormFile AdditionalImage2File { get; set; }
    }
}
