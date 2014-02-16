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
    /// Handles NPC usage for [4010] SolarSaint
    /// </summary>
    public class NPC_4010 : INpc
    {

        public NPC_4010(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4010;	
			Face = 6;    
    	}
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                    
                case 0:
                    AddText("You have made it through the first area. You are now in Hell Hall. In order to pass on to Hell Cloister, ");
                    AddText("you will need to slay the appropriate amount of demons for your class. This will power me to teleport you ");
                    AddText("onwards. The amounts are as follows: Trojans: 800; Warriors: 1,000; Archers: 1,300; Fire Taoists: 1,000; ");
                    AddText("Water Taoists: 600. Good luck, Hero. ");
                    AddOption("Thank you.", 255);
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
