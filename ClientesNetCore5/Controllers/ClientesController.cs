using ClientesNetCore5.Data;
using ClientesNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesNetCore5.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        //constructor
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //http get Index
        public IActionResult Index()
        {
            IEnumerable<Cliente> listacliente = _context.Cliente;
            return View(listacliente);
        }


        //http get Create
        public IActionResult Create()
        {
            
            return View();
        }

        //http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El cliente se ha agregado.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //http get Edit
        public IActionResult Edit(int? id)
        {
            //identificacion = 1;
            if (id == null || id == 0)
            {
                return NotFound();

            }

            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();

            }

            return View(cliente);
        }

        //http post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
           
            if (ModelState.IsValid)
            {
                _context.Cliente.Update(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "Se ha actualizado";
                return RedirectToAction("Index");
            }
            
            return View();
        }

        //http get Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }

            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();

            }

            return View(cliente);
        }

        //http post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCliente(int? identificacion)
        {
            var cliente = _context.Cliente.Find(identificacion);

            if(cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            TempData["mensaje"] = "Se ha eliminado";
            return RedirectToAction("Index");


        }
    }
}
