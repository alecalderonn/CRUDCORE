using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;



namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        //LA VISTA SOLO MOSTRARA CONTACTOS
        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //DEVUELVE LA VISTA 

            return View();
        }
        [HttpPost]//enviar datos a un servidor utilizando el método HTTP POST.
                  //Este método se utiliza comúnmente para enviar datos al servidor web, como formularios HTML o solicitudes de API.

        public IActionResult Guardar(ContactoModel oContacto)//recibe el objeto de contacto model 
        {
            if (!ModelState.IsValid)//partes de el codigo para hacer los campos obligatorios
                return View();
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN la BD 
            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
            return View();
        }


    }
}
