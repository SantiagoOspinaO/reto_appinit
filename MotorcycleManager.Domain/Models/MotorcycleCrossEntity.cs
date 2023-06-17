using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Domain.Models
{
    internal class MotorcycleCrossEntity : MotorcycleEntity
    {
        public int SeatHeight { get; set; }
        public bool HasRearSuspension { get; set; }
    }
}
