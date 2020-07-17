using Singularity.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class PearlStaff : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 21;
			item.magic = true;
			item.mana = 7;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4.75f;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PearlBolt");
			item.shootSpeed = 7f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 10);
			recipe.AddIngredient(null, "Pearl", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}