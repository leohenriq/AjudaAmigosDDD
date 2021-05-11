using AjudaAmigos.Domain.Entities;
using AjudaAmigos.Domain.Interfaces;
using AjudaAmigos.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AjudaAmigos.Application.Controllers
{
    /// <summary>
    /// Usuario Controller
    /// Responsável por ações do Usuário
    /// </summary>
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IBaseService<Usuario> _baseUsuarioService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseUsuarioService">IBaseService do Usuário</param>
        /// <returns></returns>
        public UsuarioController(IBaseService<Usuario> baseUsuarioService)
        {
            _baseUsuarioService = baseUsuarioService;
        }

        /// <summary>
        /// Obter Todos Versão 1
        /// </summary>
        /// <returns>
        /// Retorna Lista de Usuários
        /// </returns>
        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult ObterTodosV1()
        {
            return Executar(() => _baseUsuarioService.ObterTodos());
        }
        /// <summary>
        /// Obter Todos Versão 2
        /// </summary>
        /// <returns>
        /// Retorna Lista de Usuários
        /// </returns>
        [HttpGet]
        [MapToApiVersion("2")]
        public IActionResult ObterTodosV2()
        {
            return Executar(() => _baseUsuarioService.ObterTodos());
        }
        /// <summary>
        /// Adicionar Usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuário</param>
        /// <returns>
        /// Retorna Usuário Adicionado
        /// </returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return NotFound();

            return Executar(() => _baseUsuarioService.Adicionar<UsuarioValidator>(usuario).Id);
        }

        /// <summary>
        /// Atualizar Usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuário</param>
        /// <returns>
        /// Retorna Usuário Atualizado
        /// </returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return NotFound();

            return Executar(() => _baseUsuarioService.Atualizar<UsuarioValidator>(usuario));
        }

        /// <summary>
        /// Deletar Usuário
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>
        /// Retorno booleano para caso o Usuário tenha sido deletado
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
                return NotFound();

            Executar(() =>
            {
                _baseUsuarioService.Deletar(id);
                return true;
            });

            return new NoContentResult();
        }

        /// <summary>
        /// Obter Usuário Por Id
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>
        /// Retorna um objeto Usuário
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            if (id == 0)
                return NotFound();

            return Executar(() => _baseUsuarioService.ObterPorId(id));
        }
        private IActionResult Executar(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
