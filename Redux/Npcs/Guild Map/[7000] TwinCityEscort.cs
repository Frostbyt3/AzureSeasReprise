/*
 * User: cookc
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
    /// Handles NPC usage for [7000] TwinCityEscort
    /// 
    public class NPC_7000 : INpc
    {

        public NPC_7000(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 7000;	
			Face = 7;    
    	}

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Do you want to go back to Twin City?");
                    AddOption("Yes.", 1);
                    AddOption("No. Wait a moment", 255);
                    break;
                case 1:
                    _client.ChangeMap(1002, 356, 336);
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
