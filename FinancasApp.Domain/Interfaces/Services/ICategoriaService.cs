using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Contrato de serviços para categorias.
    /// </summary>
    public interface ICategoriaService
    {
        CategoriaResponseDTO Criar(CategoriaRequestDTO request);

        CategoriaResponseDTO Alterar(Guid id, CategoriaRequestDTO request);

        CategoriaResponseDTO Excluir(Guid id);

        List<CategoriaResponseDTO> Consultar();

        CategoriaResponseDTO? ObterPorId(Guid id);
    }
}
