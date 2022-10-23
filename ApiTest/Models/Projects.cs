namespace ApiTest.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string NameProject { get; set; }
        public List<Employees> Employees { get; set; }
    }
}
