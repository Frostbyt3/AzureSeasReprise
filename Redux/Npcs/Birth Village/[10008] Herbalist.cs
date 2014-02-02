using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10008 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10008] Herbalist
        /// </summary>
        public NPC_10008(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10008;
            Face = 3;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                        AddText("Hello! I am an Herbalist. I can sell you herbs and potions that may aid you on your journey! ");
                        AddText("I also sell city scrolls so that you may return to the main cities!");
                        AddOption("Thanks!", 255);
                        break;
            }
            AddFinish();
            Send();

        }
    }
}