/*
 * User: cookc
 * Date: 27/11/2013
 * Time: 4:10 PM 
 */
using System;
using Redux.Game_Server;
using Redux.Structures;

namespace Redux.Items
{
	/// <summary>
	/// Handles item usage for [723700] MeteorScroll
	/// </summary>
    public class Item_723700: IItem
	{		
        public override void Run(Player _client, ConquerItem _item) 
        {
            if (_client.Level >= 140)
                return;
            _client.DeleteItem(_item);
            _client.GainExpBall(600);
		}
	}
}
