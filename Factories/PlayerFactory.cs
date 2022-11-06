using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;
using AltV.Net;
using AltV.Net.Elements.Entities;

namespace test.Factories
{
    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, ushort id)
        {
            return new MyPlayer(core, playerPointer, id);
        }
    }
}
