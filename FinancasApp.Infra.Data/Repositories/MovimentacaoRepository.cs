using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar o repositório de movimentações.
    /// </summary>
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public List<Movimentacao> GetByDatas(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Movimentacao>() //Consulta de movimentações
                        .Include(m => m.Categoria) //Junção para trazer a categoria relacionada
                        .Where(m => m.Data >= dataMin && m.Data <= dataMax) //Filtro por data
                        .OrderBy(m => m.Data) //Ordenação por data
                        .ToList(); //Retorna a lista de movimentações
            }
        }
    }
}