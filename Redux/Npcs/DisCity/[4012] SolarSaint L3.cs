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

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [4012] SolarSaint
    /// </summary>
    public class NPC_4012 : INpc
    {

        public NPC_4012(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4012;	
			Face = 6;    
    	}
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                    
                case 0:
                    AddText("Your final trial awaits.");
                    AddOption("I understand.", 255);
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
