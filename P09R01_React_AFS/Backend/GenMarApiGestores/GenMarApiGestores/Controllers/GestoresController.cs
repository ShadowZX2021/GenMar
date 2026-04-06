using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GenMarApiGestores.Context;
using GenMarApiGestores.Models;

namespace GenMarApiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }

        //Creacion de metodo GET All
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestores_bd.ToList());
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        //Creacion de metodo Get by Id
        [HttpGet("{id}" , Name="GetGestor")]
        public ActionResult Get(int id) {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(gestor => gestor.Id == id);
                return Ok(gestor);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        //Creacion del metodo post
        [HttpPost]
        public ActionResult Post([FromBody] Gestores_BD gestor)
        {
            try
            {
                context.gestores_bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Creacion del metodo Put(Actualizar)

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Gestores_BD gestor) {

            try {
                if (gestor.Id == id)
                {
                    context.Entry(gestor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id }, gestor);

                }
                else
                {
                    return BadRequest();
                }
            
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        
        }
        //Cracion del metodo delete (Eliminar)

        [HttpDelete("{id}")]

        public ActionResult Delete( int id)
        {
            try {
                var gestor = context.gestores_bd.FirstOrDefault(g => g.Id == id);

                if (gestor != null)
                {
                    context.gestores_bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }// Fin de la clase

}//Fin de namespace
