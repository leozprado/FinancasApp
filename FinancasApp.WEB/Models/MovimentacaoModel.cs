namespace FinancasApp.WEB.Models
{
    /// <summary>
    /// Modelo de dados para consulta de movimentações
    /// </summary>
    public record MovimentacaoModel(
            Guid id, //Identificador único da movimentação
            string nome, //Nome da movimentação
            DateTime data, //Data da movimentação
            decimal valor, //Valor da movimentação
            string tipo, //Tipo da movimentação (Receita ou Despesa)
            CategoriaModel categoria //Categoria associada à movimentação
        );
}
