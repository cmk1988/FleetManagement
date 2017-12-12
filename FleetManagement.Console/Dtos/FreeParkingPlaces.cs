using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Dtos
{
    public class FreeParkingPlaces
    {
        public int Free { get; set; }
        public int Total { get; set; }
        public bool IsSelected { get; set; }
    }
}
