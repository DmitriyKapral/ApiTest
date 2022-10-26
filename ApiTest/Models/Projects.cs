using Newtonsoft.Json;

namespace ApiTest.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string NameProject { get; set; }
        [JsonIgnore]
        public List<Employees> Employees { get; set; }
    }
}
