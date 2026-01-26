using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacoesController(IMovimentacaoService movimentacaoService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] MovimentacaoRequestDTO request)
        {
            try
            {
                //Chamar o serviço para criar a movimentação
                var response = movimentacaoService.Criar(request);
                //Retornar a resposta com status 201 Created
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                //Retornar erro com status 500 Internal Server Error
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MovimentacaoRequestDTO request)
        {
            try
            {
                //Chamar o serviço para atualizar a movimentação
                var response = movimentacaoService.Alterar(id, request);
                //Retornar a resposta com status 200 OK
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //Retornar erro com status 400 Bad Request
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //Retornar erro com status 500 Internal Server Error
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Chamar o serviço para excluir a movimentação
                var response = movimentacaoService.Excluir(id);
                //Retornar a resposta com status 200 OK
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //Retornar erro com status 400 Bad Request
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //Retornar erro com status 500 Internal Server Error
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult GetAll(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                //Chamar o serviço para consultar todas as movimentações
                var response = movimentacaoService.Consultar(dataMin, dataMax);
                //Retornar a resposta com status 200 OK
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //Retornar erro com status 500 Internal Server Error
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //Chamar o serviço para consultar a movimentação por Id
                var response = movimentacaoService.ObterPorId(id);
                //Verificar se a movimentação foi encontrada
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //Retornar erro com status 500 Internal Server Error
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
