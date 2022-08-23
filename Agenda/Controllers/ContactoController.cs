using agenda.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agenda.Entidades;

namespace Agenda.Controllers
{
    public class ContactoController : Controller
    {
        private ApplicationDbContext dbContext;
        public ContactoController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        // GET: HomeController1
        public async Task<ActionResult> Index()

        {
            var lista = await dbContext.Contactos.ToListAsync();
            return View(lista);
        }

        // GET: HomeController1/Details/5
        public async Task <ActionResult> Details(int id)

        {
            Contacto contacto= await dbContext.Contactos.FindAsync(id);

            return View(contacto);

        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contacto contacto )
        {
            try
            {
                dbContext.Contactos.Add(contacto);
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
            var contacto=  dbContext.Contactos.Find(id);
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Contacto contacto )
        {
            try
            {
               if (id!=contacto.Id)
                {
                    new Exception("El Id no coincide");
                }
                dbContext.Update(contacto);
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contacto);
            }
        }

        // GET: HomeController1/Delete/5
        public async Task<ActionResult> Delete(int id)

        {
            var contacto = await dbContext.Contactos.FindAsync(id);
            return View(contacto);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Contacto contacto )
        {
            try
            {
                dbContext.Remove(contacto);
                await dbContext.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contacto);
            }
        }
    }
}
