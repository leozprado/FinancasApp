using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para métodos de repositorio de movimentação
    /// </summary>
    public interface IMovimentacaoRepository : IBaseRepository<Movimentacao>
    {
        List<Movimentacao> GetByDatas(DateTime dataMin, DateTime dataMax);
    }
}