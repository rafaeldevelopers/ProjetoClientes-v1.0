using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoClientes.Models;

namespace ProjetoClientes.Controllers
{
    public class ClientesController : Controller
    {

        private readonly Contexto _contexto;

        public ClientesController(Contexto contexto)
        {
            _contexto = contexto;
        }


        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_contexto.Cliente.ToList());
        }


        
             

        [HttpGet]
        public IActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiforgeryToken]
        public IActionResult NovoCliente(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(cliente);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(NovoCliente));
            }

            return RedirectToAction(nameof(Index));


        }


        public IActionResult Detalhes ( int ? id)
        {
            if (id == null)
                return NotFound();
            {
                var cliente = _contexto.Cliente.FirstOrDefault(c => c.ClientesId == id);
                return View(cliente);

            }

        }


        [HttpGet]
        public IActionResult AtualizarCliente(int ? id)
        {
            if (id == null)

                return NotFound();

            var cliente = _contexto.Cliente.Find(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiforgeryToken]
        public IActionResult AtualizarCliente(int Id, Clientes cliente)
        {
            if (Id == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                _contexto.Update(cliente);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Index));

            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Excluir (int? id)
        {
            if ( id == null)
            
                return NotFound();

            var clientes = _contexto.Cliente.FirstOrDefault(c => c.ClientesId == id);

            return View(clientes);
          

        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiforgeryToken]
        public IActionResult ConfirmarExclusao( int ? id)
        {
            if (id == null)
                return NotFound();

            var clientes = _contexto.Cliente.FirstOrDefault(c => c.ClientesId == id);
            _contexto.Remove(clientes);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));



        }

    }

    

}
