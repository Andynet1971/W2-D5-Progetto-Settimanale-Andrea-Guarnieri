using System.ComponentModel.DataAnnotations;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models
{
    /// <summary>
    /// Modello per un prodotto.
    /// Contiene i campi che rappresentano le proprietà di un prodotto.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il prezzo del prodotto è obbligatorio.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 100000, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 e 100000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La descrizione del prodotto è obbligatoria.")]
        public string Description { get; set; }

        public string MainImage { get; set; }
        public string AdditionalImage1 { get; set; }
        public string AdditionalImage2 { get; set; }
    }
}
