namespace FinancasApp.WEB.Models
{
    /// <summary>
    /// Modelo de dados para consulta de categorias
    /// </summary>
    public record CategoriaModel(
            Guid id, //Id da categoria
            string nome //Nome da categoria
        );
}
