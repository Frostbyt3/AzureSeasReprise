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
    /// Handles NPC usage for [101613] CanyonEscort
    /// </summary>
    public class NPC_101613 : INpc
    {

        public NPC_101613(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 101613;	
			Face = 123;    
    	}

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Are you heading for Ape Mountain? It is free for our members, and 5,000 ");
                    AddText("Silver for others.");
                    AddOption("Please teleport me there.", 1);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    if (_client.Money >= 5000)
                    {
                        _client.ChangeMap(1020, 567, 564);
                        uint warwinner = Redux.Database.ServerDatabase.Context.Events.GetWinner().WinnerID;
                        if (_client.GuildId != Redux.Managers.GuildManager.GetGuild(warwinner).Id || _client.Guild == null)
                        {
                            _client.Money -= 5000;
                            Redux.Managers.GuildManager.GetGuild(warwinner).Money += 5000;
                        }
                    }
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
