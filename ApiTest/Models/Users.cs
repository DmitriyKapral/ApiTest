namespace ApiTest.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int EmployeesId { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
