using System.ComponentModel.DataAnnotations.Schema;
using ApiTest.MyClass;

namespace ApiTest.Models
{
    public class nav_o_mes : Attributes
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public nav_o_fsk? nav_O_Fsk { get; set; }
    }
}
