using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular_1.Models;
using System.Web.Http.Cors;

namespace Angular_1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {

        public List<Todo> lista = new List<Todo>();
        int counter = 0;
        public ValuesController()
        {
            lista.Add(new Todo(counter++, "Jeden", null, null, false));
            lista.Add(new Todo(counter++, "Dwa", null, null, false));
            lista.Add(new Todo(counter++, "Trzy", null, null, false));
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return lista;
        }
    

        // POST api/values
        [HttpPost]
        public Todo Post(Todo todo)
        {
            todo.Id = counter++;
            lista.Add(todo);
            return todo;
        }

        // PUT api/values/
        [HttpPut]
        public IActionResult Put( Todo value)
        {
            Todo todo = lista.Find(x => x.Id == value.Id);
            todo.Subject = value.Subject;
            todo.DueDate = value.DueDate;
            todo.Description = value.Description;
            todo.Done = value.Done;
            return Ok();
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int indeks = lista.FindIndex(x => x.Id ==id);
            if (indeks > -1)
            {
                lista.RemoveAt(indeks);
               
                return Ok();
            }
            else
                return NotFound();
        }
    }
    
}
