using ApiTest.ModelView;
using Newtonsoft.Json;

namespace ApiTest.Models
{
    public class Positions : Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Employees> Employees { get; set; }
    }
}
