using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Dtos.Responses
{
    /// <summary>
    /// Record para definir os dados de saída (resposta) de uma categoria.
    /// </summary>
    public record CategoriaResponseDTO(
            Guid Id, //Identificador único da categoria
            string Nome //Nome da categoria
        );
}
