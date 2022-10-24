using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Items.Weapons {
	public class BizarreBazaar : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true;
			Tooltip.SetDefault("Shoots a variety of shots.");
		}

		public override void SetDefaults() {
			item.damage = 36;
			item.magic = true;
			item.mana = 18;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Singularity.ToCopper(0, 0, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ProjectileID.DemonScythe;
			item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack){
			float proj = Main.rand.NextFloat(0,2);
			if (proj<=1){
				item.shootSpeed = 4f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BizarreBazaarBolt1"), damage * 2, knockBack * 2, item.owner);
			}
			if (proj>1 && proj <= 2){
				item.shootSpeed = 8f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BizarreBazaarBolt2"), damage, knockBack, item.owner);
			}
			return false;
		}

		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnchantedBar", 10);
			recipe.AddIngredient(null, "Lodestone", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}