using AspNetMVC5.Data;
using AspNetMVC5.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVC5.Controllers
{
    public class AlunoController : Controller
    {
        private AppDbContext context = new AppDbContext();

        [HttpGet]
        [Route(template:"novo-aluno")]
        public ActionResult NovoAluno()
        {
            return View();
        }

        [HttpPost]
        [Route(template: "novo-aluno")]
        [ValidateAntiForgeryToken]
        public ActionResult NovoAluno(Aluno aluno)
        {
            if (!ModelState.IsValid) return View(aluno);

            aluno.DataMatricula = DateTime.Now;

            context.alunos.Add(aluno);
            context.SaveChanges();

            return View(aluno);
        }
        [HttpGet]
        [Route(template:"obter-alunos")]
        public ActionResult ObterAlunos()
        {
            var alunos = context.alunos.ToList();

            return View("NovoAluno", alunos.FirstOrDefault());
        }

        [HttpGet]
        [Route("editar-aluno")]
        public ActionResult EditarAluno()
        {
            var aluno = context.alunos.Where(a => a.Nome == "Joao").FirstOrDefault();

            aluno.Nome = "Eduardo";
            var entry = context.Entry(aluno);
            context.Set<Aluno>().Attach(aluno);
            entry.State = EntityState.Modified;

            context.SaveChanges();

            var alunonovo = context.alunos.Find(aluno.Id);

            return View("NovoAluno", alunonovo);
        }

        [HttpGet]
        [Route("excluir-aluno")]
        public ActionResult ExcluirAluno()
        {
            var aluno = context.alunos.Where(a => a.Nome == "Eduardo").FirstOrDefault();

            context.alunos.Remove(aluno);
            context.SaveChanges();

            var alunos = context.alunos.ToList();

            return View("NovoAluno", alunos);
        }
    }
}