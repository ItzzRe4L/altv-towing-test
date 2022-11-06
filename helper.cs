using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class helper : IScript
{
    public static IVehicle getNearestVehicle(IPlayer player, float dist = 2f)
    {
        IVehicle vehicle = null;

        foreach(IVehicle car in Alt.GetAllVehicles())
        {
            Position pos = car.Position;
            float playerDistance = player.Position.Distance(pos);

            if(playerDistance < dist)
            {
                dist = playerDistance;
                vehicle = car;
            }
        }
        return vehicle;
    }
}
