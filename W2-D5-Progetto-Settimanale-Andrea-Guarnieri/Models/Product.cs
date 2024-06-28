using System.ComponentModel.DataAnnotations;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string MainImage { get; set; }
        public string AdditionalImage1 { get; set; }
        public string AdditionalImage2 { get; set; }
    }
}
