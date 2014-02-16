/*
 * User: pro4never
 * Date: 9/24/2013
 * Time: 9:18 PM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;
using Redux.Enum;

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [4009] SolarSaint
    /// </summary>
    public class NPC_4009 : INpc
    {

        public NPC_4009(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4009;	
			Face = 6;    
    	}
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                    
                case 0:
                    AddText("Your quest has just begun. I require 5 Soul Stones so that I may break the barrier to Hell Hall. ");
                    AddText("If you can collect them for me, I will send you through so that you can defeat the demons inside. ");
                    AddText("You can find Soul Stones from any of the demons here. Revenants, UndeadSoldiers, UndeadSpearmen, ");
                    AddText("Eidolon, and Phantoms. Do you have 5 Soul Stones? ");
                    AddOption("I have collected 5 Soul Stones.", 1);
                    AddOption("I'll be back.", 255);
                    break;
                case 1:
                    if (_client.HasItem(723085, 5)/* && MaxEntries < 60*/)
                    {
                        AddText("You are now in Hell Hall. You must slay enough demons to proceed. I will wait for you in the NorthEast quadrant.");
                        AddOption("I understand.", 255);
                        _client.KOCount = 0;
                        _client.ChangeMap(2022, 219, 343);
                        Redux.Managers.PlayerManager.SendToServer(new Packets.Game.TalkPacket(Enum.ChatType.GM, "[DisCity] " + _client.Name + " has collected enough Soul Stones and has been proceeded to Hell Hall!", ChatColour.Yellow));
                        _client.DeleteItem(723085);
                        _client.DeleteItem(723085);
                        _client.DeleteItem(723085);
                        _client.DeleteItem(723085);
                        _client.DeleteItem(723085, true);
                        System.Threading.Thread.Sleep(5000);
                        _client.KOCount = 0;
                    }
                    /*else if (MaxEntries >= 60)
                    {
                        AddText("Sorry, I cannot allow more than 60 people to pass through this gate. I am not strong enough to teleport ");
                        AddText("that many today. You will have to wait until next time.");
                        AddOption("Damn!", 255);
                    }*/
                    else
                    {
                        AddText("You are not strong enough to proceed. I cannot allow you to pass beyond this point. It would be suicide.");
                        AddOption("I understand.", 255);
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
