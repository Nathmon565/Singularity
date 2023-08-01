using Singularity.Projectiles.Minions;
using Singularity.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons
{

	public class ClayManStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Clay Man Staff");
			// Tooltip.SetDefault("Summons Clay Men to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 3;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(0, 0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item44;

			// These below are needed for a minion weapon
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<ClayManStaffBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			Item.shoot = ModContent.ProjectileType<ClayManStaffClayMan>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);
			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			//int projSpawn = Main.rand.Next(1, 11); //picks a number between 1 and 4
			Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("ClayManStaffClayMan").Type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
			Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("ClayManStaffClayMan").Type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 8);
			recipe.AddIngredient(ItemID.ClayPot, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.TinBar, 8);
			recipe2.AddIngredient(ItemID.ClayPot, 1);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.Register();
		}
	}
}