using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Data.Dtos.DtoUser;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class UsersController : ControllerBase
    {
        //Instanciar o Contexto
        private Contexto _contexto;
        //Instanciar o Mapper
        private IMapper _mapper;
        //Instaciar o Logger
        private readonly ILogger<UsersController> _logger;

        public UsersController
        (
            Contexto contexto,
            IMapper mapper,
            ILogger<UsersController> logger
        ) 
        { 
            _contexto = contexto;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("createUser")]
        [AllowAnonymous]
        public IActionResult AdicionarUser(
       [FromBody] CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            _contexto.Users.Add(user);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ListarUserPorId),
                new { id = user.Id }, user);
        }

        [HttpGet("listarUser")]
        [AllowAnonymous]
        public IEnumerable<ReadUserDto> ListarUsers([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            _logger.LogInformation("UsersController Index executed at {date}", DateTime.UtcNow);
            return _mapper.Map<List<ReadUserDto>>(_contexto.Users.Skip
                (skip).Take(take)).ToList();
        }

        [HttpGet("listarUser/{id}")]
        [AllowAnonymous]
        public IActionResult ListarUserPorId(int id)
        {
            var user = _contexto.Users?.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpDelete("deleteUser/{id}")]
        [AllowAnonymous]
        public IActionResult DeletarUser(int id)
        {
            var user = _contexto.Users.FirstOrDefault(
                user => user.Id == id
                );
            if (user == null)
            {
                return NotFound();
            }
            _contexto.Remove(user);
            _contexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Usuário Foi deletado com sucesso");

        }
    }
}
