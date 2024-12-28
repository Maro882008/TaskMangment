using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;
using TaskManagment.ViewModel;

namespace TaskManagment.Controllers
{
    public class taskController : Controller
    {
        private readonly Itask itask;
        private readonly Iproject iproject;
        private readonly Iuser iuser;
        public taskController(Iuser iuser,Iproject iproject,Itask itask)
        {
            this.iuser = iuser;
            this.iproject = iproject;
            this.itask = itask;
        }
        public async Task <IActionResult> Index()
        {
            var t = await itask.GetTasks();
            return View(t);
        }
        public async Task <IActionResult> Create()
        {
            taskViewModel v1 = new taskViewModel()
            {
                projects = await iproject.GetProjects(),
                users = await iuser.GetUsers(),
            };
            return View(v1);
        }
        [HttpPost]
        public async Task<IActionResult> Create(taskViewModel v1)
        {
            await itask.add(v1);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var t = await itask.getby(id);
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(task t1)
        {
            await itask.Delete(t1);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var v1 = await itask.getby(id);
            taskViewModel t = new taskViewModel()
            {
                projects = await iproject.GetProjects(),
                users = await iuser.GetUsers(),
                Title = v1.Title,
                Description = v1.Description,
                StartDate = v1.StartDate,
                EndDate = v1.EndDate,
                Userid = v1.Userid,
                Projectid = v1.Projectid,
                status = v1.status
            };
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(taskViewModel v1, int id)
        {
            await itask.Edit(v1, id);
            return RedirectToAction("Index");
        }
    }
   
   
}
