using Newtonsoft.Json;

namespace ApiTest.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int? PositionsId { get; set; }
        public Positions? Positions { get; set; }
        [JsonIgnore]
        public int? ProjectsId { get; set; }
        [JsonIgnore]
        public Projects? Projects { get; set; }
    }
}
