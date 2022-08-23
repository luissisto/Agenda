using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using agenda.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Agenda.Entidades;

namespace Agenda.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDbContext dbContext;
        public UsuarioController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        // GET: HomeController1
        public async Task<ActionResult>  Index()
        {
            var lista = await dbContext.Usuarios.ToListAsync();

            return View(lista);
        }

        // GET: HomeController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
           Usuario usuario= await dbContext.Usuarios.FindAsync (id);
            return View(usuario);

        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task  <ActionResult> Create(Usuario usuario)
        {
            try
            {
                dbContext.Add(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
           var usuario=dbContext.Usuarios.Find(id);
            return View(usuario);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Usuario usuario)
        {
            try
            {
               if (id!=usuario.Id)
                {
                    new Exception("El Id no coincide");
                }
                dbContext.Update(usuario);
                 await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario= dbContext.Usuarios.Find(id);
            return View(usuario);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Usuario usuario)
        {
           try
            {
                    
            dbContext.Remove(usuario);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(usuario);
            }
        }
    }
}
