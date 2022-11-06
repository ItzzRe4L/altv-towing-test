using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Client.Elements.Entities;
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
    public static void firstTow(MyPlayer player, Dictionary<string, object> data)
    {
        player.SendChatMessage("Start Towing");
        
        object ropeTemp;
        data.TryGetValue("Rope", out ropeTemp);
        long ropet2 = (long)ropeTemp;
        int rope = (int)ropet2;

        object vehTemp;
        data.TryGetValue("Veh", out vehTemp);
        MyVehicle vehicle = (MyVehicle)vehTemp;
  
        player.SetData("isTowing", true);
        player.SetData("ropeId", rope);
        player.SetData("towedVeh", vehicle);

        
        vehicle.SetData("isTowing", true);
        vehicle.SetData("ropeId", rope);
        
    }

    [ClientEvent("secondTow")]
    public static void secondTow(MyPlayer player, Dictionary<string, object> data)
    {

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

        player.SetData("isTowing", false);
        player.SetData("ropeId", 0);

        veh1.SetData("isTowing", true);
        veh1.SetData("ropeId", rope);
        veh1.SetData("towedVeh", veh2);

        veh2.SetData("isTowing", true);
        veh2.SetData("ropeId", rope);
        veh2.SetData("towedVeh", veh1);
    }

    [ClientEvent("unTow")]
    public static void unTow(MyPlayer player)
    {
        player.SetData("isTowing", false);
        player.SetData("ropeId", 0);
    }
}