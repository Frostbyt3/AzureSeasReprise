using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    /// <summary>
    /// Handles NPC usage for [7050] Compose Items NPC
    /// </summary>
    public class NPC_7050 : INpc
    {

        public NPC_7050(Game_Server.Player _client)
            : base(_client)
        {
            ID = 7050;
            Face = 9;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            _client.Send(GeneralActionPacket.Create(_client.UID, Enum.DataAction.OpenWindow, 1));
        }
    }
}
