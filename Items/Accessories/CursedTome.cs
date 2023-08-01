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
			// DisplayName.SetDefault("Cursed Tome");
			// Tooltip.SetDefault("Increases your max number of minions by 1 \nIncreases the damage and knockback of your minions \nNegates 6 defense");
		}
		
		public override void SetDefaults()
        {
            Item.width = 24; 
            Item.height = 28;
            Item.value = Singularity.ToCopper(0, 0, 30, 0);
            Item.rare = 2;
            Item.accessory = true;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.1f;
			player.GetKnockback(DamageClass.Summon).Base += 2;
			player.statDefense -= 6;
        }
	}
}