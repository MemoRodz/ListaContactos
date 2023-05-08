using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;


namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //Muestra la lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Recibe un objeto para GUARDARLO en la BD
            if(!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Guardar(oContacto);
            if(respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idContacto)
        {
            //Sólo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idContacto)
        {
            //Sólo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult AcercaDe()
        {
            ViewBag.Message = "¿Que tal?, soy Guillermo Rodríguez.";
            return View();
        }

    }
}
