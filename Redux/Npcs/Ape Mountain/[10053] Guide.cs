using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10053 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10053] Ape Mountain Guide
        /// </summary>
        public NPC_10053(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10053;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Where are you heading for? I can teleport you for a price of 500 Silver.");
                    AddOption("Twin City", 1);
                    AddOption("Market", 2);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    if (_client.Money >= 500)
                    {
                        _client.Money -= 500;
                        _client.ChangeMap(1020, 381, 21);
                    }
                    else
                    {
                        AddText("Sorry, you do not have 500 Silver.");
                        AddOption("I see.", 255);
                    }
                    break;
                case 2:
                    if (_client.Money >= 500)
                    {
                        _client.Money -= 500;
                        _client.ChangeMap(1036);
                    }
                    else
                    {
                        AddText("Sorry, you do not have 500 Silver.");
                        AddOption("I see.", 255);
                    }
                    break;
            }
            AddFinish();
            Send();

        }
    }
}