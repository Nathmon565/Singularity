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
			item.width = 12;
			item.height = 12;
			item.useTime = 20; 
			item.useAnimation = 20;
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
			for (int i=0; i < 49; i++){
						if (player.inventory[i].Name == "Speed Breaker")
						{
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 0){
								item.damage = 20;
								player.meleeSpeed /= 1.1f;
								item.width = 16;
								item.height = 16;
								item.scale = 4f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 5){
								item.damage = 40;
								player.meleeSpeed *= 1.2f;
								item.width = 20;
								item.height = 20;
								item.scale = 5f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 10){
								item.damage = 60;
								player.meleeSpeed *= 1.3f;
								item.width = 24;
								item.height = 24;
								item.scale = 2f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 20){
								item.damage = 60;
								player.meleeSpeed *= 1.5f;
								item.width = 30;
								item.height = 30;
								item.scale = 2.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 30){
								item.damage = 60;
								player.meleeSpeed *= 1.75f;
								item.width = 36;
								item.height = 36;
								item.scale = 3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 40){
								item.damage = 60;
								player.meleeSpeed *= 2f;
								item.width = 42;
								item.height = 42;
								item.scale = 3.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 50){
								item.damage = 80;
								player.meleeSpeed *= 4f;
								item.width = 48;
								item.height = 48;
								item.scale = 4f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 60){
								item.damage = 80;
								player.meleeSpeed *= 6f;
								item.width = 60;
								item.height = 60;
								item.scale = 5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 100){
								item.damage = 200;
								player.meleeSpeed *= 10f;
								item.width = 72;
								item.height = 72;
								item.scale = 6f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) == 0){
								item.damage = 1;
								item.width = 12;
								item.height = 12;
								item.scale = 1;
							}
						}
			
		}
	}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ConveyorBeltLeft, 20);
			recipe.AddIngredient(ItemID.ConveyorBeltRight, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}