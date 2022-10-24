using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Items.Weapons {
	public class LivingLute : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
			Tooltip.SetDefault("The most lively lute that ever lived.");
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 30;
			Item.damage = 6;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 2;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3f;
			Item.value = Singularity.ToCopper(0, 0, 10, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("LivingLuteBolt").Type; //Amber staff
			Item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(velocity.X-0.5f, velocity.X+0.5f), Main.rand.NextFloat(velocity.Y-1.5f, velocity.Y+1.5f), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(velocity.X-0.5f, velocity.X+0.5f), Main.rand.NextFloat(velocity.Y-1.5f, velocity.Y+1.5f), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
			Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(velocity.X-0.5f, velocity.X+0.5f), Main.rand.NextFloat(velocity.Y-1.5f, velocity.Y+1.5f), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
			return false;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.LivingWoodWand, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.Wood, 8);
			recipe2.AddIngredient(ItemID.LeafWand, 1);
			recipe2.AddTile(TileID.LivingLoom);
			recipe2.Register();
			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.Wood, 8);
			recipe3.AddIngredient(ItemID.LivingMahoganyWand, 1);
			recipe3.AddTile(TileID.LivingLoom);
			recipe3.Register();
			Recipe recipe4 = CreateRecipe();
			recipe4.AddIngredient(ItemID.Wood, 8);
			recipe4.AddIngredient(ItemID.LivingMahoganyLeafWand, 1);
			recipe4.AddTile(TileID.LivingLoom);
			recipe4.Register();
		}
	}
}