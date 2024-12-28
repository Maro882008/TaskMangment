using Microsoft.AspNetCore.Mvc;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;

namespace TaskManagment.Controllers
{
    public class UserController : Controller
    {
        private readonly Iuser iuser;
        public UserController(Iuser iuser)
        {
            this.iuser = iuser;
        }
        public async Task<IActionResult> Index()
        {
            var user = await iuser.GetUsers();
            return View(user);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await iuser.add(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var user = await iuser.getby(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            await iuser.delete(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var user = await iuser.getby(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await iuser.update(user);   
            return RedirectToAction("Index");
        }
    }
}
