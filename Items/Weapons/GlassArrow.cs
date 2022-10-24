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
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.GlassArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 1.8f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(null, "ReinforcedGlass", 2);
			recipe.AddTile(TileID.GlassKiln);
			recipe.Register();
		}
	}
}