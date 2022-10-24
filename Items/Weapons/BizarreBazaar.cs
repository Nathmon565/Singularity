using Terraria;
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
using Terraria.DataStructures;
=======
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Items.Weapons {
	public class BizarreBazaar : ModItem {
		public override void SetStaticDefaults() {
<<<<<<< Updated upstream
			Item.staff[item.type] = true;
=======
<<<<<<< HEAD
			Item.staff[Item.type] = true;
=======
			Item.staff[item.type] = true;
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
			Tooltip.SetDefault("Shoots a variety of shots.");
		}

		public override void SetDefaults() {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
			Item.damage = 36;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 18;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4f;
			Item.value = Singularity.ToCopper(0, 0, 50, 0);
			Item.rare = 2;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.DemonScythe;
			Item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
			float proj = Main.rand.NextFloat(0,2);
			if (proj<=1){
				Item.shootSpeed = 4f;
				Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("BizarreBazaarBolt1").Type, damage * 2, knockBack * 2, Item.playerIndexTheItemIsReservedFor);
			}
			if (proj>1 && proj <= 2){
				Item.shootSpeed = 8f;
				Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("BizarreBazaarBolt2").Type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
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