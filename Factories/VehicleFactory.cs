using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using test.Entities;

namespace test.Factories
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, uint model, Position position, Rotation rotation)
        {
            return new MyVehicle(core, model, position, rotation);
        }

        public IVehicle Create(ICore core, IntPtr entityPointer, ushort id)
        {
            return new MyVehicle(core, entityPointer, id);
        }
    }
}
