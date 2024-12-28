
using TaskManagment.Models.Entites;

namespace TaskManagment.Repos.Irepo
{
    public interface Iproject
    {
        public Task<IEnumerable<Project>> GetProjects();
        public Task<Project> getby(int  id);    
        public Task add(Project project);
        public Task update(Project project);
        public Task delete(Project project);
    }
}
