using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagment.Models.Entites
{
    public class task
    {
        public int taskid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string status {  get; set; }
        public int Userid { get; set; }
        [ForeignKey("Userid")]
        public User? User { get; set; }  
        public int Projectid {  get; set; }
        [ForeignKey("Projectid")]
        public Project? Project { get; set; }

    }
}
