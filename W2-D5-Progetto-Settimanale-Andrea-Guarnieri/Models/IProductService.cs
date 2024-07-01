using System.Collections.Generic;
using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Models;

namespace W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Services
{
    /// <summary>
    /// Interfaccia per il servizio dei prodotti.
    /// Definisce i metodi per ottenere, aggiungere e cercare prodotti.
    /// </summary>
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(ProductInputModel inputModel);
    }
}
