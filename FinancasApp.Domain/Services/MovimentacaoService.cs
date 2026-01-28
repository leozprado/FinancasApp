using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Enums;
using FinancasApp.Domain.Interfaces.Messages;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de dominio de Movimentação
    /// </summary>
    public class MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, IMessageProducer messageProducer) : IMovimentacaoService
    {
        public MovimentacaoResponseDTO Criar(MovimentacaoRequestDTO request)
        {
            //capturar os dados da movimentação
            var movimentacao = new Movimentacao
            {
                Nome = request.Nome,
                Data = request.Data,
                Valor = request.Valor,
                Tipo = (TipoMovimentacao)request.Tipo,
                CategoriaId = request.CategoriaId
            };

            //salvar a movimentação no banco de dados
            movimentacaoRepository.Add(movimentacao);

            //copiar os dados para o record de resposta
            var response = new MovimentacaoResponseDTO
            (
                movimentacao.Id, //Id da movimentação
                movimentacao.Nome, ///Nome da movimentação
                movimentacao.Data, ///Data da movimentação
                movimentacao.Valor, //Valor da movimentação
                movimentacao.Tipo.ToString(), //Tipo da movimentação
                new CategoriaResponseDTO(movimentacao.CategoriaId, null) //Categoria
            );

            //Enviar os dados para a mensageria
            messageProducer.SendMessage(JsonSerializer.Serialize(response));

            return response; //retornar a resposta
        }

        public MovimentacaoResponseDTO Alterar(Guid id, MovimentacaoRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public MovimentacaoResponseDTO Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<MovimentacaoResponseDTO> Consultar(DateTime dataMin, DateTime dataMax)
        {
            throw new NotImplementedException();
        }

        public MovimentacaoResponseDTO? ObterPorId(Guid id)
        {
            //Obter a categoria do banco de dados
            var movimentacao = movimentacaoRepository.GetById(id);

            //Verificar se a categoria foi encontrada
            if (movimentacao == null)
                return null; //Retornar nulo se não encontrada

            var response = new MovimentacaoResponseDTO
            (
                movimentacao.Id, //Id da movimentação
                movimentacao.Nome, ///Nome da movimentação
                movimentacao.Data, ///Data da movimentação
                movimentacao.Valor, //Valor da movimentação
                movimentacao.Tipo.ToString(), //Tipo da movimentação
                new CategoriaResponseDTO(movimentacao.CategoriaId, null) //Categoria
            );

            //Retornar o DTO de resposta
            return response;
        }
    }
}
