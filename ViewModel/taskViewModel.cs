using TaskManagment.Models.Entites;
using Project = TaskManagment.Models.Entites.Project;

namespace TaskManagment.ViewModel
{
    public class taskViewModel
    {
        public int taskid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string status { get; set; }
        public int Userid { get; set; }
        public int Projectid { get; set; }
        public IEnumerable<Project>? projects { get; set; }
        public IEnumerable<User>? users {  get; set; }
    }
}
