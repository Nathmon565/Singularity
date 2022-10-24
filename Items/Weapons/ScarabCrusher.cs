using Singularity;
using Singularity.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class ScarabCrusher : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It was too big to be called a sword.\nMassive, thick, heavy, and far too rough.\nIndeed, it was a heap of raw iron.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            Item.damage = 1800; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 40; 
			Item.useAnimation = 40;
			Item.knockBack = 120;
			Item.value = Singularity.ToCopper(0, 12, 0, 0); 
			Item.rare = ItemRarityID.LightPurple; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = false;
			Item.crit = 6;
            Item.useStyle = ItemUseStyleID.Swing; 
            //item.noMelee = true;
			//item.channel = true;
            //item.noUseGraphic = true;
            //item.shoot = ModContent.ProjectileType<ScarabCrusherProjectile>();
			//item.shootSpeed = 80f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(189, 180);
		}
        
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            int numberProjectiles = 1;
			for (int i = 0; i < numberProjectiles; i++) {
				//Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BreakerBlade);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}