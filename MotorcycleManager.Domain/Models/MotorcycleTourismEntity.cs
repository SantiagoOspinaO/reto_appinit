using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Domain.Models
{
    internal class MotorcycleTourismEntity : MotorcycleEntity
    {
        public int TankCapacity { get; set; }
        public bool HasSideCases { get; set; }
    }
}
