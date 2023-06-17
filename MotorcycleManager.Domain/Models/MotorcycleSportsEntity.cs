using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Domain.Models
{
    internal class MotorcycleSportsEntity : MotorcycleEntity
    {
        public int Power { get; set; }
        public bool HasAleron { get; set; }
    }
}
