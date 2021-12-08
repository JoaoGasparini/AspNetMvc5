using AppFuncional.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppFuncional.Controllers
{
    [Authorize]
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [OutputCache(Duration = 60)]
        [Route(template:"listar-alunos")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Alunos.ToListAsync());
        }

        [HttpGet]
        [Route(template:"aluno-detalhes/{id:int}")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var alunos = await db.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        [HttpGet]
        [Route(template:"novo-aluno")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route(template: "novo-aluno")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,CPF,Ativo")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alunos);
        }

        [HttpGet]
        [Route(template: "editar-aluno/{id:int}")]
        public async Task<ActionResult> Edit(int? id)
        {
            var alunos = await db.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(NullRerenceException), View = "Erro")]
        [Route(template: "editar-aluno/{id:int}")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,CPF,Ativo")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos).State = EntityState.Modified;
                db.Entry(alunos).Property(a => a.DataMatricula).IsModified = false;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alunos);
        }

        [HttpGet]
        [Route(template: "excluir-aluno/{id:int}")]
        public async Task<ActionResult> Delete(int? id)
        {
            var alunos = await db.Alunos.FindAsync(id);

            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(template: "excluir-aluno/{id:int}")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Alunos alunos = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(alunos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

