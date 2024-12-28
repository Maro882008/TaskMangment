using Microsoft.EntityFrameworkCore;
using TaskManagment.Models;
using TaskManagment.Models.Entites;
using TaskManagment.Repos.Irepo;

namespace TaskManagment.Repos.immplention
{
    public class UserPage : Iuser
    {
        private readonly AppDbContext db;
        public UserPage(AppDbContext db)
        {
            this.db = db;
        }

        public async Task add(User user)
        {
           await db.users.AddAsync(user);
           await db.SaveChangesAsync();
        }

        public async Task delete(User user)
        {
            db.users.Remove(user);
            await db.SaveChangesAsync();
        }

        public async Task<User> getby(int id)
        {
           return await db.users.FirstOrDefaultAsync(x => x.Userid == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.users.ToListAsync();
        }

        public async Task update(User user)
        {
            db.users.Update(user);
            await db.SaveChangesAsync();    
        }
    }
}
