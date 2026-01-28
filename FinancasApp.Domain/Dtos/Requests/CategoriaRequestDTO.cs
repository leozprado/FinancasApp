using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Dtos.Requests
{
    /// <summary>
    /// Record para definir os dados de entrada de categoria.
    /// </summary>
    public record CategoriaRequestDTO(
        string Nome //Nome da categoria
        
    );
}
