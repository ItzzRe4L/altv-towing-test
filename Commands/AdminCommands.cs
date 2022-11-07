using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using test.Entities;

public class AdminCommands : IScript
{
    [Command("veh")]
    public static void Veh_CMD(MyPlayer player, string vehicleName)
    {
        MyVehicle vehicle = (MyVehicle)Alt.CreateVehicle(Alt.Hash(vehicleName), player.Position, player.Rotation);
        player.SetIntoVehicle(vehicle, 1);
    }

    [Command("getIn")]
    public static void getIn_CMD(MyPlayer player)
    {
        IVehicle veh = helper.getNearestVehicle(player);
        if(veh != null)
        {
            player.SetIntoVehicle(veh, 1);
        } 
        else
        {
            player.SendChatMessage("Kein Fahrzeug in der Nähe!");
        }
    }

    [Command("tow")]
    public static void tow_CMD(MyPlayer player)
    {
        MyVehicle veh1 = (MyVehicle)helper.getNearestVehicle(player, 5f);
        MyPlayer[] players = { player };
        bool result = false;
        player.GetData<bool>("isTowingPl", out result);
        if(result)
        {
            if (veh1 != null)
            {
                player.GetData<MyVehicle>("towedVeh", out MyVehicle veh2);
                player.GetData<int>("ropeId", out int ropeId);

                Alt.EmitClients(players, "attachRopeCar", player, veh1, veh2, ropeId);
            }
            else
            {
                player.SendChatMessage("Kein Fahrzeug in der Nähe!");
            }
        }
        else
        {
            if (veh1 != null)
            {
                Alt.EmitClients(players, "attachRope", player, veh1);
            }
            else
            {
                player.SendChatMessage("Kein Fahrzeug in der Nähe!");
            }
        }
    }

    [Command("untow")]
    public static void untow_CMD(MyPlayer player)
    {
        MyPlayer[] players = { player };
        int ropeId = 0;
        player.GetData<int>("ropeId", out ropeId);
        bool result = false;
        player.GetData<bool>("isTowingPl", out result);
        if(result)
        {
            player.GetData<MyVehicle>("towedVeh", out MyVehicle veh);
            Alt.EmitClients(players, "untowPlayer", player, ropeId, veh);
        }
        else
        {
            MyVehicle veh1 = (MyVehicle)helper.getNearestVehicle(player, 5f);
            veh1.GetData<bool>("isTowing", out bool result2);
            veh1.GetData<bool>("isTowed", out bool result3);
            if (result2||result3)
            {
                veh1.GetData<MyVehicle>("towedVeh", out MyVehicle veh2);
                veh1.GetData<int>("ropeId", out int ropeId2);
                Alt.EmitClients(players, "untowCar", player, veh1, veh2, ropeId2);
            }
        }
    }

    [Command("istowing")]
    public static void istow_CMD(MyPlayer player)
    {
        bool result = false;
        player.GetData<bool>("isTowingPl", out result);
        if(result)
        {
            player.SendChatMessage("isTowing!");
        }
        else
        {
            player.SendChatMessage("isNotTowing!");
        }
    }
}


