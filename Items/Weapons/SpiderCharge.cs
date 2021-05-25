using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class SpiderCharge : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true;
			DisplayName.SetDefault("Spider Bolt");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.magic = true;
			item.mana = 12;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 4.75f;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpiderBolt");
			item.shootSpeed = 8f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WaterBolt);
			recipe.AddIngredient(null, "ToughSilk", 8);
			recipe.AddIngredient(ItemID.SpiderFang, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}