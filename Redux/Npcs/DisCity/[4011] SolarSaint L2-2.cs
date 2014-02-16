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
    /// Handles NPC usage for [4011] SolarSaint
    /// </summary>
    public class NPC_4011 : INpc
    {

        public NPC_4011(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4011;	
			Face = 6;    
    	}
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                    
                case 0:
                    AddText("Have you slayed enough demons in order for me to pass you on to Hell Cloister?");
                    AddOption("I have slayed enough.", 1);
                    AddOption("No, I'll be back.", 255);
                    break;
                case 1:
                    /*if (MaxPlayers >= 30)
                    {
                        AddText("I'm sorry; I cannot send any more to Hell Cloister. ");
                        AddText("I have reached my power limit for today. Please try again next time.");
                        AddOption("Damn!", 255);
                    }
                    else
                    {*/
                    if (_client.ProfessionType == Enum.ProfessionType.Trojan && _client.KOCount >= 800)
                        {
                            _client.ChangeMap(2023, 296, 664);
                        }
                        else if (_client.ProfessionType == Enum.ProfessionType.Warrior && _client.KOCount >= 1000)
                        {
                            _client.ChangeMap(2023, 296, 664);
                        }
                        else if (_client.ProfessionType == Enum.ProfessionType.Archer && _client.KOCount >= 1300)
                        {
                            _client.ChangeMap(2023, 296, 664);
                        }
                        else if (_client.ProfessionType == Enum.ProfessionType.FireTaoist && _client.KOCount >= 1000)
                        {
                            _client.ChangeMap(2023, 296, 664);
                        }
                        else if (_client.ProfessionType == Enum.ProfessionType.WaterTaoist && _client.KOCount >= 600)
                        {
                            _client.ChangeMap(2023, 296, 664);
                        }
                        else
                        {
                            AddText("You have not met the required amount of demon slays, yet. Please kill more demons to proceed.");
                            AddOption("I understand.", 255);
                        }
                    //}
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
