
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.Scaffolding.Shared.T4Templating;
using Microsoft.EntityFrameworkCore;
using TaskManagment.Models;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;
using TaskManagment.ViewModel;

namespace TaskManagment.Repos.immplention
{
    public class TaskImmplemntion : Itask
    {
        private readonly AppDbContext db;
        public TaskImmplemntion(AppDbContext db)
        {
            this.db = db;
        }
        public async Task add(taskViewModel v1)
        {
           
            var task = new task()
            {
                Title = v1.Title,
                Description = v1.Description,
                StartDate = v1.StartDate,
                EndDate = v1.EndDate,
                Userid = v1.Userid,
                Projectid = v1.Projectid,
                status = v1.status
               
            };
            await db.tasks.AddAsync(task);
            await db.SaveChangesAsync();
        }

        public async Task Delete(task t1)
        {
            db.tasks.Remove(t1);
            await db.SaveChangesAsync();

        }

        public async Task Edit(taskViewModel v1,int id)
        {
            var t = await db.tasks.FirstOrDefaultAsync(x => x.taskid == id);
            t.Title = v1.Title;
            t.Description = v1.Description;
            t.StartDate = v1.StartDate;
            t.EndDate = v1.EndDate;
            t.Userid = v1.Userid;
            t.Projectid = v1.Projectid;
            t.status = v1.status;
            db.tasks.Update(t);
            await db.SaveChangesAsync();
        }

        public async Task<task> getby(int id)
        {
            return await db.tasks.Include(x => x.Project).Include(x => x.User).FirstOrDefaultAsync(x => x.taskid ==id);
        }

        public async Task<IEnumerable<task>> GetTasks()
        {
            return await db.tasks.Include(x => x.Project).Include(x => x.User).ToListAsync();
        }
    }
}
