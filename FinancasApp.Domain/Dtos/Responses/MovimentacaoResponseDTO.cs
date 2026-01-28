using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Dtos.Responses
{
    /// <summary>
    /// Record para definir os dados de saída (resposta) de uma movimentação.
    /// </summary>
    public record MovimentacaoResponseDTO(
            Guid Id, //Identificador único da movimentação
            string Nome, //Nome da movimentação
            DateTime Data, //Data da movimentação
            decimal Valor, //Valor da movimentação
            string Tipo, //Tipo da movimentação (Receita ou Despesa)
            CategoriaResponseDTO Categoria //Categoria associada à movimentação
        );

}

