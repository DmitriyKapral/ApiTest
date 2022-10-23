namespace ApiTest.Models
{
    public class Positions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employees> Employees { get; set; }
    }
}
