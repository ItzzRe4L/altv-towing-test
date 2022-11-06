using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Elements.Entities;

namespace test.Entities
{
    public class MyPlayer : Player
    {
        public bool isTowing { get; set; }
        public int ropeId { get; set; }
        public MyVehicle? towedVeh { get; set; }

        public MyPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            isTowing = false;
            ropeId = 0;
            towedVeh = null;
        }
    }
}
