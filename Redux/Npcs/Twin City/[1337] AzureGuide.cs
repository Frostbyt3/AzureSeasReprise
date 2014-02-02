using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_1337 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [1337] AzureGuide
        /// </summary>
        public NPC_1337(Game_Server.Player _client)
            : base(_client)
        {
            ID = 1337;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Welcome to Conquer Online: Azure Seas. I have lots of valuable information. What would you like to know?");
                    AddOption("How do I get CP?", 1);
                    AddOption("Server Rates", 2);
                    AddOption("Available Classes", 3);
                    AddOption("Where is the server hosted?", 4);
                    AddOption("More questions...", 5);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    AddText("You can obtain CP by winning server events or donating to help keep us online as well as ");
                    AddText("help improve the server's performance for all players! Do you have any more questions?");
                    AddOption("More.", 0);
                    AddOption("No more questions.", 255);
                    break;
                case 2:
                    AddText("The server rates are currently the same as Classic Conquer 1.0. ");
                    AddText("This includes experience, drop, and socket rates. Do you have more questions?");
                    AddOption("More.", 0);
                    AddOption("No more questions.", 255);
                    break;
                case 3:
                    AddText("Just as you saw at the character creation screen, you may choose to be ");
                    AddText("a Trojan, Warrior, Archer, or Taoist. Do you have any more questions?");
                    AddOption("More.", 0);
                    AddOption("No more questions.", 255);
                    break;
                case 4:
                    AddText("Conquer Online: Azure Seas is hosted in the United States in the Eastern Time Zone (-5:00). ");
                    AddText("Do you have any more questions?");
                    AddOption("More.", 0);
                    AddOption("No more questions.", 255);
                    break;
                case 5:
                    AddOption("What is the maximum level?", 6);
                    AddOption("Is there second rebirth?", 7);
                    AddOption("What is the maximum Plus item?", 8);
                    AddOption("Are there Pure skills?", 9);
                    AddOption("More questions...", 10);
                    AddOption("Previous questions...", 0);
                    AddOption("No more questions.", 255);
                    break;
                case 6:
                    AddText("The maximum level is 130 at this time. Do you have any more questions?");
                    AddOption("More.", 5);
                    AddOption("No more questions.", 255);
                    break;
                case 7:
                    AddText("Yes, players have the option of being reborn a second time. Do you have any more questions?");
                    AddOption("Where can I become reborn?", 11);
                    AddOption("More.", 5);
                    AddOption("No more questions.", 255);
                    break;
                case 8:
                    AddText("The maximum Plus item level is +12. You can find Plus Stones by hunting monsters or by mining. ");
                    AddText("Do you have any more questions?");
                    AddOption("More.", 5);
                    AddOption("No more questions.", 255);
                    break;
                case 9:
                    AddText("No, there are not currently any second rebirth Pure skills to learn. You can, however, learn ");
                    AddText("first rebirth Pure skills such as Dodge, IronShirt, Reflect, FreezingArrow, Pervade, and ");
                    AddText("CruelShade with the respective Pure class choice. Do you have any more questions?");
                    AddOption("More.", 5);
                    AddOption("No more questions.", 255);
                    break;
                case 10:
                    AddOption("Where can I become reborn?", 11);
                    AddOption("Are there any commands I can use?", 12);
                    AddOption("What do I do if I find a bug, glitch, or exploit?", 13);
                    AddOption("What do I do if I haven't received my donation reward?", 14);
                    AddOption("How can I report someone for abuse?", 15);
                    AddOption("Previous questions...", 5);
                    AddOption("No more questions.", 255);
                    break;
                case 11:
                    AddText("You can obtain first rebirth by finding Ethereal in Wonderland which is located far Northwest of ");
                    AddText("Ape Mountain. You can obtain second rebirth by finding Alex North of Ape Mountain between GiantApes ");
                    AddText("and ThunderApes. Do you have any more questions?");
                    AddOption("More.", 10);
                    AddOption("No more questions.", 255);
                    break;
                case 12:
                    AddText("There are currently no commands for regular players to use. Only the Server Administrator [SA] ");
                    AddText("and the Player Assistants [PA] have commands. Rest assured, [PA]s do not have any game-breaking ");
                    AddText("powers. Do you have any more questions?");
                    AddOption("More.", 10);
                    AddOption("No more questions.", 255);
                    break;
                case 13:
                    AddText("If you find a bug, glitch, exploit or otherwise, please take a screenshot of the issue and post ");
                    AddText("all information you can in our forums under the 'Help & Support' section. Players who ");
                    AddText("successfully find exploits will be rewarded for reporting any issues. Players who abuse ");
                    AddText("any of these issues will have their accounts banned permanently. Do you have any more questions?");
                    AddOption("More.", 10);
                    AddOption("No more questions.", 255);
                    break;
                case 14:
                    AddText("If you have donated, but have not yet received your reward, please send an e-mail to the ");
                    AddText("Server Adminstrator [SA]. DO NOT give any personal information to any Player Assistant [PA] ");
                    AddText("or any other player. The only person authorised to credit donations is the Server Administrator [SA]. ");
                    AddText("The contact e-mail for the Server Adminstrator is on the website: www.coazureseas.com ");
                    AddOption("More.", 10);
                    AddOption("No more questions.", 255);
                    break;
                case 15:
                    AddText("If you witness someone cheating, exploiting the game, or being abusive to you or other players, ");
                    AddText("please take screenshots of the abuse along with any video you may be able to take and post a ");
                    AddText("report under the 'Player Reports' sub-section under 'Help & Support' in the forums. ");
                    AddText("Repeated false reports will result in a permanent account ban. We take all reports seriously.");
                    AddOption("More.", 10);
                    AddOption("No more questions.", 255);
                    break;
            }
            AddFinish();
            Send();

        }
    }
}