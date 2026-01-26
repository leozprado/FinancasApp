using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Contrato de serviços para movimentações.
    /// </summary>
    public interface IMovimentacaoService
    {
        MovimentacaoResponseDTO Criar(MovimentacaoRequestDTO request);

        MovimentacaoResponseDTO Alterar(Guid id, MovimentacaoRequestDTO request);

        MovimentacaoResponseDTO Excluir(Guid id);

        List<MovimentacaoResponseDTO> Consultar(DateTime dataMin, DateTime dataMax);

        MovimentacaoResponseDTO? ObterPorId(Guid id);
    }
}
