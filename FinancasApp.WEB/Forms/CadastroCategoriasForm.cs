using System.ComponentModel.DataAnnotations;

namespace FinancasApp.WEB.Forms
{
    /// <summary>
    /// /Classe para definir os campos do formulário
    /// de cadastro de categorias
    /// </summary>
    public class CadastroCategoriasForm
    {
        [Required(ErrorMessage = "Por favor, informe o nome da categoria.")]
        [MinLength(6, ErrorMessage = "Por favor, informe pelo menos {1} caracteres.")]
        public string? Nome { get; set; }
    }
}
