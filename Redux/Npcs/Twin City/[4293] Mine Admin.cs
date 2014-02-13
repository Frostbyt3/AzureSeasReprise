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
    /// Handles NPC usage for [4293] Mine Admin
    /// </summary>
    public class NPC_4293 : INpc
    {

        public NPC_4293(Game_Server.Player _client)
            :base (_client)
    	{
            ID = 4293;	
			Face = 9;    
    	}

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Hello, I am the assistant of the mine union. ");
                    AddText("If you want to enter the mine cave, I can send you. I can also sell you a Pickaxe for 1,000 Silver if you don't already have one.");
                    AddOption("Enter the mine.", 1);
                    AddOption("Buy a Pickaxe.", 2);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    _client.ChangeMap(1028, 158, 95);
                    break;
                case 2:
                    if (_client.Money >= 1000)
                    {
                        _client.Money -= 1000;
                        _client.CreateItem(562000);
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
