using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Data.Dtos.DtoListaTarefa;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListaTarefasController : ControllerBase
    {

        //Instanciar o Contexto
        private Contexto _contexto;
        //Instanciar o Mapper
        private IMapper _mapper;
        //Instaciar o Logger
        private readonly ILogger<ListaTarefasController> _logger;

        public ListaTarefasController
        (
        Contexto contexto, 
        IMapper mapper, 
        ILogger<ListaTarefasController> logger 
        )
        {
            _contexto = contexto;
            _mapper   = mapper;
            _logger   = logger;
        }

        [HttpPost("createTarefa")]
        [AllowAnonymous]
        public IActionResult AdicionarTarefa(
        [FromBody] CreateListaTarefaDto listaDto)
        {
            ListaTarefa lista = _mapper.Map<ListaTarefa>(listaDto);

            _contexto.ListaTarefas.Add(lista);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ListarTarefaPorId),
                new { id = lista.Id }, lista);
        }

        [HttpGet("listaTarefa")]
        [AllowAnonymous]
        public IEnumerable<ReadListaTarefaDto> ListaTarefas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            _logger.LogInformation("UsersController Index executed at {date}", DateTime.UtcNow);
            return _mapper.Map<List<ReadListaTarefaDto>>(_contexto.ListaTarefas.Skip
                (skip).Take(take)).ToList();
        }

        [HttpGet("listaTarefa/{id}")]
        [AllowAnonymous]
        public IActionResult ListarTarefaPorId(int id)
        {
            var lista = _contexto.ListaTarefas.FirstOrDefault(lista => lista.Id == id);

            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);

        }

        [HttpDelete("deleteTarefa/{id}")]
        [AllowAnonymous]
        public IActionResult DeletarUser(int id)
        {
            var lista = _contexto.ListaTarefas.FirstOrDefault(
                lista => lista.Id == id
                );
            if (lista == null)
            {
                return NotFound();
            }
            _contexto.Remove(lista);
            _contexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Tarefa Foi deletado com sucesso");

        }

        [HttpPut("editarTarefa/{id}")]
        [AllowAnonymous]
        public IActionResult AtualizaLista(int id, [FromBody] UpdateListaTarefaDto listaDto)
        {
            var lista = _contexto.ListaTarefas.FirstOrDefault(lista => lista.Id == id);
            if (lista == null)
            {
                return BadRequest();
            }
            _mapper.Map(listaDto, lista);
            _contexto.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, "Foi atualizado com sucesso");
        }

    }
}
