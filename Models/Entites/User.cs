namespace TaskManagment.Models.Entites
{
    public class User
    {
        public int Userid {  get; set; }    
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<task> Tasks { get; set; }
    }
}
