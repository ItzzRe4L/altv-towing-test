using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
    public class MyVehicle : Vehicle
    {
        public bool isTowing { get; set; }
        public int ropeId { get; set; }
        public MyVehicle? towedVeh { get; set; }

        // This constructor is used for creation via constructor
        public MyVehicle(ICore core, uint model, Position position, Rotation rotation) : base(core, model, position, rotation)
        {
            isTowing = false;
            ropeId = 0;
            towedVeh = null;
        }

        // This constructor is used for creation via entity factory
        public MyVehicle(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            isTowing = false;
            ropeId = 0;
            towedVeh = null;
        }
    }
}