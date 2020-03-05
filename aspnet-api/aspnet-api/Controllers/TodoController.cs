using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {
        private static List<Todo> todos = new List<Todo>();
        [HttpGet]
        public IEnumerable<Todo> Get() {
            return todos;
        }
        [HttpPost]
        public Todo Post([FromBody] Todo todo) {
        //public Todo Post(Todo todo) {
            todos.Add(todo);
            return todo;
        }
        [HttpPut]
        public IActionResult Put([FromBody] Todo todo) {
        //public IActionResult Put(Todo todo) {
            int i = todos.FindIndex(t => t.Id == todo.Id);
            if (i == -1) return NotFound();
            todos[i] = todo;
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            int i = todos.FindIndex(t => t.Id == id);
            if (i == -1) return NotFound();
            todos.RemoveAt(i);
            return Ok();
        }
    }
}
