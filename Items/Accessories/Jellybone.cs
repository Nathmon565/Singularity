using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Singularity.Projectiles.Minions;
using Singularity.Buffs;

namespace Singularity.Items.Accessories
{
	// public class Jellybone : ModItem
	// {
	// 	public override void SetStaticDefaults()
	// 	{
	// 		DisplayName.SetDefault("Jellybone");
	// 		Tooltip.SetDefault("Become immune for one hit periodically");
	// 	}
		
	// 	public override void SetDefaults()
    //     {
    //         item.width = 24; 
    //         item.height = 28;
    //         item.value = Singularity.ToCopper(0, 0, 30, 0);
    //         item.rare = 2;
    //         item.accessory = true;
    //     }

	// 	public override void UpdateAccessory(Player player, bool hideVisual)
    //     {
	// 		player.statDefense += 1000;
	// 		if (!player.HasBuff(ModContent.BuffType<ClayManStaffBuff>()))
	// 		{
	// 			player.immune = true;
	// 			player.immuneAlpha = 0;
	// 			player.immuneTime = 180;
	// 			item.buffType = ModContent.BuffType<ClayManStaffBuff>();
	// 			item.buffTime = 900;
	// 			player.AddBuff(item.buffType, item.buffTime);
	// 		}
    //     }

		
	// 	public override void AddRecipes()
	// 	{
	// 		ModRecipe recipe = new ModRecipe(mod);
	// 		recipe.AddIngredient(ItemID.BlueJellyfish, 1);
	// 		recipe.AddIngredient(ItemID.Bone, 50);
	// 		recipe.AddTile(TileID.Anvils);
	// 		recipe.SetResult(this);
	// 		recipe.AddRecipe();
	// 		recipe.AddIngredient(ItemID.PinkJellyfish, 1);
	// 		recipe.AddIngredient(ItemID.Bone, 50);
	// 		recipe.AddTile(TileID.Anvils);
	// 		recipe.SetResult(this);
	// 		recipe.AddRecipe();
	// 		recipe.AddIngredient(ItemID.GreenJellyfish, 1);
	// 		recipe.AddIngredient(ItemID.Bone, 50);
	// 		recipe.AddTile(TileID.Anvils);
	// 		recipe.SetResult(this);
	// 		recipe.AddRecipe();	
	// 	}
	// }
}