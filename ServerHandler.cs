using System;
using System.Runtime.CompilerServices;
using AltV.Net;
using AltV.Net.Elements;
using AltV.Net.Elements.Entities;
using test.Entities;
using test.Factories;

public class ServerHandler : Resource
{
    public override void OnStart()
    {

    }

    public override void OnStop()
    {

    }

    public override IEntityFactory<IVehicle> GetVehicleFactory()
    {
        return new MyVehicleFactory();
    }

    public override IEntityFactory<IPlayer> GetPlayerFactory()
    {
        return new MyPlayerFactory();
    }
}