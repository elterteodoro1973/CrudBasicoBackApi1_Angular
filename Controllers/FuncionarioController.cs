using AutoMapper;
using BackEndAngular.DTO;
using BackEndAngular.Models;
using BackEndAngular.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        readonly FuncionarioRepository _funcionarioRepository;
        readonly IMapper _mapper; // Add this field to inject AutoMapper

        public FuncionarioController(FuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper; 
        }


        [HttpGet]        
        [ProducesResponseType(typeof(Resposta<IEnumerable<Funcionario>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Resposta<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getAll()
        {
            try
            {  
                return Ok(new Resposta<IEnumerable<Funcionario>>()
                {
                    Sucesso = true,
                    Mensagem = "Retorno com sucesso",
                    Dados = await _funcionarioRepository.GetAllFuncionarios()
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta<IEnumerable<Funcionario>>
                {
                    Sucesso = false,
                    Mensagem = "Erro ao obter os funcionários: " + e.Message,
                    Dados = null
                });
            }
        }

        // GET api/<FuncionariosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Resposta<Funcionario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Resposta<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> find(int id)
        {
            try
            {
                return Ok(new Resposta<Funcionario>()
                {
                    Sucesso = true,
                    Mensagem = "Funcionário não encontrado",
                    Dados = await _funcionarioRepository.GetFuncionarioById(id)
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta<Funcionario>
                {
                    Sucesso = false,
                    Mensagem = "Erro ao obter o funcionário: " + e.Message,
                    Dados = null
                });
            }
        }


        
        [HttpPost(Name = "IncluirFuncionario")]
        [ProducesResponseType(typeof(Resposta<FuncionarioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Resposta<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> create([FromBody] FuncionarioDTO funcionario)
        {
            try
            {                
                var novoFuncionario = _mapper.Map<Funcionario>(funcionario); 
                var createdFuncionario = await _funcionarioRepository.AddFuncionario(novoFuncionario); 

                return Ok( new Resposta<Funcionario>
                {
                    Sucesso = true,
                    Mensagem = "Funcionário incluído com sucesso",
                    Dados = createdFuncionario
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta<Funcionario>
                {
                    Sucesso = false,
                    Mensagem = "Erro ao incluir o funcionário: " + e.Message,
                    Dados = null
                });
            }
        }

            
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Resposta<Funcionario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Resposta<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> update(int id,  [FromBody] FuncionarioDTO funcionario)
        {
            try
            {
                var funcionarioAtualizado = await _funcionarioRepository.UpdateFuncionario(id,funcionario);
                return Ok(new Resposta<Funcionario>
                {
                    Sucesso = true,
                    Mensagem = "Funcionário atualizado com sucesso",
                    Dados = funcionarioAtualizado
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta<Funcionario>
                {
                    Sucesso = false,
                    Mensagem = "Erro ao atualizar o funcionário: " + e.Message,
                    Dados = null
                });
            }
        }

        // DELETE api/<FuncionariosController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Resposta<Funcionario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Resposta<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var funcionarioDeletado = await _funcionarioRepository.GetFuncionarioById(id); 
                await _funcionarioRepository.DeleteFuncionario(id);
                return Ok(new Resposta<Funcionario>
                {
                    Sucesso = true,
                    Mensagem = "Funcionário deletado com sucesso",
                    Dados = funcionarioDeletado
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta<Funcionario>
                {
                    Sucesso = false,
                    Mensagem = "Erro ao deletar o funcionário: " + e.Message,
                    Dados = null
                });
            }
        }
    }
}
