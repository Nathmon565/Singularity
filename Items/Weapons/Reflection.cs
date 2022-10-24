using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Singularity.Projectiles;

namespace Singularity.Items.Weapons {
	public class Reflection : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("SwordrowS");  //The (English) text shown below your weapon's name
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
            Item.damage = 62; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 30; 
			Item.useAnimation = 30;
			Item.knockBack = 6;
			Item.value = Singularity.ToCopper(0, 0, 30, 0); 
			Item.rare = ItemRarityID.Blue; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 0;
			Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing; 
			Item.shoot = Mod.Find<ModProjectile>("ReflectionProjectileSpawner").Type;
			Item.shootSpeed = 12f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int numberProjectiles = 1;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2( velocity.X, velocity.Y); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -perturbedSpeed.X, -perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			Lighting.AddLight(new Vector2(hitbox.X, hitbox.Y), 0.73f, 0.8f, 0.73f);
		}*/
		
		public override void AddRecipes() {
			Recipe reflection = CreateRecipe();
			reflection.AddIngredient(ItemID.HallowedBar, 16);
			reflection.AddIngredient(ItemID.CrystalShard, 12);
			reflection.AddIngredient(ItemID.MagicMirror, 1);
			reflection.AddTile(TileID.Anvils);
			reflection.Register();
			Recipe reflection2 = CreateRecipe();
			reflection2.AddIngredient(ItemID.HallowedBar, 16);
			reflection2.AddIngredient(ItemID.CrystalShard, 12);
			reflection2.AddIngredient(ItemID.IceMirror, 1);
			reflection2.AddTile(TileID.Anvils);
			reflection2.Register();
			Recipe MagicMirror = Recipe.Create(ItemID.MagicMirror);
			MagicMirror.AddIngredient(null, "EnchantedBar", 10);
			MagicMirror.AddIngredient(null, "ReinforcedGlass", 10);
			MagicMirror.AddIngredient(ItemID.RecallPotion, 5);
			MagicMirror.AddTile(TileID.Anvils);
			MagicMirror.Register();
			Recipe IceMirror = Recipe.Create(ItemID.IceMirror);
			IceMirror.AddIngredient(null, "GlacialBar", 10);
			IceMirror.AddIngredient(null, "ReinforcedGlass", 10);
			IceMirror.AddIngredient(ItemID.RecallPotion, 5);
			IceMirror.AddTile(TileID.Anvils);
			IceMirror.Register();
		}
	}
}