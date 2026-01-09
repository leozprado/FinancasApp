using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
    }
}
