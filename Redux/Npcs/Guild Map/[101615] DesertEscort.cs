/*
 * User: pro4never
 * Date: 9/21/2013
 * Time: 8:14 PM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [101615] DesertEscort
    /// </summary>
    public class NPC_101615 : INpc
    {

        public NPC_101615(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 101615;	
			Face = 123;    
    	}

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Are you heading for Desert City? It is free for our members, and 5,000 ");
                    AddText("Silver for others.");
                    AddOption("Please teleport me there.", 1);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    if (_client.Money >= 5000)
                    { _client.ChangeMap(1000, 497, 652); _client.Money -= 5000; Redux.Managers.GuildWar.CurrentWinner.Money += 5000; }
                    else
                    {
                        AddText("Sorry, you do not have enough.");
                        AddOption("I see.", 255);
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
