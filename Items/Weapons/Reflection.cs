using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;

namespace Singularity.Items.Weapons {
	public class Reflection : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("SwordrowS");  //The (English) text shown below your weapon's name
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
            item.damage = 22; 
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 25; 
			item.useAnimation = 25;
			item.knockBack = 6;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.Blue; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 0;
            item.useStyle = ItemUseStyleID.SwingThrow; 
			item.shoot = mod.ProjectileType("ReflectionProjectileSpawner");
			item.shootSpeed = 12f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 1;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -perturbedSpeed.X, -perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicMirror, 1);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe.AddIngredient(ItemID.MagicMirror, 1);
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe.AddIngredient(ItemID.IceMirror, 1);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe.AddIngredient(ItemID.IceMirror, 1);
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}