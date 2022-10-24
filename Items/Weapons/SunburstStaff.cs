using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons
{

	public class SunburstStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a sentry that shoots out sunbeams in every direction");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.sentry = true;
			Item.mana = 10; //How much mana this weapon takes to use.
			Item.width = 26; //Item width hitbox.
			Item.height = 28; //Item height hitbox.
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.DamageType = DamageClass.Summon;
			Item.noMelee = true; //Restricts this weapon dealing melee damage.
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 1, 0, 0); //How much this item is sold for.
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item83;
			Item.shoot = ModContent.ProjectileType<SunburstStaffSunburst>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			position = Main.MouseWorld - new Vector2(0, 28);
			velocity.Y = 1000f;
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.FallenStar, 24);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}