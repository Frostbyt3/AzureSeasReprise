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
    /// Handles NPC usage for [4008] OldExplorer
    /// </summary>
    public class NPC_4008 : INpc
    {

        public NPC_4008(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4008;	
			Face = 6;    
    	}

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Greetings, Traveler. I have explored to the ends of these lands. Beyond this point, the monsters ");
                    AddText("you encounter are much stronger than anywhere else. They use magic unlike any other. If you wish to ");
                    AddText("travel further and survive, you need to be stronger than those monsters. I cannot let you pass ");
                    AddText("unless you have reached at least Level 70. I warn you: I don't recommend proceeding unless you are ");
                    AddText("over Level 100 for your own safety and greater chance of survival. Do you wish to proceed?");
                    AddOption("Proceed.", 1);
                    AddOption("It sounds too dangerous...", 255);
                    break;
                case 1:
                    if (_client.Level >= 70)
                    {
                        _client.ChangeMap(1210, 1041, 717);
                    }
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
