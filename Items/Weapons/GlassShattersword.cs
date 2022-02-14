using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;

namespace Singularity.Items.Weapons {
	public class GlassShattersword : ModItem {
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Glass Shattersword");
			Tooltip.SetDefault("Has a chance to shatter on hit... \nBe Carfeul!");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            item.damage = 27; 
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 24; 
			item.useAnimation = 24;
			item.knockBack = 1;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.White; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
		}
		public bool shatterTime = false;
		public override void OnHitNPC (Player player, NPC target, int damage, float knockBack, bool crit){
			if (shatterTime == true){
				Main.PlaySound(new Terraria.Audio.LegacySoundStyle(13, 0).WithVolume(2));
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
				item.damage *=5;
				shatterTime = true;
			}
		}
		
		public override void AddRecipes() {
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
		}
	}
}