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
            item.damage = 62; 
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 30; 
			item.useAnimation = 30;
			item.knockBack = 6;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.Blue; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 0;
			item.useTurn = true;
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
		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			Lighting.AddLight(new Vector2(hitbox.X, hitbox.Y), 0.73f, 0.8f, 0.73f);
		}*/
		
		public override void AddRecipes() {
			ModRecipe reflection = new ModRecipe(mod);
			reflection.AddIngredient(ItemID.HallowedBar, 16);
			reflection.AddIngredient(ItemID.CrystalShard, 12);
			reflection.AddIngredient(ItemID.MagicMirror, 1);
			reflection.AddTile(TileID.Anvils);
			reflection.SetResult(this);
			reflection.AddRecipe();
			ModRecipe reflection2 = new ModRecipe(mod);
			reflection2.AddIngredient(ItemID.HallowedBar, 16);
			reflection2.AddIngredient(ItemID.CrystalShard, 12);
			reflection2.AddIngredient(ItemID.IceMirror, 1);
			reflection2.AddTile(TileID.Anvils);
			reflection2.SetResult(this);
			reflection2.AddRecipe();
			ModRecipe MagicMirror = new ModRecipe(mod);
			MagicMirror.AddIngredient(null, "EnchantedBar", 10);
			MagicMirror.AddIngredient(null, "ReinforcedGlass", 10);
			MagicMirror.AddIngredient(ItemID.RecallPotion, 5);
			MagicMirror.AddTile(TileID.Anvils);
			MagicMirror.SetResult(ItemID.MagicMirror);
			MagicMirror.AddRecipe();
			ModRecipe IceMirror = new ModRecipe(mod);
			IceMirror.AddIngredient(null, "GlacialBar", 10);
			IceMirror.AddIngredient(null, "ReinforcedGlass", 10);
			IceMirror.AddIngredient(ItemID.RecallPotion, 5);
			IceMirror.AddTile(TileID.Anvils);
			IceMirror.SetResult(ItemID.IceMirror);
			IceMirror.AddRecipe();
		}
	}
}