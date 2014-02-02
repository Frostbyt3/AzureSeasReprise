using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10006 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10006] Warehouseman
        /// </summary>
        public NPC_10006(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10006;
            Face = 6;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                        AddText("Hello! I am a Warehouseman. I can store your goods for you for as long as you would like! ");
                        AddText("I can also keep your money safe so that you do not lose it on long journeys!");
                        AddOption("Thanks!", 255);
                        break;
            }
            AddFinish();
            Send();

        }
    }
}