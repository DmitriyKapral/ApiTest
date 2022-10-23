namespace ApiTest.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<Users> Users { get; set; }
        public int PositionsId { get; set; }
        public virtual Positions Positions { get; set; }

        public List<Projects> Projects { get; set; }
    }
}
