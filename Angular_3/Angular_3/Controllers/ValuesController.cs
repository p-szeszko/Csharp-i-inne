using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Angular_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Todo> lista = new List<Todo>();
        
        
       
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return lista;
        }


        // POST api/values
        [HttpPost]
        public Todo Post([FromBody]Todo todo)
        {
            todo.Id = lista.Count != 0 ? lista[lista.Count - 1].Id + 1 : 1;
            lista.Add(todo);
            return todo;
        }

        // PUT api/values/
        [HttpPut]
        public IActionResult Put([FromBody]Todo value)
        {
            int indeks = lista.FindIndex(x => x.Id == value.Id);
            if (indeks>-1)
            {
                lista.RemoveAt(indeks);
                lista.Insert(indeks, value);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute]int id)
        {
            int indeks = lista.FindIndex(x => x.Id == id);
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
