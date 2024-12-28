using TaskManagment.Models.Entites;

namespace TaskManagment.Repos.Irepo
{
    public interface Iuser
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task add(User user);
        public Task update(User user);
        public Task<User> getby(int id);
        public Task delete(User user); 
    }
}
