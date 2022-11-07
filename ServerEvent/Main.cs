using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using test.Entities;

public class Main : IScript
{
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public static void OnPlayerConnect (MyPlayer player, string reason)
    {
        player.Model = (uint)PedModel.FreemodeMale01;
        player.Spawn(new AltV.Net.Data.Position(0, 0, 75), 10);
    }

    [ClientEvent("firstTow")]
    public static void firstTow(MyPlayer playerx, Dictionary<string, object> data)
    {
        object playerTemp;
        data.TryGetValue("Player", out playerTemp);
        MyPlayer player = (MyPlayer)playerTemp;

        player.SendChatMessage("Start Towing");
        
        object ropeTemp;
        data.TryGetValue("Rope", out ropeTemp);
        long ropet2 = (long)ropeTemp;
        int rope = (int)ropet2;

        object vehTemp;
        data.TryGetValue("Veh", out vehTemp);
        MyVehicle vehicle = (MyVehicle)vehTemp;
  
        player.SetData("isTowingPl", true);
        player.SetData("ropeId", rope);
        player.SetData("towedVeh", vehicle);

        
        vehicle.SetData("isTowed", true);
        vehicle.SetData("ropeId", rope);

        
        player.SetStreamSyncedMetaData("veh", vehicle);
        player.SetStreamSyncedMetaData("isTowingPl", true);

        if (player.HasStreamSyncedMetaData("veh"))
        {
            Alt.Log($"Meta is set: {vehicle}");
        }
    }

    [ClientEvent("secondTow")]
    public static void secondTow(MyPlayer playerx, Dictionary<string, object> data)
    {
        object playerTemp;
        data.TryGetValue("Player", out playerTemp);
        MyPlayer player = (MyPlayer)playerTemp;


        object ropeTemp;
        data.TryGetValue("Rope", out ropeTemp);
        long ropet2 = (long)ropeTemp;
        int rope = (int)ropet2;

        object veh1Temp;
        data.TryGetValue("Veh1", out veh1Temp);
        MyVehicle veh1 = (MyVehicle)veh1Temp;

        object veh2Temp;
        data.TryGetValue("Veh2", value: out veh2Temp);
        MyVehicle veh2 = (MyVehicle)veh2Temp;

        player.SetData("isTowingPl", false);
        player.SetData("ropeId", 0);

        veh1.SetData("isTowed", true);
        veh1.SetData("ropeId", rope);
        veh1.SetData("towedVeh", veh2);

        veh2.SetData("isTowing", true);
        veh2.SetData("ropeId", rope);
        veh2.SetData("towedVeh", veh1);

        
        player.DeleteStreamSyncedMetaData("veh");
        player.DeleteStreamSyncedMetaData("isTowingPl");
        
        veh2.SetStreamSyncedMetaData("ropeId", rope);
        veh2.SetStreamSyncedMetaData("veh", veh1);
        veh2.SetStreamSyncedMetaData("isTowing", true);
    }

    [ClientEvent("untowPlayer")]
    public static void untowPlayer(MyPlayer playerx, Dictionary<string, object> data)
    {
        object playerTemp;
        data.TryGetValue("Player", out playerTemp);
        MyPlayer player = (MyPlayer)playerTemp;

        object veh1Temp;
        data.TryGetValue("Veh", out veh1Temp);
        MyVehicle veh = (MyVehicle)veh1Temp;

        player.SetData("isTowingPl", false);
        player.SetData("ropeId", 0);

        veh.SetData("isTowed", false);
        veh.SetData("isTowing", false);
        veh.SetData("ropeId", 0);
        veh.SetData("towedVeh", null);
    }

    [ClientEvent("untowCar")]
    public static void untowCar(MyPlayer playerx, Dictionary<string, object> data)
    {
        object veh1Temp;
        data.TryGetValue("Veh1", out veh1Temp);
        MyVehicle veh1 = (MyVehicle)veh1Temp;

        object veh2Temp;
        data.TryGetValue("Veh2", out veh2Temp);
        MyVehicle veh2 = (MyVehicle)veh2Temp;

        veh1.SetData("isTowing", false);
        veh1.SetData("isTowed", false);
        veh1.SetData("ropeId", 0);
        veh1.SetData("towedVeh", null);

        veh2.SetData("isTowing", false);
        veh2.SetData("isTowed", false);
        veh2.SetData("ropeId", 0);
        veh2.SetData("towedVeh", null);
    }
}