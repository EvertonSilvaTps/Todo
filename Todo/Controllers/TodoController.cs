using Microsoft.AspNetCore.Mvc;
using Todo.API.Data;
using Todo.API.Migrations;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        //public static List<TodoModel> todos = new List<TodoModel>();

        private AppDbContext _context = new AppDbContext();

        [HttpGet]
        public List<TodoModel> GetTodos()
        {
            return _context.Todos.ToList();
        }

        [HttpPost]
        public ActionResult AddTodo([FromBody] TodoModel todo)  // FromBody = corpo     tem que passar o parametro do objeto
        {

            //todos.Add(todo);

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Created();
        }

        [HttpDelete("{id}")]  // parametro da URL
        public ActionResult DeleteTodo(Guid id) // parametro do Delete
        {
            var tupla = _context.Todos.FirstOrDefault(t => t.Id == id);

            if (tupla is null)
            {
                return NotFound();  // Client Error: [404] > retorna erro como 'não encontrado'
            }

            _context.Todos.Remove(tupla);
            _context.SaveChanges();    // Salvar alteração

            return NoContent();  // Successful: [204] retorna sucesso como 'sem conteúdo'
        }

        // Versão > Update retornando objeto atualizado + 'Ok', ou retorna 400 (requisição ruim) para quando não é um id inválido(Não quebra o programa), e para quando não encontra retorna 404 NotFound
        [HttpPut("{id}")]
        public ActionResult<TodoModel> UpdateTodo(Guid id)
        {
            var tupla = _context.Todos.FirstOrDefault(t => t.Id == id);

            if (tupla is null)
            {
                return NotFound();
            }

            // Atualiza o campo desejado
            tupla.IsCompleted = !tupla.IsCompleted;

            _context.Todos.Update(tupla);
            _context.SaveChanges(); // ESSENCIAL

            return Ok(tupla);
        }


        #region Versão > Update retornando objeto atualizado + 'Ok', ou retorna null para quando é um id inválido (quebra o programa)
        //[HttpPut("{id}")]
        //public TodoModel UpdateTodo(Guid id)
        //{
        //    var tupla = _context.Todos.FirstOrDefault(t => t.Id == id);

        //    if (tupla is null)
        //    {
        //        return null;
        //    }

        //    tupla.IsCompleted = !tupla.IsCompleted;

        //    _context.Todos.Update(tupla);
        //    _context.SaveChanges();

        //    return tupla;
        //}
        #endregion




    }
}
