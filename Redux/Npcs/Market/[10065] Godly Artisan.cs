using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    /// <summary>
    /// Handles NPC usage for [10065]  Godly Artisan 
    /// NOT FINISHED!
    /// </summary>
    public class NPC_10065 : INpc
    {

        public NPC_10065(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10065;
            Face = 54;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    {
                        AddText("Hello , did you knew that an socketed equipment is better than one without sockets?");
                        AddText("It costs DragonBalls or ToughDrills/StarDrills depending on the item.");
                        AddOption("Socket my weapon", 1);
                        AddOption("Socket my gears", 2);
                        AddOption("No. I like it this way.", 255);
                        break;
                    }
                case 1:
                    {
                        var equipment = _client.Equipment.GetItemBySlot(Enum.ItemLocation.WeaponR);
                        if (equipment == null)
                            AddText("There must be some mistake. You must be wearing a weapon before I can help you socket it!");
                        else if (equipment.Gem2 > 0)
                            AddText("There must be some mistake. Your weapon already has the maximum number of sockets!");
                        else
                        {
                            var cost = (uint)(equipment.Gem1 == 0 ? 1 : 5);
                            AddText("It will cost " + cost + " DragonBall(s) to socket this weapon. Are you positive you wish to continue?");
                            AddOption("I'm Sure!", 10);
                        }
                        AddOption("Nevermind", 255);
                        break;
                    }
                case 2:
                    {
                        AddText("It costs 12 DragonBalls for the first socket and 7 StarDrills for second.If you consider yourself lucky try ToughDrill! ");
                        AddOption("Make the first socket ", 3);
                        AddOption("Make the second socket ", 4);
                        AddOption("No. I like it this way.", 255);
                        break;
                    }
                case 3:
                    {
                        AddText("The first socket requires 12 DragonBalls and there is no turning back! ");
                        AddText("What item would you like me to socket?");
                        AddOption("Helmet/Earrings/TaoCap ", 11);
                        AddOption("Necklace/Bag ", 12);
                        AddOption("Ring/Bracelet ", 16);
                        AddOption("Shield ", 15);
                        AddOption("Armor ", 13);
                        AddOption("Boots ", 18);
                        AddOption("I changed my mind. ", 255);
                        break;
                    }
                case 4:
                    {
                        AddText("Opening the second socket is a delicate matter. I can guarentee an upgrade by using 7 StarDrills ");
                        AddText("or you can try your luck using a ToughDrill.");
                        AddOption("Use ToughDrill", 5);
                        AddOption("Use 7 StarDrills", 6);
                        AddOption("No. I like it this way.", 255);
                        break;
                    }
                case 10:
                    {
                        var equipment = _client.Equipment.GetItemBySlot(Enum.ItemLocation.WeaponR);
                        if (equipment == null)
                        {
                            AddText("There must be some mistake. You must be wearing a weapon before I can help you socket it!");
                            AddOption("Nevermind", 255);
                        }
                        else if (equipment.Gem2 > 0)
                        {
                            AddText("There must be some mistake. Your weapon already has the maximum number of sockets!");
                            AddOption("Nevermind", 255);
                        }
                        else
                        {
                            var cost = (uint)(equipment.Gem1 == 0 ? 1 : 5);
                            if (_client.HasItem(1088000, cost))
                            {
                                if (cost == 1)
                                    equipment.Gem1 = 255;
                                else
                                    equipment.Gem2 = 255;

                                for (var i = 0; i < cost; i++)
                                    _client.DeleteItem(1088000);
                                equipment.Save();
                                _client.Send(ItemInformationPacket.Create(equipment));
                                AddText("It is done! Please enjoy your new equipment.");
                                AddOption("Thanks!", 255);
                            }
                            else
                            {
                                AddText("There must be some mistake. Your do not have the " + cost + " DragonBall(s) required");
                                AddOption("Nevermind", 255);
                            }

                        }
                        break;
                    }

                case 11:
                case 12:
                case 13:
                case 15:
                case 16:
                case 18:
                    {
                        var equipment = _client.Equipment.GetItemBySlot((Enum.ItemLocation)(_linkback % 10));
                        if (equipment == null)
                        {
                            AddText("There must be some mistake., You must be wearing an item before you may socket it!");
                            AddOption("Nevermind", 255);
                        }
                        else if (equipment.Gem1 != 0)
                        {
                            AddText("There must be some mistake. This item already has a socket!");
                            AddOption("Nevermind", 255);
                        }
                        else if (!_client.HasItem(1088000, 12))
                        {
                            AddText("There must be some mistake. You do not have the 12 DragonBalls required to socket this item!");
                            AddOption("Nevermind", 255);
                        }
                        else
                        {
                            for (var i = 0; i < 12; i++)
                                _client.DeleteItem(1088000);
                            equipment.Gem1 = 255;
                            _client.Send(ItemInformationPacket.Create(equipment));
                            AddText("It is done! Please enjoy your new equipment.");
                            AddOption("Thanks!", 255);
                        }

                        break;
                    }
            }
            AddFinish();
            Send();

        }
    }
}
