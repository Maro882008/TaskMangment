using TaskManagment.Models.Entites;
using TaskManagment.ViewModel;

namespace TaskManagment.Repos.Irepo
{
    public interface Itask
    {
        public Task<IEnumerable<task>> GetTasks();
        public Task add(taskViewModel v1);
        public Task Edit(taskViewModel v1,int id);
        public Task Delete(task t1);
        public Task<task> getby(int id);  
    }
}
