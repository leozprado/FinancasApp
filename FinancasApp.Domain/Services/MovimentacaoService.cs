using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        public MovimentacaoResponseDTO Alterar(Guid id, MovimentacaoRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public List<MovimentacaoResponseDTO> Consultar(DateTime dataMin, DateTime dataMax)
        {
            throw new NotImplementedException();
        }

        public MovimentacaoResponseDTO Criar(MovimentacaoRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public MovimentacaoResponseDTO Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public MovimentacaoResponseDTO? ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
