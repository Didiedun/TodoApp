using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.DTOs;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Application.Features.Todos.Queries;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
        {
            var query = new GetTodosQuery();
            var todos = await _mediator.Send(query);
            return Ok(todos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoDto>> GetById(int id)
        {
            try
            {
                var query = new GetTodoByIdQuery { Id = id };
                var todo = await _mediator.Send(query);
                return Ok(todo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoDto>> Create([FromBody] CreateTodoDto createTodoDto)
        {
            var command = new CreateTodoCommand
            {
                Title = createTodoDto.Title,
                Description = createTodoDto.Description
            };
            
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoDto updateTodoDto)
        {
            try
            {
                var command = new UpdateTodoCommand
                {
                    Id = id,
                    Title = updateTodoDto.Title,
                    Description = updateTodoDto.Description,
                    IsCompleted = updateTodoDto.IsCompleted
                };
                
                await _mediator.Send(command);
                
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteTodoCommand { Id = id };
                await _mediator.Send(command);
                
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}