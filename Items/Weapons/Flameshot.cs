using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class Flameshot : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses gel for ammo");
		}

		public override void SetDefaults() {
			item.damage = 23;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.ranged = true;
			item.noMelee = true;
			item.knockBack = 0.3f;
			item.value = Singularity.ToCopper(0, 5, 0, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 85; //Flamethrower
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Gel;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 4;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}