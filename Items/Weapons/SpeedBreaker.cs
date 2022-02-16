using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;
using System;

namespace Singularity.Items.Weapons {
	public class SpeedBreaker : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Speed Breaker");
			Tooltip.SetDefault("Becomes more powerful the faster you are going.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            item.damage = 1; 
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 60; 
			item.useAnimation = 60;
			item.knockBack = 1;
			item.value = Singularity.ToCopper(0, 5, 0, 0); 
			item.rare = ItemRarityID.Pink; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 0;
			item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
		}

		public override void UpdateInventory (Player player){
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 0){
				item.damage = 10;
				item.useTime = 60; 
				item.useAnimation = 60;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 5){
				item.damage = 20;
				item.useTime = 30; 
				item.useAnimation = 30;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 10){
				item.damage = 40;
				item.useTime = 20; 
				item.useAnimation = 20;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 20){
				item.damage = 80;
				item.useTime = 15; 
				item.useAnimation = 15;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 30){
				item.damage = 160;
				item.useTime = 12; 
				item.useAnimation = 12;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 40){
				item.damage = 160;
				item.useTime = 10; 
				item.useAnimation = 10;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 50){
				item.damage = 160;
				item.useTime = 8; 
				item.useAnimation = 8;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 60){
				item.damage = 160;
				item.useTime = 6; 
				item.useAnimation = 6;
			}
			if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) == 0){
				item.damage = 1;
				item.useTime = 60; 
				item.useAnimation = 60;
			}
		}
		
		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 30);
			recipe.AddIngredient(ItemID.DemoniteBar, 7);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Glass, 30);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 7);
			recipe2.AddTile(TileID.GlassKiln);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}*/
	}
}