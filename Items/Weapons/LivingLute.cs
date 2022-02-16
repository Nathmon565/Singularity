using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Items.Weapons {
	public class LivingLute : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true;
			Tooltip.SetDefault("The most lively lute that ever lived.");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.damage = 6;
			item.magic = true;
			item.mana = 2;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Singularity.ToCopper(0, 0, 10, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("LivingLuteBolt"); //Amber staff
			item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack){
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-0.5f, speedX+0.5f), Main.rand.NextFloat(speedY-1.5f, speedY+1.5f), type, damage, knockBack, item.owner);
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-0.5f, speedX+0.5f), Main.rand.NextFloat(speedY-1.5f, speedY+1.5f), type, damage, knockBack, item.owner);
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-0.5f, speedX+0.5f), Main.rand.NextFloat(speedY-1.5f, speedY+1.5f), type, damage, knockBack, item.owner);
			return false;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.LivingWoodWand, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Wood, 8);
			recipe2.AddIngredient(ItemID.LeafWand, 1);
			recipe2.AddTile(TileID.LivingLoom);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.Wood, 8);
			recipe3.AddIngredient(ItemID.LivingMahoganyWand, 1);
			recipe3.AddTile(TileID.LivingLoom);
			recipe3.SetResult(this);
			recipe3.AddRecipe();
			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.Wood, 8);
			recipe4.AddIngredient(ItemID.LivingMahoganyLeafWand, 1);
			recipe4.AddTile(TileID.LivingLoom);
			recipe4.SetResult(this);
			recipe4.AddRecipe();
		}
	}
}