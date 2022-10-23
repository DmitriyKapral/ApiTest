namespace ApiTest.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string NameProject { get; set; }
        public DateTime StartWork { get; set; }
        public List<int> EmployeesId { get; set; }
    }
}
