using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Contexto;
using WebApiLibros.Entidades;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private ApplicationDbContext context;
        public AutorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //GET - api/Autor
        [HttpGet]
        public List<Autor> Get()
        {
            return context.Autores.ToList();
        }

        //GET - api/Autor/id
        [HttpGet("{id}")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.Find(id);
            if (autor == null) return NotFound();

            return autor;
        }


        //POST - api/Autor
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }

        //PUT - api/Autor/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Autor autor)
        {
            if (id != autor.AutorId) return BadRequest();

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
            
        }

        //DELETE - api/Autor/id
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id) 
        {
           var aEliminar = context.Autores.Find(id);
            if (aEliminar == null) return NotFound();

            context.Autores.Remove(aEliminar);
            context.SaveChanges();
            return aEliminar;
            
        }

    }
}
