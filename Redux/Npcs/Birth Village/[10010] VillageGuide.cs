using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_10010 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [10010] VillageGuide
        /// </summary>
        public NPC_10010(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10010;
            Face = 7;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                        AddText("Welcome to Conquer Online: Azure Seas! This is Birth Village. You can learn about the ");
                        AddText("different NPCs here. If you would like to go directly to Twin City, I can send you there!");
                        AddOption("Let's go!", 1);
                        AddOption("I'm not ready, yet", 255);
                        break;
                case 1:
                    _client.ChangeMap(1002, 438, 377);
                    if (_client.ProfessionType == Enum.ProfessionType.Taoist)
                    {
                        AddText("Welcome to Twin City! I have taught you to cast the spells Thunder and Cure to aid your journey ");
                        AddText("as well as provided you with some basic equipment. If you would like to learn more about the server, ");
                        AddText("please talk to AzureGuide here in town! You can also ask a Player Assistant [PA] for help or post on our forums! ");
                        _client.CreateItem(132005);
                        _client.CreateItem(421301);
                        _client.CreateItem(1000000);
                        _client.CreateItem(1000000);
                        _client.CreateItem(1000000);
                        _client.CreateItem(1001000);
                        _client.CreateItem(1001000);
                        _client.CreateItem(1001000);
                        _client.CreateItem(1001000);
                        _client.CreateItem(1001000);
                        _client.CombatManager.LearnNewSkill(Enum.SkillID.Thunder);
                        _client.CombatManager.LearnNewSkill(Enum.SkillID.Cure);
                        AddOption("Thanks!", 255);
                    }
                    else
                    {
                        AddText("Welcome to Twin City! If you would like to learn more about the server, please talk to AzureGuide ");
                        AddText("here in town! You can also ask a Player Assistant [PA] or post on our forums!");
                        if (_client.ProfessionType == Enum.ProfessionType.Trojan || _client.ProfessionType == Enum.ProfessionType.Warrior)
                        {
                            _client.CreateItem(132005);
                            _client.CreateItem(410501);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                        }
                        else if (_client.ProfessionType == Enum.ProfessionType.Archer)
                        {
                            _client.CreateItem(132005);
                            _client.CreateItem(500301);
                            _client.CreateItem(1050000);
                            _client.CreateItem(1050000);
                            _client.CreateItem(1050000);
                            _client.CreateItem(1050000);
                            _client.CreateItem(1050000);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                            _client.CreateItem(1000000);
                        }
                        AddOption("Thanks!", 255);
                    }
                    break;
            }
            AddFinish();
            Send();

        }
    }
}