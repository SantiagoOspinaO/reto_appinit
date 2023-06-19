using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleManager.Domain.Models
{
    public class MotorcycleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MotorcycleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}