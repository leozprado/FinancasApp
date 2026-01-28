using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Dtos.Requests
{
    /// <summary>
    /// Record para definir os dados de entrada de uma movimentação.
    /// </summary>
    public record MovimentacaoRequestDTO(
            string Nome, //Nome da movimentação
            DateTime Data, //Data da movimentação
            decimal Valor, //Valor da movimentação
            int Tipo, //Tipo da movimentação (1 - Receber, 2 - Pagar)
            Guid CategoriaId //Id da categoria associada
        );
}
