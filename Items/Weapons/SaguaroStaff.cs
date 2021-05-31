using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons
{

	public class SaguaroStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a cactus to fire needles at your enemies \n\nNo touchy");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		
		public override void SetDefaults()
		{
			item.damage = 30;
			item.sentry = true;
			item.mana = 10; //How much mana this weapon takes to use.
			item.width = 26; //Item width hitbox.
			item.height = 28; //Item height hitbox.
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.summon = true;
			item.noMelee = true; //Restricts this weapon dealing melee damage.
			item.knockBack = 9;
			item.value = Item.buyPrice(0, 0, 50, 0); //How much this item is sold for.
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item83;
			item.shoot = ModContent.ProjectileType<SaguaroStaffSaguaro>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			damage /= 6;
			position = Main.MouseWorld - new Vector2(0, 40);
			speedY = 1000f;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 6);
			recipe.AddIngredient(ItemID.Cactus, 40);
			recipe.AddIngredient(ItemID.AntlionMandible, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}