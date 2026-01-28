using System.ComponentModel.DataAnnotations;

namespace FinancasApp.WEB.Forms
{
    public class ConsultaMovimentacoesForm
    {
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        public string? DataMin { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fim.")]
        public string? DataMax { get; set; }
    }
}
