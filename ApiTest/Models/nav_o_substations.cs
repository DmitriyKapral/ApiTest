using System.ComponentModel.DataAnnotations.Schema;
using ApiTest.MyClass;

namespace ApiTest.Models
{
    public class nav_o_substations : Attributes
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public nav_o_pmes? nav_O_Pmes { get; set; }
    }
}
