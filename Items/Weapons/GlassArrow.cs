using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Items.Weapons {
	public class GlassArrow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Tends to shatter on impact.");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<Projectiles.GlassArrow>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 1f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 10);
			recipe.AddIngredient(null, "ReinforcedGlass", 1);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}