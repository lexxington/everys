using System.ComponentModel.DataAnnotations;

namespace Everys.Infrastructure.Models
{
    public class Operator
    {
        public int Id { get; set; }
        [Required()]
        public string Name { get; set; }
    }
}
