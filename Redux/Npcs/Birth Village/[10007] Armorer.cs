using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10007 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10007] Armorer
        /// </summary>
        public NPC_10007(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10007;
            Face = 9;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                        AddText("Hello! I am an Armorer. I can sell you equipment that will help protect you on your journey! ");
                        AddText("I carry helmets, armors, and boots.");
                        AddOption("Thanks!", 255);
                        break;
            }
            AddFinish();
            Send();

        }
    }
}