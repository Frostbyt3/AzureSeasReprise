using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10005 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10005] Weaponsmith
        /// </summary>
        public NPC_10005(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10005;
            Face = 10;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                        AddText("Hello! I am a Weaponsmith! I craft all sorts of weapons that help you to stay the beasts of this land!");
                        AddOption("Thanks!", 255);
                        break;
            }
            AddFinish();
            Send();

        }
    }
}