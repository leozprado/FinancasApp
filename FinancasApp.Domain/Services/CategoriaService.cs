using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de dominio de Categoria
    /// </summary>
    public class CategoriaService(ICategoriaRepository categoriaRepository) : ICategoriaService
    {
        public CategoriaResponseDTO Criar(CategoriaRequestDTO request)
        {
            var categoria = new Categoria(); //instanciando a classe de entidade
            categoria.Nome = request.Nome; //Capturando o nome da categoria no DTO

            //Adicionar a categoria no banco de dados
            categoriaRepository.Add(categoria);

            //Retornar o DTO de resposta
            return MapearParaDTO(categoria);
        }

        public CategoriaResponseDTO Alterar(Guid id, CategoriaRequestDTO request)
        {
            //Obter a categoria do banco de dados
            var categoria = categoriaRepository.GetById(id);

            //Verificar se a categoria não foi encontrada
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para edição.");

            categoria.Nome = request.Nome; //Atualizar o nome da categoria

            //Atualizar a categoria no banco de dados
            categoriaRepository.Update(categoria);

            //Retornar o DTO de resposta
            return MapearParaDTO(categoria);
        }

        public CategoriaResponseDTO Excluir(Guid id)
        {
            //Obter a categoria do banco de dados
            var categoria = categoriaRepository.GetById(id);

            //Verificar se a categoria não foi encontrada
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para exclusão.");

            //Excluir a categoria no banco de dados
            categoriaRepository.Delete(categoria);

            //Retornar o DTO de resposta
            return MapearParaDTO(categoria);
        }

        public List<CategoriaResponseDTO> Consultar()
        {
            //Obter todas as categorias do banco de dados
            var categorias = categoriaRepository.GetAll();

            //Mapear as categorias para DTOs de resposta
            var categoriasDTO = new List<CategoriaResponseDTO>();

            //Percorrer todas as categorias do banco de dados e mapear para DTO
            foreach (var item in categorias)
            {
                categoriasDTO.Add(MapearParaDTO(item));
            }

            //Retornar a lista de DTOs de resposta
            return categoriasDTO;
        }

        public CategoriaResponseDTO? ObterPorId(Guid id)
        {
            //Obter a categoria do banco de dados
            var categoria = categoriaRepository.GetById(id);

            //Verificar se a categoria foi encontrada
            if (categoria == null)
                return null; //Retornar nulo se não encontrada

            //Retornar o DTO de resposta
            return MapearParaDTO(categoria);
        }

        private CategoriaResponseDTO MapearParaDTO(Categoria categoria)
        {
            return new CategoriaResponseDTO
            (
                categoria.Id,
                categoria.Nome
            );
        }
    }
}
