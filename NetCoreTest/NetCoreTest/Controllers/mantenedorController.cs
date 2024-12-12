using Microsoft.AspNetCore.Mvc;
using NetCoreTest.Datos;
using NetCoreTest.Models;

namespace NetCoreTest.Controllers
{
    public class mantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //La lista mostrará una lista de contactos
            var oLista = _contactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //Metodo recibe el objeto para guardarlo en bd.
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Metodo solo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = _contactoDatos.Guardar(oContacto);
            
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oContacto);
            }
        }
        public IActionResult Editar(int IdContacto)
        {
            //Metodo recibe el objeto para guardarlo en bd.
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //Metodo solo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oContacto);
            }
        }
        public IActionResult Eliminar(int IdContacto)
        {
            //Metodo recibe el objeto para guardarlo en bd.
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
           
            var respuesta = _contactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oContacto);
            }
        }
    }
}
