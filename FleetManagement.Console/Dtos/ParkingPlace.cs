using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Dtos
{
    public class ParkingPlace
    {
        public int Id { get; }
        public bool IsUsed { get; set; }

        public ParkingPlace(int id, bool isUsed)
        {
            this.Id = id;
            this.IsUsed = isUsed;
        }
    }
}
