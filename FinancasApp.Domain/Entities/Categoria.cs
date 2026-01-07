using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Entities
{
    public class Categoria
    {
        /// <summary>
        /// Modelo de entidade para categoria de movimentação
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        // Relação 1:N com movimentações
        #region Relacionamentos

        public List<Movimentacao>? Movimentacoes { get; set; }

        #endregion
    }
}
