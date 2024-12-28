using Microsoft.EntityFrameworkCore;
using TaskManagment.Models;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;

namespace TaskManagment.Repos.immplention
{
    public class ProjectPage : Iproject
    {
        private readonly AppDbContext db;
        public ProjectPage(AppDbContext db)
        {
            this.db = db;
        }
        public async Task add(Project p1)
        {
            await db.projects.AddAsync(p1);
            await db.SaveChangesAsync();
        }

        public async Task delete(Project project)
        {
            db.projects.Remove(project);
            await db.SaveChangesAsync();
        }

        public async Task<Project> getby(int id)
        {
            return await db.projects.FirstOrDefaultAsync(x => x.ProjectId == id);
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await db.projects.ToListAsync();
        }

        public async Task update(Project project)
        {
            db.projects.Update(project);
            await db.SaveChangesAsync();
        }
    }
}
