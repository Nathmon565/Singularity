using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;

namespace Singularity.Items.Weapons {
	public class GlassShattersword : ModItem {
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Glass Shattersword");
			// Tooltip.SetDefault("Has a chance to shatter on hit... \nBe Carfeul!");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            Item.damage = 27; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 24; 
			Item.useAnimation = 24;
			Item.knockBack = 1;
			Item.value = Singularity.ToCopper(0, 0, 30, 0); 
			Item.rare = ItemRarityID.White; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 0;
			Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
		}
		public bool shatterTime = false;
		public override void OnHitNPC (Player player, NPC target, NPC.HitInfo hit, int damageDone){
			if (shatterTime == true){
				SoundEngine.PlaySound(SoundID.Shatter);
				for (int i=0; i < 49; i++){
						if (player.inventory[i].Name == "Glass Shattersword")
						{
							player.inventory[i].TurnToAir();
							break;
						}
				}
				shatterTime = false;
			}
			float shatterChance = Main.rand.NextFloat(0,99);
			if (shatterChance >98){
				Item.damage *=5;
				shatterTime = true;
			}
		}
		
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 30);
			recipe.AddIngredient(ItemID.DemoniteBar, 7);
			recipe.AddTile(TileID.GlassKiln);
			recipe.Register();
			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.Glass, 30);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 7);
			recipe2.AddTile(TileID.GlassKiln);
			recipe2.Register();
		}
	}
}