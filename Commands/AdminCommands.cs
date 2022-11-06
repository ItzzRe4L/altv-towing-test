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
        player.GetData<bool>("isTowing", out result);
        if(result)
        {
            if (veh1 != null)
            {
                player.GetData<MyVehicle>("towedVeh", out MyVehicle veh2);
                player.GetData<int>("ropeId", out int ropeId);

                /*
                player.SendChatMessage(player.ToString());
                player.SendChatMessage(veh1.ToString());
                player.SendChatMessage(veh2.ToString());
                player.SendChatMessage(ropeId.ToString());
                */

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
        player.GetData<bool>("isTowing", out result);
        if(result)
        {
            Alt.EmitClients(players, "untow", player, ropeId);
        }
    }

    [Command("istowing")]
    public static void istow_CMD(MyPlayer player)
    {
        bool result = false;
        player.GetData<bool>("isTowing", out result);
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


