using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Accessories
{
	public class ShapedGlass : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shaped Glass");
			Tooltip.SetDefault("Doubles your damage \nHalves your health");
		}
		
		public override void SetDefaults()
        {
            item.width = 24; 
            item.height = 28;
            item.value = Singularity.ToCopper(0, 0, 30, 0);
            item.rare = 3;
            item.accessory = true;
        }

		public override bool CanEquipAccessory (Player player, int slot){
			return true;
		}
		public override void UpdateEquip (Player player){
			player.statLifeMax2 /=2;
			if (player.statLife >= player.statLifeMax2){
				player.statLife = player.statLifeMax2;
			}
			player.allDamage *=2;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			
        }

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 40);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}