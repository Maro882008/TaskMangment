using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;

namespace TaskManagment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly Iproject iproject;
        public ProjectController(Iproject iproject)
        {
            this.iproject = iproject;
        }
        public async Task<IActionResult> Index()
        {
            var pro = await iproject.GetProjects();
            return View(pro);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project p1)
        {
            await iproject.add(p1);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var p = await iproject.getby(id);
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Project project)
        {
            await iproject.delete(project);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var p = await iproject.getby(id);
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            await iproject.update(project);
            return RedirectToAction("Index");
        }
    }
}
