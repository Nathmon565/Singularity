using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Accessories
{
	public class CursedTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Tome");
			Tooltip.SetDefault("Increases your max number of minions by 1 \n\nIncreases the damage and knockback of your minions \n\nLowers your defense");
		}
		
		public override void SetDefaults()
        {
            item.width = 24; 
            item.height = 28;
            item.value = Singularity.ToCopper(0, 0, 30, 0);
            item.rare = 2;
            item.accessory = true;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.maxMinions += 1;
			player.minionDamage += 0.1f;
			player.minionKB += 2;
			player.statDefense -= 8;
        }
	}
}