namespace TaskManagment.Models.Entites
{
    public class Project
    {
        public int ProjectId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<task>? Tasks { get; set; }
    }
}
