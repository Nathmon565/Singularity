using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;
using System;

namespace Singularity.Items.Weapons {
	public class SpeedBreaker : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Speed Breaker");
			// Tooltip.SetDefault("Becomes more powerful the faster you are going.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
<<<<<<< HEAD
            Item.damage = 1; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 12;
			Item.height = 12;
			Item.useTime = 20; 
			Item.useAnimation = 20;
			Item.knockBack = 1;
			Item.value = Singularity.ToCopper(0, 5, 0, 0); 
			Item.rare = ItemRarityID.Pink; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 0;
			Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
=======
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
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
		}

		public override void UpdateInventory (Player player){
			for (int i=0; i < 49; i++){
						if (player.inventory[i].Name == "Speed Breaker")
						{
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 0){
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
								Item.damage = 20;
								player.GetAttackSpeed(DamageClass.Melee) /= 1.1f;
								Item.width = 16;
								Item.height = 16;
								Item.scale = 4f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 5){
								Item.damage = 40;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.2f;
								Item.width = 20;
								Item.height = 20;
								Item.scale = 5f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 10){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.3f;
								Item.width = 24;
								Item.height = 24;
								Item.scale = 2f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 20){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.5f;
								Item.width = 30;
								Item.height = 30;
								Item.scale = 2.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 30){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.75f;
								Item.width = 36;
								Item.height = 36;
								Item.scale = 3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 40){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 2f;
								Item.width = 42;
								Item.height = 42;
								Item.scale = 3.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 50){
								Item.damage = 80;
								player.GetAttackSpeed(DamageClass.Melee) *= 4f;
								Item.width = 48;
								Item.height = 48;
								Item.scale = 4f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 60){
								Item.damage = 80;
								player.GetAttackSpeed(DamageClass.Melee) *= 6f;
								Item.width = 60;
								Item.height = 60;
								Item.scale = 5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 100){
								Item.damage = 200;
								player.GetAttackSpeed(DamageClass.Melee) *= 10f;
								Item.width = 72;
								Item.height = 72;
								Item.scale = 6f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) == 0){
								Item.damage = 1;
								Item.width = 12;
								Item.height = 12;
								Item.scale = 1;
=======
>>>>>>> Stashed changes
								Item.damage = 20;
								player.GetAttackSpeed(DamageClass.Melee) /= 1.1f;
								Item.width = 16;
								Item.height = 16;
								Item.scale = 4f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 5){
								Item.damage = 40;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.2f;
								Item.width = 20;
								Item.height = 20;
								Item.scale = 5f/3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 10){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.3f;
								Item.width = 24;
								Item.height = 24;
								Item.scale = 2f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 20){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.5f;
								Item.width = 30;
								Item.height = 30;
								Item.scale = 2.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 30){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 1.75f;
								Item.width = 36;
								Item.height = 36;
								Item.scale = 3f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 40){
								Item.damage = 60;
								player.GetAttackSpeed(DamageClass.Melee) *= 2f;
								Item.width = 42;
								Item.height = 42;
								Item.scale = 3.5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 50){
								Item.damage = 80;
								player.GetAttackSpeed(DamageClass.Melee) *= 4f;
								Item.width = 48;
								Item.height = 48;
								Item.scale = 4f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 60){
								Item.damage = 80;
								player.GetAttackSpeed(DamageClass.Melee) *= 6f;
								Item.width = 60;
								Item.height = 60;
								Item.scale = 5f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) > 100){
								Item.damage = 200;
								player.GetAttackSpeed(DamageClass.Melee) *= 10f;
								Item.width = 72;
								Item.height = 72;
								Item.scale = 6f;
							}
							if ((player.velocity.X)*(player.velocity.X) + (player.velocity.Y)*(player.velocity.Y) == 0){
								Item.damage = 1;
								Item.width = 12;
								Item.height = 12;
								Item.scale = 1;
<<<<<<< Updated upstream
=======
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
							}
						}
			
		}
	}
		
		public override void AddRecipes() {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ConveyorBeltLeft, 20);
			recipe.AddIngredient(ItemID.ConveyorBeltRight, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.Register();
=======
>>>>>>> Stashed changes
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ConveyorBeltLeft, 20);
			recipe.AddIngredient(ItemID.ConveyorBeltRight, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.Register();
<<<<<<< Updated upstream
=======
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
		}
	}
}