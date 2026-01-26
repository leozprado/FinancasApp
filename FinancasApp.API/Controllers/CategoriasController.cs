using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController(ICategoriaService categoriaService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaRequestDTO request)
        {
            try
            {
                //Chamar o serviço para criar a categoria
                var response = categoriaService.Criar(request);
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
        public IActionResult Put(Guid id, [FromBody] CategoriaRequestDTO request)
        {
            try
            {
                //Chamar o serviço para atualizar a categoria
                var response = categoriaService.Alterar(id, request);
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
                //Chamar o serviço para excluir a categoria
                var response = categoriaService.Excluir(id);
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //Chamar o serviço para consultar todas as categorias
                var response = categoriaService.Consultar();
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
                //Chamar o serviço para consultar a categoria por Id
                var response = categoriaService.ObterPorId(id);
                //Verificar se a categoria foi encontrada
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
