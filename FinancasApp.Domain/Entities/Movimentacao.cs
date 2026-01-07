using FinancasApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public  decimal Valor { get; set; }

        public TipoMovimentacao Tipo { get; set; }

        public Guid CategoriaId { get; set; }

        #region Relacionamentos

        public Categoria? Categoria { get; set; }

        #endregion



    }
}
